namespace Task1.Data
{
    public static class DataSeeding
    {
        public static async void Seed(this IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new List<IdentityRole>
                {
                    new IdentityRole("Admin"),
                    new IdentityRole("User")
                };
                foreach (var role in roles)
                {
                    if(!await roleManager.RoleExistsAsync(role.Name))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }

                var user = new IdentityUser
                {
                        UserName = "hasan",
                        Email = "hasan@gmail.com",
                        PasswordHash = "pass1".GetHashCode().ToString(),
                };

                var admin = new IdentityUser
                {
                    UserName = "hasanAdmin",
                    Email = "hasanAdmin@gmail.com",
                };

                if(await userManager.FindByEmailAsync(user.Email) == null)
                {
                    var result = await userManager.CreateAsync(user,"pass1");

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "User");
                    }
                }

                if (await userManager.FindByEmailAsync(admin.Email) == null)
                {
                    var result = await userManager.CreateAsync(admin,"pass1Admin");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(admin, "Admin");
                    }

                }
            }
        }
    }
}
