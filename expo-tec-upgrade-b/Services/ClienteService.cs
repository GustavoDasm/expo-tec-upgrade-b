using MongoDB.Driver;
using expo_tec_upgrade_b.Models;
using expo_tec_upgrade_b.Connection;
namespace expo_tec_upgrade_b.Services
{
    public class ClienteService
    {
        private readonly ConnectionDB connection;

        public ClienteService(ConnectionDB connection)
        {
            this.connection = connection;
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            var col = connection.Connect().GetCollection<Cliente>("cliente");

            var result = await col.Find(FilterDefinition<Cliente>.Empty).ToListAsync();

            return result;
        }

        public async Task<bool> PostCliente(Cliente nuevoCliente)
        {
            try
            {
                var col = connection.Connect().GetCollection<Cliente>("cliente");

                await col.InsertOneAsync(nuevoCliente);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar cliente: {ex.Message}");
                return false;
            }
        }
    }
}
