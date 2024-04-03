using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            // Fick problem med att lägga till Migrations och köra Update-Database så fick göra så här för att få det att fungera.
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\code\\ASP.NET\\Silicon_Project\\WebApp_Silicon\\Infrastructure\\Data\\database.mdf;Integrated Security=True;Connect Timeout=30");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
