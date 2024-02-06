using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace FirstApi.Model
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public ProductContext()
        {
            //constructeur par defaut pour entityframework sake
        }
        public DbSet<Product?> ProductItems { get; set; } = null!;
    }

}
