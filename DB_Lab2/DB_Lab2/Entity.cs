using System;
using System.Diagnostics;
using Npgsql;

namespace lab2.MVC
{
    class Model
    {
        private NpgsqlConnection db= new NpgsqlConnection("Host = localhost; Username = postgres; Password = babak6832; Database = postgres");
        public Model()
        {
            if (db == null)
            {
                NpgsqlConnection db = new NpgsqlConnection("Host = localhost; Username = postgres; Password = babak6832; Database = postgres");

                db.Open();

                using var cmd = new NpgsqlCommand("SELECT version()", db);

                var version = cmd.ExecuteScalar().ToString();
                Console.WriteLine($"PostgreSQL version: {version}");
            }
            else
            {
                db.Open();

                using var cmd = new NpgsqlCommand("SELECT version()", db);

                var version = cmd.ExecuteScalar().ToString();
                Console.WriteLine($"PostgreSQL version: {version}");
            }
        }

        #region Characters
        public string character_print()
        {
            using var cmd = new NpgsqlCommand("SELECT * from \"Characters\" ORDER BY \"id\"", db);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            string characters = "";
            while (rdr.Read())
            {
                characters += ". id: ";
                characters += rdr.GetInt32(0);
                if (characters.Length == 0)
                {
                    break;
                }
                characters += "   Character_name: ";
                characters += rdr.GetString(1);
                characters += "   HP: ";
                characters += rdr.GetInt32(2);
                characters += "   Level: ";
                characters += rdr.GetInt32(3);
                characters += "\n";
            }
            return characters;
        }

        public string character_get_by_id(int id)
        {
            using var cmd = new NpgsqlCommand("SELECT * FROM \"Characters\" WHERE \"id\"=" + id+"", db);
            using NpgsqlDataReader rdr = cmd.ExecuteReader();
            string characters = "";
            while (rdr.Read())
            {
                characters += ". id: ";
                characters += rdr.GetInt32(0);
                if (characters.Length == 0)
                {
                    break;
                }
                characters += "   Character_name: ";
                characters += rdr.GetString(1);
                characters += "   HP: ";
                characters += rdr.GetInt32(2);
                characters += "   Level: ";
                characters += rdr.GetInt32(3);
                characters += "\n";
            }
            return characters;
        }
         public int character_add(string c_name, int c_HP, int c_Level)
             {
             
            using var cmd = new NpgsqlCommand("INSERT INTO \"Characters\"(\"Character_name\", \"HP\", \"Level\") VALUES(@name, @HP, @Level)", db);
            cmd.Parameters.AddWithValue("name", c_name);
            cmd.Parameters.AddWithValue("HP", c_HP);
            cmd.Parameters.AddWithValue("Level", c_Level);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            using var cmd2 = new NpgsqlCommand("SELECT \"id\" FROM \"Characters\" WHERE id = (SELECT MAX(\"id\") from \"Characters\")", db);
            using NpgsqlDataReader rdr = cmd2.ExecuteReader();
            int new_id = 0;
            while (rdr.Read())
            {
                new_id = rdr.GetInt32(0);
            }
            return new_id;
        }
           public void character_delete(int c_id)
           {
               using var cmd2 = new NpgsqlCommand("DELETE from \"Characters\" WHERE \"id\"= " + c_id, db);
               cmd2.ExecuteNonQuery();
               using var cmd = new NpgsqlCommand("DELETE from \"Characters\" WHERE \"id\" = " + c_id, db);
               cmd.ExecuteNonQuery();
           }
        public void character_edit(string c_name, int c_HP, int c_lvl, int c_id)
        {
            using var cmd = new NpgsqlCommand("UPDATE \"Characters\" SET \"Character_name\" = @c_name, \"HP\"= @c_HP, \"Level\"= @c_lvl WHERE \"id\" = " + c_id, db);
            cmd.Parameters.AddWithValue("@c_name", c_name);
            cmd.Parameters.AddWithValue("@c_HP", c_HP);
            cmd.Parameters.AddWithValue("@c_lvl", c_lvl);
            cmd.ExecuteNonQuery();
        }


