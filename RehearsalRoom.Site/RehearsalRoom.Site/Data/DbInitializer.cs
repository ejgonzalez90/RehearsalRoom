using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RehearsalRoom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RehearsalRoom.Site.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RehearsalRoomContext context)
        {
            context.Database.EnsureCreated();

            // TODO: Seed con valores reales
            /*
            if (context.InstrumentBrands.Any())
            {
                return;
            }

            var instrumentBrands = new InstrumentBrand[]
            {
                // Brands
                new InstrumentBrand { BrandName = "Fender" },
                new InstrumentBrand { BrandName = "Gibson" },
                new InstrumentBrand { BrandName = "Ibanez" },
                new InstrumentBrand { BrandName = "Marshall" },
                new InstrumentBrand { BrandName = "Tama" },
                new InstrumentBrand { BrandName = "Paiste" }
            };

            context.InstrumentBrands.AddRange(instrumentBrands);
            context.SaveChanges();

            // Ibanez instrumentBrandId
            var instrumentBrandId = context
                .InstrumentBrands
                .First(ib => ib.BrandName == "Ibanez")
                .InstrumentBrandId;

            var brandModels = new BrandModel[]
            {
                // Ibanez
                new BrandModel { InstrumentBrandId = instrumentBrandId, Name = "GRX40" },
                new BrandModel { InstrumentBrandId = instrumentBrandId, Name = "RG7321" },
                new BrandModel { InstrumentBrandId = instrumentBrandId, Name = "AEG10" },

                // Marshall
                new BrandModel { InstrumentBrandId = 4, Name = "Code 50" }
            };

            context.BrandModels.AddRange(brandModels);
            context.SaveChanges();
            */
        }
    }
}
