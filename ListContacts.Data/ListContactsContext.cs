using ListContacts.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListContacts.Data
{
    public class ListContactsContext : DbContext
    {
        public DbSet<Contacts> Contacts { get; set; }

        public ListContactsContext(DbContextOptions<ListContactsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
