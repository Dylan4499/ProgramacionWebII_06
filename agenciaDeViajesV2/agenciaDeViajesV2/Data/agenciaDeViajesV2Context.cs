using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using agenciaDeViajesV2.Models;

namespace agenciaDeViajesV2.Data
{
    public class agenciaDeViajesV2Context : DbContext
    {
        public agenciaDeViajesV2Context (DbContextOptions<agenciaDeViajesV2Context> options)
            : base(options)
        {
        }

        public DbSet<agenciaDeViajesV2.Models.RoomClass> RoomClass { get; set; } = default!;
    }
}
