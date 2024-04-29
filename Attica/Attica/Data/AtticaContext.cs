using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Attica.Models;

namespace Attica.Data
{
    public class AtticaContext : DbContext
    {
        public AtticaContext(DbContextOptions<AtticaContext> options)
            : base(options)
        {
        }

        public DbSet<Attica.Models.ArtPieceDV> ArtPieceDV { get; set; } = default!;
        public DbSet<Attica.Models.Artist> Artist { get; set; } = default!;


       
    }
}
