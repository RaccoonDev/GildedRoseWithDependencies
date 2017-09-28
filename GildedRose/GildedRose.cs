using System.Collections.Generic;
using System.Data.SqlClient;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        public SqlConnection Connection;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                            using (var command = new SqlCommand("update store set quality = @quality where name = @name", Connection))
                            {
                                command.Parameters.AddWithValue("quality", Items[i].Quality);
                                command.Parameters.AddWithValue("name", Items[i].Name);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                        using (var command = new SqlCommand("update store set quality = @quality where name = @name", Connection))
                        {
                            command.Parameters.AddWithValue("quality", Items[i].Quality);
                            command.Parameters.AddWithValue("name", Items[i].Name);

                            command.ExecuteNonQuery();
                        }

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                    using (var command = new SqlCommand("update store set quality = @quality where name = @name", Connection))
                                    {
                                        command.Parameters.AddWithValue("quality", Items[i].Quality);
                                        command.Parameters.AddWithValue("name", Items[i].Name);

                                        command.ExecuteNonQuery();
                                    }
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                    using (var command = new SqlCommand("update store set quality = @quality where name = @name", Connection))
                                    {
                                        command.Parameters.AddWithValue("quality", Items[i].Quality);
                                        command.Parameters.AddWithValue("name", Items[i].Name);

                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                    using (var command = new SqlCommand("update store set sellIn = @sellIn where name = @name", Connection))
                    {
                        command.Parameters.AddWithValue("sellIn", Items[i].SellIn);
                        command.Parameters.AddWithValue("name", Items[i].Name);

                        command.ExecuteNonQuery();
                    }
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                    using (var command = new SqlCommand("update store set quality = @quality where name = @name", Connection))
                                    {
                                        command.Parameters.AddWithValue("quality", Items[i].Quality);
                                        command.Parameters.AddWithValue("name", Items[i].Name);

                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                            using (var command = new SqlCommand("update store set quality = @quality where name = @name", Connection))
                            {
                                command.Parameters.AddWithValue("quality", Items[i].Quality);
                                command.Parameters.AddWithValue("name", Items[i].Name);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                            using (var command = new SqlCommand("update store set quality = @quality where name = @name", Connection))
                            {
                                command.Parameters.AddWithValue("quality", Items[i].Quality);
                                command.Parameters.AddWithValue("name", Items[i].Name);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
    }
}