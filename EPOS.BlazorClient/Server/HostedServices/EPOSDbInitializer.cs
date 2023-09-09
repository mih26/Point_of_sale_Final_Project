using EPOS.BlazorClient.Shared.Models;
using NuGet.Packaging;

namespace EPOS.BlazorClient.Server.HostedServices
{
    public class EPOSDbInitializer
    {
        private readonly EPOSDbContext db;
        public EPOSDbInitializer(EPOSDbContext db)
        {
            this.db = db;
        }
        public async Task SeedAsync()
        {
            if(!db.ProductMeasurements.Any()) {
                string[] types = { "Weight", "Volume", "No(s)", "Dozens" };
                string[][] units= new string[][]
                {
                    new string[] {"Kg", "G", "Mg"},
                    new string[]{"L", "Ml"},
                    new string[] {"No(s)"},
                    new string[] {"Dozen(s)"}
                };
                var i = 0;
                foreach (var type in types)
                {
                    
                    ProductMeasurement bt = new () { BaseTypeName = type };


                    foreach (var su in units[i])
                    {
                        bt.SellUnits?.Add(new SellUnit { SellUnitName = su });
                    }
                    db.ProductMeasurements.Add(bt);
                    i++;

                }
                string[] packages = { "Ploy Back", "Paper Box","Plastic box", "Tetrapack", "Box", "Wrapped", "Can", "Free" };
                foreach (var package in packages)
                {
                    db.SellPackages.Add(new SellPackage { SellPackageName= package });
                    
                }
                await db.SaveChangesAsync();
            }
        }
    }
}
