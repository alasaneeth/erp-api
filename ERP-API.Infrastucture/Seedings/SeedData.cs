using ERP_API.Domain.Models;
using ERP_API.Infrastucture.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_API.Infrastucture.Seedings
{
    public class SeedData
    {
        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope(); 

            var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new List<IdentityRole>
            {
                new IdentityRole {Name="ADMIN", NormalizedName="ADMIN"},
                new IdentityRole{Name="MANGER", NormalizedName="MANAGER"},
                new IdentityRole{Name="CASHIER", NormalizedName="CASHIER"}
            };

            foreach (var role in roles)
            {
                if (!await roleManger.RoleExistsAsync(role.Name)) 
                {
                    await roleManger.CreateAsync(role);
                }
            }
        }

        public static async Task SeedDataAsync(ApplicationDbContext _dbcontex)
        {
            if (!_dbcontex.CustomerTypes.Any()) 
            {
                await _dbcontex.AddRangeAsync(
                        new CustomerType
                        {
                            Name="Wholesale"
                        },
                        new CustomerType
                        {
                            Name="Retail"
                        }
                    );

                await _dbcontex.SaveChangesAsync();
            }
        }
    }
}
