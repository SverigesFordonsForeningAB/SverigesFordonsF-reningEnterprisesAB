using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SverigesFordonsFöreningEnterprisesAB.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SverigesFordonsFöreningEnterprisesAB.Models.Order> Order { get; set; } = default!;

public DbSet<SverigesFordonsFöreningEnterprisesAB.Models.Customer> Customer { get; set; } = default!;

public DbSet<SverigesFordonsFöreningEnterprisesAB.Models.Car> Car { get; set; } = default!;

public DbSet<SverigesFordonsFöreningEnterprisesAB.Models.Motorcycle> Motorcycle { get; set; } = default!;
    }
