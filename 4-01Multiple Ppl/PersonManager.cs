using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace _4_01Multiple_Ppl
{
    public class PersonManager
    {
        private String _connString;

        public PersonManager(string conn)
        {
            _connString = conn;
        }

        public List<Person> GetPeople()
        {
            List<Person> ppl = new List<Person>();
            using (SqlConnection conn = new SqlConection(_connString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM People";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ppl.Add(
                        new Person()
                        {
                            PersonId = (int)reader["PersonId"],
                            First = (string)reader["FirstName"],
                            Last = (string)reader["LastName"],
                            Age = (int)reader["Age"]
                        });
               }
            }
           return ppl;
        }

        public void AddPerson(Person p)
        {
            using(SqlConnection conn = new SqlConnection(_connString))
            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO People
                                  SELECT @first, @last,@age";
                cmd.Parameters.AddWithValue("first", p.First);
                cmd.Parameters.AddWithValue("last", p.Last);
                cmd.Parameters.AddWithValue("age", p.Age);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
