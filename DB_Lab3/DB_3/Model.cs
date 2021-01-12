using System;
using System.Diagnostics;
using Npgsql;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace DB_3
{
    class Model
    {
        private NpgsqlConnection db= new NpgsqlConnection("Host = localhost; Username = postgres; Password = 1111; Database = postgres");
        public Model()
        {
            if (db == null)
            {
                NpgsqlConnection db = new NpgsqlConnection("Host = localhost; Username = postgres; Password = 1111; Database = postgres");

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
        public List<Character> character_print()
        {
            using (postgresContext db = new postgresContext())
            {
                var characters = db.Characters.ToList();
                return characters;
            }
        }

        public Character character_get_by_id(int id)
        {
            using (postgresContext db = new postgresContext())
            {
                var character = db.Characters.Find(id);
                return character;
            }
        }
         public int character_add(Character char_)
         {
            using (postgresContext db = new postgresContext())
            {
                db.Characters.Add(char_);
                db.SaveChanges();
                var m = db.Characters.Max(m => m.Id);
                return m;
            }
         }
         public bool character_delete(int char_id)
         {
            using (postgresContext db = new postgresContext())
            {
                var chara = character_get_by_id(char_id);
                if (chara == null)
                {
                    return false;
                }
                db.Characters.Remove(chara);
                db.SaveChanges();
                return true;
            }
        }
        public void character_edit(Character char_)
        {
            using (postgresContext db = new postgresContext())
            {
                var m = character_get_by_id(char_.Id);
                m = char_;
                db.SaveChanges();
            }
        }
           public void character_generation(int num)
            {
            using var cmd = new NpgsqlCommand("INSERT INTO \"Characters\" (\"Character_name\", \"HP\", \"Level\", \"acc_id\") SELECT chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) , trunc(random() * 500 + 20), trunc(random() * 500 + 20), trunc(random() * 500 + 20) FROM generate_series(1, @num)", db);
            cmd.Parameters.AddWithValue("@num", num);
            cmd.ExecuteNonQuery();
            }
        #endregion
        
            #region Items
        public List<Item> items_print()
        {
            using (postgresContext db = new postgresContext())
            {
                var items = db.Items.ToList();
                return items;
            }
        }
        public Item item_get_by_id(int item_id)
        {
            using (postgresContext db = new postgresContext())
            {
                var item = db.Items.FirstOrDefault(a => a.Id == item_id);
                return item;
            }
        }
        public int item_add(Item item)
        {
            using (postgresContext db = new postgresContext())
            {
                db.Items.Add(item);
                db.SaveChanges();
                var a = db.Accounts.Max(a => a.Id);
                return a;
            }
        }
        public bool item_delete(int i_id)
        {
            using (postgresContext db = new postgresContext())
            {
                var item = item_get_by_id(i_id);
                if (item == null)
                {
                    return false;
                }
                db.Items.Remove(item);
                db.SaveChanges();
                return true;
            }
        }
        public void item_edit(Item item)
        {
            using (postgresContext db = new postgresContext())
            {
                var a = item_get_by_id(item.Id);
                a = item;
                db.SaveChanges();
            }
        }
             public void Item_generation(int num)
             {
                 using var cmd = new NpgsqlCommand("INSERT INTO \"Items\" (\"name\", \"ATK\") SELECT chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int), trunc(random() * 500 + 20) FROM generate_series(1, @num)", db);
                 cmd.Parameters.AddWithValue("@num", num);
                 cmd.ExecuteNonQuery();
             }
             #endregion

             #region accounts
        public List<Account> account_print()
        {
            using (postgresContext db = new postgresContext())
            {
                var directors = db.Accounts.ToList();
                return directors;
            }
        }
        public Account account_get_by_id(int acc_id)
        {
            using (postgresContext db = new postgresContext())
            {
                var account = db.Accounts.FirstOrDefault(d => d.Id == acc_id);
                return account;
            }
        }
        public int account_add(Account acc)
        {
            using (postgresContext db = new postgresContext())
            {
                db.Accounts.Add(acc);
                db.SaveChanges();
                var d = db.Accounts.Max(d => d.Id);
                return d;
            }
        }
        public bool account_delete(int acc_id)
        {
            using (postgresContext db = new postgresContext())
            {
                var director = account_get_by_id(acc_id);
                if (director == null)
                {
                    return false;
                }
                db.Accounts.Remove(director);
                db.SaveChanges();
                return true;
            }
        }
        public void account_edit(Account acc)
        {
            using (postgresContext db = new postgresContext())
            {
                var d = account_get_by_id(acc.Id);
                d = acc;
                db.SaveChanges();
            }
        }
             public void acc_generation(int num)
             {
                 using var cmd = new NpgsqlCommand("INSERT INTO \"accounts\" (\"name\", \"pword\") SELECT chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int), chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int)  FROM generate_series(1, @num)", db);
                 cmd.Parameters.AddWithValue("@num", num);
                 cmd.ExecuteNonQuery();
             }
             #endregion
        #region Characters_items
        public string char_item_print()
        {
            using (postgresContext db = new postgresContext())
            {
                var ret = db.CharactersItems.Include(m => m.Char).Include(a => a.Link).ToList();
                string char_items = "";
                foreach (var r in ret)
                {
                    char_items += r.LinkId.ToString();
                    char_items += ". ";
                    char_items += r.CharId.ToString();
                    char_items += ". Name: ";
                    char_items += r.Char.CharacterName;
                    char_items += " <-----> ";
                    char_items += r.ItemId.ToString();
                    char_items += ". Category: ";
                    char_items += r.Link.Name;
                    char_items += '\n';
                }
                return char_items;
            }
        }
        public string char_item_get_by_id(int l_id)
        {
            using (postgresContext db = new postgresContext())
            {
                var ret = db.CharactersItems.Include(m => m.Char).Include(a => a.Link).FirstOrDefault(n => n.LinkId == l_id);
                string char_items = "";
                if(ret!=null)
                {
                    char_items += ret.LinkId.ToString();
                    char_items += ". ";
                    char_items += ret.CharId.ToString();
                    char_items += ". Name: ";
                    char_items += ret.Char.CharacterName;
                    char_items += " <-----> ";
                    char_items += ret.ItemId.ToString();
                    char_items += ". Category: ";
                    char_items += ret.Link.Name;
                    char_items += '\n';
                }
                return char_items;
            }
        }
        public void character_item_add(CharactersItem char_item)
        {
            using (postgresContext db = new postgresContext())
            {
                db.CharactersItems.Add(char_item);
                db.SaveChanges();
            }
        }
        public bool character_item_delete(int l_id)
        {
            using (postgresContext db = new postgresContext())
            {
                var nom = db.CharactersItems.FirstOrDefault(n => n.LinkId == l_id);
                if (nom == null)
                {
                    return false;
                }
                db.CharactersItems.Remove(nom);
                db.SaveChanges();
                return true;
            }
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
