using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataForLabb1.Models;

namespace MyDataForLabb1.Repositories
{
    public class ImageRepositories
    {
        public IEnumerable<ModelGallery> GetAllImages()
        {
            using (var ctx = new Labb1Context())
            {
                return ctx.image.ToList();
            }
        }

        public void Add(ModelGallery image)
        {
            using (var ctx = new Labb1Context())
            {
                var newImage = new ModelGallery
                {
                    Id = Guid.NewGuid(),
                    Name = image.Name,
                    dateAdded = DateTime.Now
                };

                ctx.image.Add(newImage);

                ctx.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using (var ctx = new Labb1Context())
            {
                var images = ctx.image.Single(x => x.Id == id);
                 
                ctx.image.Remove(images);

                ctx.SaveChanges();
            }
        }
    }
}
