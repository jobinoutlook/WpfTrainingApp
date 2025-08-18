using EvernoteClone.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel.Helpers
{
    internal static class DatabaseHelper
    {
        private static AppDbContext _appDbContext { get; set; }
        static DatabaseHelper()
        {
            _appDbContext = new AppDbContext();
        }

        public static bool Insert<T>(T Item) where T : class
        {
            bool result = false;

            try
            {
                _appDbContext.Add<T>(Item);
                result = true;
            }
            catch (Exception) { }
                      

            return result;
        }

        public static bool Update<T>(T Item) where T : class
        {
            bool result = false;

            try
            {
                _appDbContext.Update<T>(Item);
                result = true;
            }
            catch (Exception) { }
            
            return result;
        }

        public static bool Delete<T>(T Item) where T : class
        {
            bool result = false;

            try
            {
                _appDbContext.Remove<T>(Item);
                result = true;
            }
            catch (Exception) { }

            return result;
        }

        

        // Generic read: Get all entities of type T
        public static async Task<List<T>> ReadAll<T>() where T : class
        {

            return await _appDbContext.Set<T>().ToListAsync();
        }

        // Generic read: Get by primary key (assuming single key)
        public static async Task<T?> ReadById<T>(object id) where T : class
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }



    }
}
