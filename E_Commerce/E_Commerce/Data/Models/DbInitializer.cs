using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace E_Commerce.Data.Models
{
    public class DbInitializer
    {

        public static void seed(IApplicationBuilder applicationBuilder) {

            AppDbContext context = applicationBuilder.ApplicationServices.GetService<AppDbContext>();

            if (!context.Categories.Any()) {

                context.Categories.AddRange();


            }
            if (!context.Items.Any())
            {

                context.Items.AddRange();

            }



        }


    }
}