           public void character_generation(int num)
            {
            using var cmd = new NpgsqlCommand("INSERT INTO \"Characters\" (\"Character_name\", \"HP\", \"Level\") SELECT chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) , trunc(random() * 500 + 20), trunc(random() * 500 + 20) FROM generate_series(1, @num)", db);
            cmd.Parameters.AddWithValue("@num", num);
            cmd.ExecuteNonQuery();
            }
        #endregion
        
            #region Items
             public string items_print()
             {
                 using var cmd = new NpgsqlCommand("SELECT * from \"Items\" ORDER BY id ", db);
                 using NpgsqlDataReader rdr = cmd.ExecuteReader();
                 string items = "";
                 while (rdr.Read())
                 {
                     items += ". id: "; 
                     items += rdr.GetInt32(0);
                     if (items.Length == 0)
                    {
                       break;
                    }
                     items += ". Name: ";
                     items += rdr.GetString(1);
                     items += "   ATK: ";
                     items += rdr.GetInt32(2);
                     items += "\n";
                 }
                 return items;
             }
             public string item_get_by_id(int dir_id)
             {
                 using var cmd = new NpgsqlCommand("SELECT * FROM \"Items\" WHERE \"id\"=" + dir_id, db);
                 using NpgsqlDataReader rdr = cmd.ExecuteReader();
                string items = "";
                 while (rdr.Read())
             {
                items += ". id: ";
                items += rdr.GetInt32(0);
                if (items.Length == 0)
                {
                    break;
                }
                items += ". Name: ";
                items += rdr.GetString(1);
                items += "   ATK: ";
                items += rdr.GetInt32(2);
                items += "\n";
             }
            return items;
             }
             public int item_add(string i_name, int i_ATK)
             {
                 using var cmd = new NpgsqlCommand("INSERT INTO \"Items\"(\"name\", \"ATK\") VALUES(@name, @ATK)", db);
                 cmd.Parameters.AddWithValue("name", i_name);
                 cmd.Parameters.AddWithValue("ATK", i_ATK);
                 cmd.Prepare();
                 cmd.ExecuteNonQuery();
            using var cmd2 = new NpgsqlCommand("SELECT \"id\" FROM \"Items\" WHERE id = (SELECT MAX(id) from \"Items\")", db);
            using NpgsqlDataReader rdr = cmd2.ExecuteReader();
            int new_id = 0;
            while (rdr.Read())
            {
                new_id = rdr.GetInt32(0);
            }
            return new_id;
            }
             public void item_delete(int i_id)
             {
                using var cmd2 = new NpgsqlCommand("DELETE from \"Items\" WHERE \"id\"= " + i_id, db);
                cmd2.ExecuteNonQuery();
                using var cmd = new NpgsqlCommand("DELETE from \"Items\" WHERE \"id\" = " + i_id, db);
                cmd.ExecuteNonQuery();
            }
             public void item_edit(string i_name, int i_ATK, int item_id)
             {
                 using var cmd = new NpgsqlCommand("UPDATE \"Items\" SET \"name\" = @i_name, \"ATK\" = @i_ATK WHERE \"id\" = " + item_id, db);
                 cmd.Parameters.AddWithValue("@i_name", i_name);
                 cmd.Parameters.AddWithValue("@i_ATK", i_ATK);
                 cmd.ExecuteNonQuery();
             }
             public void Item_generation(int num)
             {
                 using var cmd = new NpgsqlCommand("INSERT INTO \"Items\" (\"name\", \"ATK\") SELECT chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int), trunc(random() * 500 + 20) FROM generate_series(1, @num)", db);
                 cmd.Parameters.AddWithValue("@num", num);
                 cmd.ExecuteNonQuery();
             }
             #endregion

