using Books_Api.dbAccess.dao;
using Books_Api.Irepositories;
using Books_Api.repository.Irepositories;
using Books_Api.services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books_Api.middlewareService
{
    public static class InyeccionService
    {
        private static  IConfiguration _configuration;
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
  
            
            //Services
            services.AddSingleton<IBookService, BookService>();
            services.AddSingleton<IEditorialsService, EditorialsService>();

            //Repositories
            services.AddSingleton<IBooksRepository, BooksRepository>();
            services.AddSingleton<IEditorialsRepository, EditorialsRepository>();


            //Dao
            services.AddSingleton<dbAccess.daoEditorials.IDao, dbAccess.daoEditorials.Dao>();
            services.AddSingleton<IDao, Dao>();
            return services;
        }

  

      

    }
}
