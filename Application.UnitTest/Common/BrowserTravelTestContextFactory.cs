using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.UnitTest.Common
{
    public class BrowserTravelTestContextFactory
    {
        public static BrowserTravelTestContext Create()
        {
            var options = new DbContextOptionsBuilder<BrowserTravelTestContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new BrowserTravelTestContext(options);

            context.Database.EnsureCreated();

            context.Editorials.AddRange(new[] {
                new Editorial { Id = 101, Nombre = "Panamericana", Sede = "Cartagena" },
                new Editorial { Id = 102, Nombre = "Norma", Sede = "Barranquilla" },
                new Editorial { Id = 103, Nombre = "Agua Negra", Sede = "Bogota"},
            });

            context.Autors.AddRange(new[] {
                new Autor { Id = 101, Nombre = "Gabriel", Apellidos = "Garcia Marquez" },
                new Autor { Id = 102, Nombre = "Stephen", Apellidos = "King" },
                new Autor { Id = 103, Nombre = "Jason", Apellidos = "Tayler" },
            });

            context.Libros.AddRange(new[] {
                new Libro { Id = 101, Titulo = "100 años de soledad", NPaginas = "100", IdEditorial = 101 },
                new Libro { Id = 102, Titulo = "It", NPaginas = "150", IdEditorial = 102},
                new Libro { Id = 103, Titulo = "Clean Architecture", IdEditorial = 103},
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(BrowserTravelTestContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
