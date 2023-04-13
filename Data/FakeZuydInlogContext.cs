using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FakeZuydInlog.Models;

namespace FakeZuydInlog.Data
{
    public class FakeZuydInlogContext : DbContext
    {
        public FakeZuydInlogContext (DbContextOptions<FakeZuydInlogContext> options)
            : base(options)
        {
        }

        public DbSet<FakeZuydInlog.Models.Inlog> Inlog { get; set; } = default!;
    }
}
