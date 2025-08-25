using EvernoteClone.EF;
using log4net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel
{
    public static class DatabaseHelper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DatabaseHelper));


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
                _appDbContext.Add(Item);
                _appDbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex) { 
            
                log.Error(ex);
            
            }
                      

            return result;
        }

        public static bool Update<T>(T Item) where T : class
        {
            bool result = false;

            try
            {
                _appDbContext.Update(Item);
                _appDbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            
            return result;
        }

        public static bool Delete<T>(T Item) where T : class
        {
            bool result = false;

            try
            {
                _appDbContext.Remove(Item);
                result = true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return result;
        }

        

        // Generic read: Get all entities of type T
        public static async Task<List<T>> ReadAllAsync<T>() where T : class
        {
            var items = new List<T>();
            try
            {
                items = await _appDbContext.Set<T>().ToListAsync();
                
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            return items;
        }

        // Generic read: Get by primary key (assuming single key)
        public static async Task<T?> ReadById<T>(object id) where T : class
        {
            return await _appDbContext.Set<T>().FindAsync(id);
        }



    }
}
