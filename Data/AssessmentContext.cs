using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assessment.Models;

namespace Assessment.Data
{
    public class AssessmentContext : DbContext
    {
        public AssessmentContext (DbContextOptions<AssessmentContext> options)
            : base(options)
        {
        }

        public DbSet<Assessment.Models.Amigo> Amigo { get; set; } = default!;

        public DbSet<Assessment.Models.Estado> Estado { get; set; }

        public DbSet<Assessment.Models.Pais> Pais { get; set; }
    }
}
