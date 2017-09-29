using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GildedRose
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var conn = new SqlConnection(args[0]))
            {
                conn.Open();
                List<Item> items = new List<Item>();
                var n = new CheckDb(items, conn).Check();

                var gsStore = new GildedRose(items);
                gsStore.Connection = conn;

                for (int i = 0; i < n; i++)
                {
                    gsStore.UpdateQuality();
                }

                using (var c3 = new SqlCommand("insert into runs values (@date)", conn))
                {
                    c3.Parameters.AddWithValue("date", DateTime.Now);
                    c3.ExecuteNonQuery();
                }
            }
        }
    }
}
