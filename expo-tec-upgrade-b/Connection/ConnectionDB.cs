using MongoDB.Driver;

namespace expo_tec_upgrade_b.Connection
{
    public class ConnectionDB
    {
        public IMongoDatabase Connect()
        {
            try
            {
                const string connectionUri = "mongodb+srv://grupoupgradeperu:CUhQCqGo3DG7z4sN@upgradedb.vcn6i.mongodb.net";
                //const string connectionUri = "mongodb://localhost:27017/";
                var settings = MongoClientSettings.FromConnectionString(connectionUri);
                var client = new MongoClient(settings);
                var database = client.GetDatabase("campania");
                return database;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