             #region accounts
             public string account_print()
             {
                 using var cmd = new NpgsqlCommand("SELECT * from \"accounts\" ORDER BY id ", db);
                 using NpgsqlDataReader rdr = cmd.ExecuteReader();
                 string accounts = "";
                 while (rdr.Read())
                 {
                     accounts += rdr.GetInt32(0);
                     if (accounts.Length == 0)
                     {
                        break;
                     }
                     accounts += ". Name: ";
                     accounts += rdr.GetString(1);
                     accounts += "   Password: ";
                     accounts += rdr.GetString(2);
                     accounts += "\n";
                 }
            return accounts;
        }
             public string account_get_by_id(int acc_id)
             {
                 using var cmd = new NpgsqlCommand("SELECT * FROM \"accounts\" WHERE \"id\"=" + acc_id, db);
                 using NpgsqlDataReader rdr = cmd.ExecuteReader();
                 string acc = "";
                 while (rdr.Read())
                 {
                     acc += rdr.GetInt32(0);
                     if (acc.Length == 0)
                     {
                         break;
                     }
                     acc += ". Name: ";
                     acc += rdr.GetString(1);
                     acc += "   Password: ";
                     acc += rdr.GetString(2);
                     acc += "\n";
                 }
            return acc;
             }
             public int account_add(string name, string pass)
             {
                 using var cmd = new NpgsqlCommand("INSERT INTO \"accounts\"(\"name\", \"pword\") VALUES(@name, @pass)", db);
                 cmd.Parameters.AddWithValue("name", name);
                 cmd.Parameters.AddWithValue("pass", pass);
                 cmd.Prepare();
                 cmd.ExecuteNonQuery();
            using var cmd2 = new NpgsqlCommand("SELECT id FROM \"accounts\" WHERE id = (SELECT MAX(id) from \"accounts\")", db);
            using NpgsqlDataReader rdr = cmd2.ExecuteReader();
            int new_id = 0;
            while (rdr.Read())
            {
                new_id = rdr.GetInt32(0);
            }
            return new_id;
    }
             public void account_delete(int acc_id)
             {
                 using var cmd2 = new NpgsqlCommand("DELETE from \"accounts\" WHERE \"id\" = " +  acc_id, db);
                 cmd2.ExecuteNonQuery();
                 using var cmd = new NpgsqlCommand("DELETE from \"accounts\" WHERE \"id\" = " + acc_id, db);
                 cmd.ExecuteNonQuery();
             }
             public void account_edit(string a_name, string a_pass, int acc_id)
             {
                 using var cmd = new NpgsqlCommand("UPDATE \"accounts\" SET \"name\" = @a_name, pword = @a_pass WHERE \"id\" = " + acc_id, db);
                 cmd.Parameters.AddWithValue("@a_name", a_name);
                 cmd.Parameters.AddWithValue("@a_pass", a_pass);
                 cmd.ExecuteNonQuery();
             }
             public void acc_generation(int num)
             {
                 using var cmd = new NpgsqlCommand("INSERT INTO \"accounts\" (\"name\", \"pword\") SELECT chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int), chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int)  FROM generate_series(1, @num)", db);
                 cmd.Parameters.AddWithValue("@num", num);
                 cmd.ExecuteNonQuery();
             }
             #endregion
        #region Characters_items
        public string acc_item_print()
             {
                 using var cmd = new NpgsqlCommand("SELECT \"Characters\".\"id\" AS \"char_id\", \"Characters\".\"Character_name\", \"Characters-Items\".\"item_id\", \"Items\".\"name\"  from \"Characters\" join \"Characters-Items\" on (\"Characters\".\"id\" = \"Characters-Items\".\"char_id\") join \"Items\" on (\"Items\".\"id\"=\"Characters-Items\".\"item_id\")", db);
                 using NpgsqlDataReader rdr = cmd.ExecuteReader();
                 string Char_item = "";
                 while (rdr.Read())
                 {
                     Char_item += rdr.GetInt32(0);
                     if (Char_item.Length == 0)
                     {
                    break;
                     }
                    Char_item += ". Character Name: ";
                    Char_item += rdr.GetString(1);
                    Char_item += " <---> ";
                    Char_item += rdr.GetInt32(2);
                    Char_item += ". Item name: ";
                    Char_item += rdr.GetString(3);
                    Char_item += "\n";
                 }
            return Char_item;
        }
        public void character_item_add(int c_id, int i_id)
        {
                 using var cmd = new NpgsqlCommand("INSERT INTO \"Characters-Items\"(\"char_id\", \"item_id\") VALUES((SELECT \"id\" from \"Characters\" where \"id\" = @c_id), (SELECT \"id\" from \"Items\" where \"id\" = @i_id))", db);
                 cmd.Parameters.AddWithValue("c_id", c_id);
                 cmd.Parameters.AddWithValue("i_id", i_id);
                 cmd.Prepare();
                 cmd.ExecuteNonQuery();
        }
        public string character_item_delete(int l_id)
        {
                 using var cmd = new NpgsqlCommand("DELETE from \"Characters-Items\" WHERE \"link_id\"= @l_id ", db);
                 cmd.Parameters.AddWithValue("l_id", l_id);
                 return cmd.ExecuteNonQuery().ToString();

        }
             public void acc_item_generation(int num)
             {
                 using var cmd = new NpgsqlCommand("INSERT INTO \"Characters-Items\" (\"char_id\", \"item_id\") SELECT gen_char_id(), gen_item_id()  FROM generate_series(1, @num)", db);
                 cmd.Parameters.AddWithValue("@num", num);
                 cmd.ExecuteNonQuery();
             }
        #endregion

