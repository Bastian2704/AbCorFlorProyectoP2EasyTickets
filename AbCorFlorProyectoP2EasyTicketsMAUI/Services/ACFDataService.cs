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
                // Configura la ruta de la base de datos
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "eventos.db");
                _database = new SQLiteAsyncConnection(dbPath);

                // Crea la tabla si no existe
                _database.CreateTableAsync<ACFEventos>().Wait();
            }

            // Guardar un evento en la base de datos
            public async Task<int> SaveEventAsync(ACFEventos evento)
            {
                if (evento.LocalId == 0) // Si LocalId es 0, es un nuevo evento
                {
                    // Insertar un nuevo evento
                    return await _database.InsertAsync(evento);
                }
                else
                {
                    // Actualizar un evento existente
                    return await _database.UpdateAsync(evento);
                }
            }

            // Obtener todos los eventos de la base de datos
            public async Task<List<ACFEventos>> GetEventsAsync()
            {
                return await _database.Table<ACFEventos>().ToListAsync();
            }

            // Obtener un evento por su LocalId
            public async Task<ACFEventos> GetEventByLocalIdAsync(int localId)
            {
                return await _database.Table<ACFEventos>()
                                      .Where(e => e.LocalId == localId)
                                      .FirstOrDefaultAsync();
            }

            // Obtener un evento por su Id (desde la API)
            public async Task<ACFEventos> GetEventByIdAsync(string id)
            {
                return await _database.Table<ACFEventos>()
                                      .Where(e => e.Id == id)
                                      .FirstOrDefaultAsync();
            }

            // Eliminar un evento de la base de datos
            public async Task<int> DeleteEventAsync(ACFEventos evento)
            {
                return await _database.DeleteAsync(evento);
            }

            // Eliminar todos los eventos de la base de datos
            public async Task<int> DeleteAllEventsAsync()
            {
                return await _database.DeleteAllAsync<ACFEventos>();
            }
        }
}
