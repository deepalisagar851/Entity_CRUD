using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace TPWebApp.Model
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("Data Source=DESKTOP-KESBDUA\\SQLEXPRESS;Initial Catalog=CodeMvc;Integrated Security=True;Pooling=False") { }

        public DbSet<Employee> employees { get; set; }
    }
}