using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using MongoDB.Driver;
using MongoDB.Bson;

namespace POC.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        private readonly IMongoCollection<ZoneData> _zoneCollection;

        public ZonesController()
        {
            var client = new MongoClient("mongodb+srv://daryl:dada@cluster0.hv8hpda.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("alarmsystem");
            _zoneCollection = database.GetCollection<ZoneData>("zones");
        }

        // Endpoint pour recevoir les données des zones de la Raspberry Pi
        [HttpPost("receive_zones_data")]
        public async Task<IActionResult> ReceiveZonesData([FromBody] ZoneData zonesData)
        {
            if (zonesData == null)
            {
                return BadRequest("Invalid data.");
            }

            string zone1 = zonesData.Zone1;
            string zone2 = zonesData.Zone2;
            string zone3 = zonesData.Zone3;
            string zone4 = zonesData.Zone4;

            // Afficher les données des zones
            Console.WriteLine("Données des zones reçues :");
            Console.WriteLine($"Zone1 : {zone1}");
            Console.WriteLine($"Zone2 : {zone2}");
            Console.WriteLine($"Zone3 : {zone3}");
            Console.WriteLine($"Zone4 : {zone4}");

            var filter = Builders<ZoneData>.Filter.Eq(z => z.Id, "1"); 
            var update = Builders<ZoneData>.Update
                .Set(z => z.Zone1, zone1)
                .Set(z => z.Zone2, zone2)
                .Set(z => z.Zone3, zone3)
                .Set(z => z.Zone4, zone4);

            try
            {
                var result = await _zoneCollection.UpdateOneAsync(filter, update);
                if (result.MatchedCount == 0)
                {
                    Console.WriteLine("No document matched the filter. Inserting new document.");
                    await _zoneCollection.InsertOneAsync(zonesData);
                    return Ok("Document not found. Inserted new document.");
                }
                Console.WriteLine("Mise à jour réussie.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
                return StatusCode(500, "Erreur interne du serveur.");
            }

            return Ok("Données des zones reçues avec succès.");
        }
    }


}



/*
    [Route("api/[controller]")]
    [ApiController]
    public class ZonesController : ControllerBase
    {
        private readonly string connectionString = "Server=localhost;Database=alarmsystem;User=root;Password=;";

        // Endpoint pour recevoir les données des zones de la Raspberry Pi
        [HttpPost("receive_zones_data")]
        public IActionResult ReceiveZonesData([FromBody] ZoneData zonesData)
        {
            if (zonesData == null)
            {
                return BadRequest("Invalid data.");
            }

            string zone1 = zonesData.Zone1;
            string zone2 = zonesData.Zone2;
            string zone3 = zonesData.Zone3;
            string zone4 = zonesData.Zone4;

            // Afficher les données des zones
            Console.WriteLine("Données des zones reçues :");
            Console.WriteLine($"Zone1 : {zone1}");
            Console.WriteLine($"Zone2 : {zone2}");
            Console.WriteLine($"Zone3 : {zone3}");
            Console.WriteLine($"Zone4 : {zone4}");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE zones SET Zone1=@Zone1, Zone2=@Zone2, Zone3=@Zone3, Zone4=@Zone4 WHERE id=1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Zone1", zone1);
                        cmd.Parameters.AddWithValue("@Zone2", zone2);
                        cmd.Parameters.AddWithValue("@Zone3", zone3);
                        cmd.Parameters.AddWithValue("@Zone4", zone4);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Mise à jour réussie.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur: {ex.Message}");
                    return StatusCode(500, "Erreur interne du serveur.");
                }
            }

            return Ok("Données des zones reçues avec succès.");
        }
    }
    */