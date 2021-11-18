using System;
using System.Data.SqlClient;

namespace OuweMeuk
{
    class Program
    {

        static void Main(string[] args)
        {
            SqlConnection cn = new SqlConnection(@"Server=.\sqlexpress;Database=ACME;Trusted_Connection=True;");
            cn.Open();

            SqlCommand com = new SqlCommand
            {
                Connection = cn,
                CommandText = "SELECT * FROM dbo.People",
                CommandType = System.Data.CommandType.Text
            };

            //com.Parameters
            SqlDataReader rdr = com.ExecuteReader();
            while(rdr.Read())
            {
                Console.WriteLine($"({rdr["Id"]}  {rdr[2]} {rdr[1]}");
            }

            
            Console.WriteLine(cn.State);
            cn.Close();

            Console.WriteLine("Done");
        }
    }
}
