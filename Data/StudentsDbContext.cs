using Microsoft.EntityFrameworkCore;
using SampleExam2020.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleExam2020.Data
{
    public class StudentsDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        
        public StudentsDbContext()
        {
            Students = this.Set<Student>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = Sample1;Trusted_connection=True;MultipleActiveResultSets=true");
        }

    }
}
