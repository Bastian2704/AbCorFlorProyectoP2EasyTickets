using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbCorFlorProyectoP2EasyTicketsMAUI.Models;


namespace AbCorFlorProyectoP2EasyTicketsMAUI.Services
{

        internal class ACFDataService
        {
            private readonly SQLiteAsyncConnection _database;

            public ACFDataService()
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eventos.db");
                _database = new SQLiteAsyncConnection(dbPath);

                _database.CreateTableAsync<ACFEventos>().Wait();
            }

            public async Task<int> SaveEventAsync(ACFEventos evento)
            {
                if (evento.LocalId == 0) 
                {
                    return await _database.InsertAsync(evento);
                }
                else
                {
                    return await _database.UpdateAsync(evento);
                }
            }

            public async Task<List<ACFEventos>> GetEventsAsync()
            {
                return await _database.Table<ACFEventos>().ToListAsync();
            }

            public async Task<ACFEventos> GetEventByLocalIdAsync(int localId)
            {
                return await _database.Table<ACFEventos>()
                                      .Where(e => e.LocalId == localId)
                                      .FirstOrDefaultAsync();
            }

            public async Task<ACFEventos> GetEventByIdAsync(string id)
            {
                return await _database.Table<ACFEventos>()
                                      .Where(e => e.Id == id)
                                      .FirstOrDefaultAsync();
            }

            public async Task<int> DeleteEventAsync(ACFEventos evento)
            {
                return await _database.DeleteAsync(evento);
            }

            public async Task<int> DeleteAllEventsAsync()
            {
                return await _database.DeleteAllAsync<ACFEventos>();
            }
        }
}
