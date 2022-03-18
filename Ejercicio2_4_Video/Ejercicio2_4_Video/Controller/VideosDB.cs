using System;
using System.Collections.Generic;
using System.Text;
using Ejercicio2_4_Video.Models;
using System.Threading.Tasks;
using SQLite;

namespace Ejercicio2_4_Video.Controller
{
    public class VideosDB
    {
        readonly SQLiteAsyncConnection db;

        public VideosDB(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Videos>().Wait();
        }

        public Task<List<Videos>> ObtenerListaVideos()
        {
            return db.Table<Videos>().ToListAsync();
        }

        public Task<Videos> ObtenerVideos(int codigo)
        {
            return db.Table<Videos>()
                .Where(i => i.Codigo == codigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> GrabarVideos(Videos videos)
        {
            if (videos.Codigo != 0)
            {
                return db.UpdateAsync(videos);
            }
            else
            {
                return db.InsertAsync(videos);
            }
        }

        public Task<int> EliminarLocalizacion(Videos videos)
        {
            return db.DeleteAsync(videos);
        }
    }
}
