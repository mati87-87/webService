using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WebAPI.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Person
        public IEnumerable<string> Get()
        {
            return new string[] { "Person1", "Person2" };
        }

        // GET: api/Person/5
        public string Get(int id)
        {
            string odpowiedz = String.Concat("MOja Odpowiedz", id*10);
            string cnString = ConfigurationManager.ConnectionStrings["MatiDB"].ConnectionString;
            MySql.Data.MySqlClient.MySqlConnection dbConn = new MySql.Data.MySqlClient.MySqlConnection(cnString);

            MySqlCommand cmd = dbConn.CreateCommand();
            cmd.CommandText = String.Concat("select * from example.Orders where ID=", id);
            string flag1 = "brak danych";
            try
            {
                dbConn.Open();
            }
            catch (Exception erro)
            {
                flag1 = erro.Message;
                return "blad polaczenia";
            }

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string ID = reader["Id"].ToString();
                string OrderDate = reader["OrderDate"].ToString();
                string OrderNumber = reader["OrderNumber"].ToString();
                string CustomerId = reader["CustomerId"].ToString();
                string totalAmount = reader["totalAmount"].ToString();
                flag1 = ID + " " + OrderDate + " " + OrderNumber + " " + CustomerId + " " + totalAmount + " ";
            }
            return flag1.ToString();
            //return odpowiedz;
        }

        // POST: api/Person
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
