using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GildedRose
{
    class CheckDb
    {
        private List<Item> _items;
        private SqlConnection _conn;

        public CheckDb(List<Item> items, SqlConnection conn)
        {
            _items = items;
            _conn = conn;
        }

        public int Check()
        {
            int n;
            using (var c = new SqlCommand("select top 1 dates from runs order by dates desc", _conn))
            {
                var dbDate = c.ExecuteScalar();
                if (dbDate == null) n = 1;
                else n = (DateTime.Now - (DateTime) dbDate).Days;
            }

            using (var c2 = new SqlCommand("select * from store", _conn))
            {
                using (var r = c2.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _items.Add(new Item
                        {
                            Name = r["name"].ToString(),
                            Quality = (int) r["quality"],
                            SellIn = (int) r["sellIn"]
                        });
                    }
                }
            }
            return n;
        }
    }
}