using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Labb1Library
{
    class Labb1Context : DbContext
    {
        public Labb1Context() : base("name=MVCLabb123")
        {

        }

        public DbSet<ModelGallery> image { get; set; }
        public DbSet<AlbumModel> album { get; set; }
        public DbSet<AlbumImages> albumImage { get; set; }
        public DbSet<Comments> comment { get; set; }
    }
}
