using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Books.Entities;

namespace Books.Web.DataContexts
{
    public class BooksDb : DbContext
    {
        public BooksDb() : base("DefaultConnection") { }

        public DbSet<Book> Book { get; set; }
    }
}