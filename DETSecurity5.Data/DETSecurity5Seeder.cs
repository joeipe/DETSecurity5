using DETSecurity5.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DETSecurity5.Data
{
    public class DETSecurity5Seeder
    {
        private readonly DETSecurity5Context _context;
        private readonly UserManager<StoreUser> _userManager;

        public DETSecurity5Seeder(DETSecurity5Context context, UserManager<StoreUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByEmailAsync("joe.ipe@hotmail.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Joe",
                    LastName = "Ipe",
                    Email = "joe.ipe@hotmail.com",
                    UserName = "joe.ipe@hotmail.com"
                };

                var result = await _userManager.CreateAsync(user, "Passw0rd$");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create a user in seeder");
                }
            }

            if (!_context.Orders.Any())
            {
                Order order = new Order()
                {
                    OrderNumber = "ODRTest",
                    User = user
                };

                _context.Orders.Add(order);
                _context.SaveChanges();
            }
        }
    }
}
