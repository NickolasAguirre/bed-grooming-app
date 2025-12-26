using bed_grooming_app.repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace bed_grooming_app.infrastructure.DatabaseContext
{
    public class BedGroomingContextFactory: IDesignTimeDbContextFactory<BedGroomingContext>
    {
        public BedGroomingContext CreateDbContext(string[] args)
        {
            // 1. Localizar la ruta del proyecto principal (API) para leer el appsettings.json
            // Nota: Ajusta "../bed-grooming-app" si la carpeta de tu API tiene otro nombre
            string projectPath = Path.Combine(Directory.GetCurrentDirectory(), "../bed-grooming-app");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            //2.Obtener la cadena de conexión desde el appsettings.json
            //Asegúrate de que en tu JSON se llame "DefaultConnection"
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection' en appsettings.json.");
            }

            // 3. Configurar las opciones del DbContext
            var optionsBuilder = new DbContextOptionsBuilder<BedGroomingContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new BedGroomingContext(optionsBuilder.Options);
        }
    }
}