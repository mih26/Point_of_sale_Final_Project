using AForge.Video.DirectShow;
using EPOS.FormClient.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace EPOS.FormClient
{
    public partial class Form2 : Form
    {
        HttpClient client;
        List<ItemViewModel> itemViewModels = new List<ItemViewModel>();
        List<string> codes = new List<string>();
        public Form1 StartForm { get; set; }    
        public Form2()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        private void Form2_Load(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5168/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filter in filterInfoCollection)
            {
                comboBox1.Items.Add(filter.Name);
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            
        }

        private async void CaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap img = (Bitmap)eventArgs.Frame.Clone();

            ZXing.BarcodeReader reader = new ZXing.BarcodeReader()
            {
                AutoRotate = true,
                TryInverted = true,
                Options = {
                   PossibleFormats= new[] {BarcodeFormat.CODE_128, BarcodeFormat.CODE_93},
                   TryHarder = true,
                ReturnCodabarStartEnd = true,
                PureBarcode = false
               }
            };
            var result = reader.Decode(img);
            if (result != null)
            {
                label1.Invoke(new MethodInvoker( delegate ()
                {
                    label1.Text = result.ToString();
                    
                    if(result != null)
                    {
                        if (!codes.Contains(result.ToString())) { 
                            codes.Add(result.ToString());
                            if (label1.Text.Length == 14)
                            {
                                GetAsync(label1.Text).ContinueWith(t =>
                                {

                                });
                            }
                        }
                        else
                        {
                            
                        }
                        
                    }
                    

                }));
            }
            pictureBox1.Image = img;
        }
        public async Task GetAsync(string code)
        {
            var x = await GetItem(code);
            if(x != null)
            {
                if(!itemViewModels.Contains(x))
                    itemViewModels.Add(x);
            }
            
        }
        public async  Task<ItemViewModel> GetItem(string code)
        {
            ItemViewModel item = null;
            HttpResponseMessage response = await client.GetAsync($"Orders/POS/{code}");
            if (response.IsSuccessStatusCode)
            {
                item = await response.Content.ReadAsAsync<ItemViewModel>();
            }
            return item;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(captureDevice != null)
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                }
            }
            if(itemViewModels.Count> 0)
            this.StartForm.RefreshGrid(itemViewModels);
        }
    }
}
