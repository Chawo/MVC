using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataForLabb1.Models;

namespace MyDataForLabb1.Repositories
{
    
    public class AlbumRepositories 
    {

        public IEnumerable<AlbumModel> GetAllAlbums()
        {

            using (var ctx = new Labb1Context())
            { 
                return ctx.album.ToList();
            }

        }

    }
}
