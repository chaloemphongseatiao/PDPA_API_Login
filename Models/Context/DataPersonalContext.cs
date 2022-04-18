using DotnetAPI5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDPA_API.Models
{
    
        public class DataPersonalContext : DbContext
        {
            public DataPersonalContext(DbContextOptions<DataPersonalContext> options) : base(options) 
            {
                        
            }

        public DbSet<Consent> Consents { get; set; }
        public DbSet<Account> Accounts { get; set; }

       
    }
    
}
