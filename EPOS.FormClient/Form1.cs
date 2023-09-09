using AForge.Video.DirectShow;
using EPOS.FormClient.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EPOS.FormClient
{
    public partial class Form1 : Form
    {
        List<ItemViewModel> items = new List<ItemViewModel>();
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public  void RefreshGrid(List<ItemViewModel> items) { 
            this.items.AddRange(items);
            this.dataGridView1.DataSource = items
                .Select(x=> new
                {
                    x.ProductName,
                    x.UnitPrice,
                    Quantity = 1,
                    SubTotal= x.UnitPrice*1
                }).ToList();
            this.label2.Text = items.Sum(x => x.UnitPrice * 1).ToString("0.00");
            this.label4.Text = ((items.Sum(x => x.UnitPrice * 1)) *.015M ).ToString("0.00");
            this.label6.Text = (decimal.Parse(this.label2.Text) + decimal.Parse(this.label2.Text)).ToString("0.00");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new Form2 { StartForm = this}.ShowDialog();
        }
    }
}
