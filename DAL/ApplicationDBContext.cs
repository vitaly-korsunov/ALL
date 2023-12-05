﻿using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        //  public DbSet<Category> Categories { get; set; }
        //  public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
