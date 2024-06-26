﻿using Proyectos.Shared.Entities;
using Proyectos.API.Helpers;
using Proyectos.Shared.Enums;
using Azure.Identity;
using Azure;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Diagnostics.Eventing.Reader;

namespace Proyectos.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }



        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckPetTypesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1010", "OAP", "Admin", "orlapez@gmail.com", "305232456", "Cr 45 7896", UserType.Admin);




        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }



        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(email);

            if (user == null)
            {

                user = new User
                {
                    Document = document,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phone,
                    UserName = email,
                    Address = address,
                    UserType = userType,
                };

                await _userHelper.AdduserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }

        private async Task CheckPetTypesAsync()
        {
            if (!_context.actividadesde_Investigaciones.Any())
            {
                _context.actividadesde_Investigaciones.Add(new ActividadesdeInvestigacion { Nombre = "Entrevista" });
                _context.actividadesde_Investigaciones.Add(new ActividadesdeInvestigacion { Nombre = "Consulta" });
                _context.actividadesde_Investigaciones.Add(new ActividadesdeInvestigacion { Nombre = "Indagacion" });
                _context.actividadesde_Investigaciones.Add(new ActividadesdeInvestigacion { Nombre = "Trabajo de campo" });

            }



            await _context.SaveChangesAsync();

        }
    }
}
    

