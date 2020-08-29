using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhones.Models
{
    public class MobilePhoneContext : DbContext
    {
        public MobilePhoneContext(DbContextOptions<MobilePhoneContext> options) : base(options)
        {

        }

        public DbSet<MobilePhone> MobilePhones { get; set; }
        
    }
}
