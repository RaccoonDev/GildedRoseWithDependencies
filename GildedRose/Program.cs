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
                int n;
                using (var c = new SqlCommand("select top 1 dates from runs order by dates desc", conn))
                {
                    var dbDate = c.ExecuteScalar();
                    if (dbDate == null) n = 1;
                    else n = (DateTime.Now - (DateTime)dbDate).Days;
                }

                var items = new List<Item>();

                using (var c2 = new SqlCommand("select * from store", conn))
                {
                    using (var r = c2.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            items.Add(new Item
                            {
                                Name = r["name"].ToString(),
                                Quality = (int) r["quality"],
                                SellIn = (int) r["sellIn"]
                            });
                        }
                    }
                }

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
