using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyDataForLabb1.Models;
using MyDataForLabb1.Repositories;

namespace MyDataForLabb1
{
    public class Labb1Context : DbContext
    {
        public Labb1Context() : base("MyDataForLabb1.Labb1Context")
        {

        }

        public DbSet<ModelGallery> image { get; set; }
        public DbSet<AlbumModel> album { get; set; }
        public DbSet<AlbumImages> albumImage { get; set; }
        public DbSet<Comments> comment { get; set; }
    }
}
