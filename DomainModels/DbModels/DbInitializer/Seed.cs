using DomainModels.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStoreAPP.Common.Enumi;

namespace DomainModels.DbModels.DbInitializer
{
    public static class Seed
    {
        public static void Seed1(ApplicationDbContext ctx)
        {
            //ApplicationDbContext ctx = applicationBuilder.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            if (!ctx.Sifarnik.Any(x => x.TipSif == WebStoreAPP.Common.Enumi.TipSif.TIP_PROIZVODA))
            {
                ctx.Sifarnik.Add(new Sifarnik() { Vrijednost = (int)Kategorija.Auta, TipSif = TipSif.TIP_PROIZVODA, Naziv = "Auta" });
                ctx.Sifarnik.Add(new Sifarnik() { Vrijednost = (int)Kategorija.IT, TipSif = TipSif.TIP_PROIZVODA, Naziv = "IT" });

            }

            ctx.SaveChanges();
            //if (!lovs.Any(w => w.LovType == LovType.ACCOUNT_GROUP_VIEW))
            //{
            //    // account documentation
            //    ctx.LOV.Add(new LOV() { Value = (int)AccountGroupView.RTG, LovType = LovType.ACCOUNT_GROUP_VIEW, Name = "Allow only RTG View", OrdNo = 0, Extra1 = "RTG View", Extra3 = "1" });
            //    ctx.LOV.Add(new LOV() { Value = (int)AccountGroupView.ADG, LovType = LovType.ACCOUNT_GROUP_VIEW, Name = "Allow only ADG View", OrdNo = 1, Extra1 = "ADG View", Extra3 = "1" });
            //    ctx.LOV.Add(new LOV() { Value = (int)AccountGroupView.ALL, LovType = LovType.ACCOUNT_GROUP_VIEW, Name = "Allow both RTG and ADG View", OrdNo = 2, Extra3 = "0" });
            //}
        }
    }
}