             #region search
             public string search_option_1(int s_lvl, int e_lvl, int s_id, int e_id, int s_ATK, int e_ATK)
             {
                 using var cmd = new NpgsqlCommand("SELECT \"Characters\".\"id\" AS \"Characters-Items.char_id\", \"Characters\".\"Character_name\", \"Characters\".\"Level\", \"Characters\".\"HP\", \"Characters-Items\".\"item_id\", \"Items\".\"name\", \"Items\".\"ATK\" from \"Characters\" join \"Characters-Items\" on (\"Characters\".\"id\" = \"Characters-Items\".\"char_id\")join \"Items\" on (\"Characters-Items\".\"item_id\" = \"Items\".\"id\") WHERE \"Characters\".\"Level\" BETWEEN @s_lvl AND @e_lvl AND \"Characters\".\"id\" BETWEEN @s_id AND @e_id AND \"Items\".\"ATK\" BETWEEN @s_ATK AND @e_ATK", db);
                 cmd.Parameters.AddWithValue("s_lvl", s_lvl);
                 cmd.Parameters.AddWithValue("e_lvl", e_lvl);
                 cmd.Parameters.AddWithValue("s_id", s_id);
                 cmd.Parameters.AddWithValue("e_id", e_id);
                 cmd.Parameters.AddWithValue("s_ATK", s_ATK);
                 cmd.Parameters.AddWithValue("e_ATK", e_ATK);
                 TimeSpan ts = DateTime.Now.TimeOfDay;
                 var sw = new Stopwatch();
                 sw.Start();
                 using NpgsqlDataReader rdr = cmd.ExecuteReader();
                 string search = "";
                 while (rdr.Read())
                 {
                     search += rdr.GetInt32(0);
                     if (search.Length == 0)
                     {
                    break;
                     }
                     search += ". Character Name: ";
                     search += rdr.GetString(1);
                     search += "   Level:";
                     search += rdr.GetInt32(2);
                     search += "   HP: ";
                     search += rdr.GetInt32(3);
                     search += " <---> ";
                     search += rdr.GetInt32(4);
                     search += ".  Item Name: ";
                     search += rdr.GetString(5);
                     search += "   ATK ";
                     search += rdr.GetInt32(6);
                     search += "\n";
                 }
                 var elapsed = sw.ElapsedMilliseconds;
                 Console.WriteLine($"Query Executed and Results Returned in 0.{elapsed.ToString()}sec");
            return search;
             }
             public string search_option_2(string c_name, int e_lvl, int s_lvl, string i_name)
             {
                 using var cmd = new NpgsqlCommand("SELECT \"Characters\".\"id\" AS \"Characters-Items.char_id\", \"Characters\".\"Character_name\", \"Characters\".\"Level\", \"Characters\".\"HP\", \"Characters-Items\".\"item_id\", \"Items\".\"name\", \"Items\".\"ATK\" from \"Characters\" join \"Characters-Items\" on (\"Characters\".\"id\" = \"Characters-Items\".\"char_id\")join \"Items\" on (\"Characters-Items\".\"item_id\" = \"Items\".\"id\") WHERE \"Characters\".\"Level\" BETWEEN @e_lvl AND @s_lvl AND \"Items\".\"name\" like '%" + i_name + "%' AND \"Characters\".\"Character_name\" like '%"+c_name+"%'", db);
                 cmd.Parameters.AddWithValue("i_name", i_name);
                 cmd.Parameters.AddWithValue("c_name", c_name);
                 cmd.Parameters.AddWithValue("e_lvl", e_lvl);
                 cmd.Parameters.AddWithValue("s_lvl", s_lvl);
                 var sw = new Stopwatch();
                 sw.Start();
                 using NpgsqlDataReader rdr = cmd.ExecuteReader();
                 string search = "";
                 while (rdr.Read())
                 {
                     search += rdr.GetInt32(0);
                     if (search.Length == 0)
                     {
                    break;
                     }
                     search += ". Character Name: ";
                     search += rdr.GetString(1);
                     search += ". Level: ";
                     search += rdr.GetInt32(2);
                     search += ". HP: ";
                     search += rdr.GetInt32(3);
                     search += " ---> ";
                     search += rdr.GetInt32(4);
                     search += ". Item name: ";
                     search += rdr.GetString(5);
                     search += "   ATK:";
                     search += rdr.GetInt32(6);
                search += "\n";
                 }
                 var elapsed = sw.ElapsedMilliseconds;
                 Console.WriteLine($"Query Executed and Results Returned in 0.{elapsed.ToString()}sec");
            return search;
                }
             public string search_option_3(string c_name, int e_hp, int s_hp, string i_name)
             {
                using var cmd = new NpgsqlCommand("SELECT \"Characters\".\"id\" AS \"Characters-Items.char_id\", \"Characters\".\"Character_name\", \"Characters\".\"Level\", \"Characters\".\"HP\", \"Characters-Items\".\"item_id\", \"Items\".\"name\", \"Items\".\"ATK\" from \"Characters\" join \"Characters-Items\" on (\"Characters\".\"id\" = \"Characters-Items\".\"char_id\")join \"Items\" on (\"Characters-Items\".\"item_id\" = \"Items\".\"id\") WHERE \"Characters\".\"Level\" BETWEEN @e_hp AND @s_hp AND \"Items\".\"name\" like '%" + i_name + "%' AND \"Characters\".\"Character_name\" like '%" + c_name + "%'", db);
                cmd.Parameters.AddWithValue("i_name", i_name);
                cmd.Parameters.AddWithValue("c_name", c_name);
                cmd.Parameters.AddWithValue("e_hp", e_hp);
                cmd.Parameters.AddWithValue("s_hp", s_hp);
                var sw = new Stopwatch();
                sw.Start();
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                string search = "";
                while (rdr.Read())
            {
                search += rdr.GetInt32(0);
                if (search.Length == 0)
                {
                    break;
                }
                search += ". Character Name: ";
                search += rdr.GetString(1);
                search += ". Level: ";
                search += rdr.GetInt32(2);
                search += ". HP: ";
                search += rdr.GetInt32(3);
                search += " ---> ";
                search += rdr.GetInt32(4);
                search += ". Item name: ";
                search += rdr.GetString(5);
                search += "   ATK:";
                search += rdr.GetInt32(6);
                search += "\n";
            }
            var elapsed = sw.ElapsedMilliseconds;
            Console.WriteLine($"Query Executed and Results Returned in 0.{elapsed.ToString()}sec");
            return search;
        } 
         #endregion 

    }
}
