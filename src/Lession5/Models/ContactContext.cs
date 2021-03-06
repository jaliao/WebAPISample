﻿using Microsoft.EntityFrameworkCore;

namespace Lession5.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
  : base(options)
        {
        }

        public DbSet<ContactItem> ContactItems { get; set; }
    }
}
