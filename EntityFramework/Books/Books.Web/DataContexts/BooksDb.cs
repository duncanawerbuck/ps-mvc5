using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Books.Entities;

namespace Books.Web.DataContexts
{
    public class BooksDb : DbContext
    {
        public BooksDb() : base("DefaultConnection")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<Book> Book { get; set; }
    }
}