using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorScriptureApp.Models
{
    public class RazorScriptureAppContext : DbContext
    {
        public RazorScriptureAppContext (DbContextOptions<RazorScriptureAppContext> options)
            : base(options)
        {
        }

        public DbSet<RazorScriptureApp.Models.Scripture> Scripture { get; set; }
        public object Notes { get; internal set; }
        public object Note { get; internal set; }
    }
}
