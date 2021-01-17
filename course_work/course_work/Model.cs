using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using System.Text.Json;
namespace course_work
{
    class Model
    {
        private NpgsqlConnection db= new NpgsqlConnection("Host = localhost; Username = postgres; Password = 1111; Database = Course_work");
        public Model()
        {
            if (db == null)
            {
                NpgsqlConnection db = new NpgsqlConnection("Host = localhost; Username = postgres; Password = 1111; Database = Course_work");

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

        #region Players
        public List<Player> player_print()
        {
            using (Course_workContext db = new Course_workContext())
            {
                var Players = db.Players.ToList();
                return Players;
            }
        }

        public Player Player_get_by_id(int id)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var Player = db.Players.Find(id);
                return Player;
            }
        }
         public int Player_add(Player char_)
         {
            using (Course_workContext db = new Course_workContext())
            {
                db.Players.Add(char_);
                db.SaveChanges();
                var m = db.Players.Max(m => m.Id);
                return m;
            }
         }
         public bool Player_delete(int char_id)
         {
            using (Course_workContext db = new Course_workContext())
            {
                var chara = Player_get_by_id(char_id);
                if (chara == null)
                {
                    return false;
                }
                db.Players.Remove(chara);
                db.SaveChanges();
                return true;
            }
        }
        public void Player_edit(Player char_)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var m = Player_get_by_id(char_.Id);
                m = char_;
                db.SaveChanges();
            }
        }
        public void Player_generation(int num)
        {
            using var cmd = new NpgsqlCommand("INSERT INTO \"Players\" (\"Player_name\", \"HP\", \"Level\", \"acc_id\") SELECT chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) , trunc(random() * 500 + 20), trunc(random() * 500 + 20), trunc(random() * 500 + 20) FROM generate_series(1, @num)", db);
            cmd.Parameters.AddWithValue("@num", num);
            cmd.ExecuteNonQuery();
        }
        public List<Player> player_find_na(double na)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Players.Where(m => m.Na == na).ToList();
                return ret;
            }
        }
        public List<Player> player_find_eu(double eu)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Players.Where(m => m.Eu == eu).ToList();
                return ret;
            }
        }
        public List<Player> player_find_jp(double jp)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Players.Where(m => m.Jp == jp).ToList();
                return ret;
            }
        }
        public List<Player> player_find_other(double ot)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Players.Where(m => m.Other == ot).ToList();
                return ret;
            }
        }
        public List<Player> player_find_glob(double glob)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Players.Where(m => m.Global == glob).ToList();
                return ret;
            }
        }
        #endregion

        #region Ratings
        public List<Rating> rating_print()
        {
            using (Course_workContext db = new Course_workContext())
            {
                var Ratings = db.Ratings.ToList();
                return Ratings;
            }
        }
        public Rating Rating_get_by_id(int Rating_id)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var Rating = db.Ratings.FirstOrDefault(a => a.Id == Rating_id);
                return Rating;
            }
        }
        public int Rating_add(Rating Rating)
        {
            using (Course_workContext db = new Course_workContext())
            {
                db.Ratings.Add(Rating);
                db.SaveChanges();
                var a = db.Ratings.Max(a => a.Id);
                return a;
            }
        }
        public bool Rating_delete(int i_id)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var Rating = Rating_get_by_id(i_id);
                if (Rating == null)
                {
                    return false;
                }
                db.Ratings.Remove(Rating);
                db.SaveChanges();
                return true;
            }
        }
        public void Rating_edit(Rating Rating)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var a = Rating_get_by_id(Rating.Id);
                a = Rating;
                db.SaveChanges();
            }
        }
             public void Rating_generation(int num)
             {
                 using var cmd = new NpgsqlCommand("INSERT INTO \"Ratings\" (\"name\", \"ATK\") SELECT chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int), trunc(random() * 500 + 20) FROM generate_series(1, @num)", db);
                 cmd.Parameters.AddWithValue("@num", num);
                 cmd.ExecuteNonQuery();
             }
             #endregion

             #region Games
        public List<Game> Game_print()
        {
            using (Course_workContext db = new Course_workContext())
            {
                var directors = db.Games.ToList();
                return directors;
            }
        }
        public Game Game_get_by_id(int acc_id)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var Game = db.Games.FirstOrDefault(d => d.Id == acc_id);
                return Game;
            }
        }
        public int Game_add(Game acc)
        {
            using (Course_workContext db = new Course_workContext())
            {
                db.Games.Add(acc);
                db.SaveChanges();
                var d = db.Games.Max(d => d.Id);
                return d;
            }
        }
        public bool Game_delete(int acc_id)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var director = Game_get_by_id(acc_id);
                if (director == null)
                {
                    return false;
                }
                db.Games.Remove(director);
                db.SaveChanges();
                return true;
            }
        }
        public void Game_edit(Game acc)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var d = Game_get_by_id(acc.Id);
                d = acc;
                db.SaveChanges();
            }
        }
        public void acc_generation(int num)
        {
                 using var cmd = new NpgsqlCommand("INSERT INTO \"Games\" (\"name\", \"pword\") SELECT chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int), chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int) || chr(trunc(97 + random()*25)::int)  FROM generate_series(1, @num)", db);
                 cmd.Parameters.AddWithValue("@num", num);
                 cmd.ExecuteNonQuery();
        }
        public List<Game> game_find_genre(string genre)
        {
            using (Course_workContext db = new Course_workContext())
            {
                char symb = '%';
                genre = symb + genre + symb;
                var ret = db.Games.Where(m => EF.Functions.Like(m.Genre, genre)).ToList();
                return ret;
            }
        }
        public List<Game> game_find_dev(string dev)
        {
            using (Course_workContext db = new Course_workContext())
            {
                char symb = '%';
                dev = symb + dev + symb;
                var ret = db.Games.Where(m => EF.Functions.Like(m.Developer, dev)).ToList();
                return ret;
            }
        }
        public List<Game> game_find_year(int year)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Games.Where(m => m.ReleaseYear == year).ToList();
                return ret;
            }
        }
        public string game_find_rating_u(double rating)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.GameRatings.Include(m => m.Game).Include(b=>b.Rating).Where(a => a.Rating.User==rating).ToList();
                string char_Ratings = "";
                foreach (var r in ret)
                {
                    char_Ratings += r.Id.ToString();
                    char_Ratings += ". ";
                    char_Ratings += r.GameId.ToString();
                    char_Ratings += ". Name: ";
                    char_Ratings += r.Game.Name;
                    char_Ratings += " <-----> ";
                    char_Ratings += r.RatingId.ToString();
                    char_Ratings += ". User rating: ";
                    char_Ratings += r.Rating.User;
                    char_Ratings += ". Critic rating: ";
                    char_Ratings += r.Rating.Critic;
                    char_Ratings += '\n';
                }
                return char_Ratings;
            }
        }
        public string game_find_rating_ñ(double rating)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.GameRatings.Include(m => m.Game).Include(b => b.Rating).Where(a => a.Rating.Critic == rating).ToList();
                string char_Ratings = "";
                foreach (var r in ret)
                {
                    char_Ratings += r.Id.ToString();
                    char_Ratings += ". ";
                    char_Ratings += r.GameId.ToString();
                    char_Ratings += ". Name: ";
                    char_Ratings += r.Game.Name;
                    char_Ratings += " <-----> ";
                    char_Ratings += r.RatingId.ToString();
                    char_Ratings += ". User rating: ";
                    char_Ratings += r.Rating.User;
                    char_Ratings += ". Critic rating: ";
                    char_Ratings += r.Rating.Critic;
                    char_Ratings += '\n';
                }
                return char_Ratings;
            }
        }
        public List<Game> game_sort_genre(string genre,int num)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Games.OrderBy(m => m.Genre==genre).Take(num).ToList();
                return ret;
            }
        }
        public List<Game> game_sort_dev(string dev, int num)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Games.OrderBy(m => m.Developer == dev).Take(num).ToList();
                return ret;
            }
        }
        public List<Game> game_sort_year(int year, int num)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Games.OrderBy(m => m.ReleaseYear == year).Take(num).ToList();
                return ret;
            }
        }
        public string game_sort_rating(string genre, int num)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.GameRatings.Include(m => m.Game).Include(a => a.Rating).OrderByDescending(r=> r.Rating.User).ToList();
                string movie = "";
                if (ret == null)
                {
                    return movie;
                }
                foreach (var r in ret)
                {
                    movie += "Rating: ";
                    movie += r.Rating.User.ToString();
                    movie += " Name: ";
                    movie += r.Game.Name;
                    movie += "\n";
                }
                return movie;
            }
        }
        #endregion
        #region Game_Ratings
        public string game_Rating_print()
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.GameRatings.Include(m => m.Game).Include(a => a.Rating).ToList();
                string char_Ratings = "";
                foreach (var r in ret)
                {
                    char_Ratings += r.Id.ToString();
                    char_Ratings += ". ";
                    char_Ratings += r.GameId.ToString();
                    char_Ratings += ". Name: ";
                    char_Ratings += r.Game.Name;
                    char_Ratings += " <-----> ";
                    char_Ratings += r.RatingId.ToString();
                    char_Ratings += ". User rating: ";
                    char_Ratings += r.Rating.User;
                    char_Ratings += ". Critic rating: ";
                    char_Ratings += r.Rating.Critic;
                    char_Ratings += '\n';
                }
                return char_Ratings;
            }
        }
        public string game_Rating_get_by_id(int l_id)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.GameRatings.Include(m => m.Game).Include(a => a.Rating).FirstOrDefault(n => n.Id == l_id);
                string char_Ratings = "";
                if(ret!=null)
                {
                    char_Ratings += ret.Id.ToString();
                    char_Ratings += ". ";
                    char_Ratings += ret.GameId.ToString();
                    char_Ratings += ". Name: ";
                    char_Ratings += ret.Game.Name;
                    char_Ratings += " <-----> ";
                    char_Ratings += ret.RatingId.ToString();
                    char_Ratings += ". User rating: ";
                    char_Ratings += ret.Rating.User;
                    char_Ratings += ". Critic rating: ";
                    char_Ratings += ret.Rating.Critic;
                    char_Ratings += '\n';
                }
                return char_Ratings;
            }
        }
        public void game_Rating_add(GameRating char_Rating)
        {
            using (Course_workContext db = new Course_workContext())
            {
                db.GameRatings.Add(char_Rating);
                db.SaveChanges();
            }
        }
        public bool game_Rating_delete(int l_id)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var nom = db.GameRatings.FirstOrDefault(n => n.Id == l_id);
                if (nom == null)
                {
                    return false;
                }
                db.GameRatings.Remove(nom);
                db.SaveChanges();
                return true;
            }
        }
        #endregion
        public void backup()
        {
            string sProcess = @"C:\windows\system32\cmd.exe";
            string command = "C:/\"Program Files\"/PostgreSQL/12/bin/pg_dump.exe --file D:/DB/coursework.sql  --host localhost --port 5432 --username postgres --password --dbname asd --verbose D:\\DB\\coursework.sql\n";
            string cmd = String.Format(" /k {0}{1}{2} x86", "\"", command, "\"");
            Process.Start(sProcess, cmd);
        }
        public void restore()
        {
            string sProcess = @"C:\windows\system32\cmd.exe";
            string command = "C:/\"Program Files\"/PostgreSQL/12/bin/pg_restore.exe -d coursework -U postgres -c D:/DB/coursework.sql";
            string cmd = String.Format(" /k {0}{1}{2} x86", "\"", command, "\"");
            Process.Start(sProcess, cmd);
        }
        public void game_generation(int num)
        {
            using var cmd = new NpgsqlCommand("INSERT INTO \"games\" (\"name\", \"platform\", \"release_year\" ,\"genre\", \"publisher\",\"developer\",\"access_rating\") SELECT chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) , chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) , trunc(random() * 500 + 20),chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) ,chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) ,chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int) ,chr(trunc(65 + random()*25)::int) || chr(trunc(97 + random()*25)::int)  FROM generate_series(1, @num)", db);
            cmd.Parameters.AddWithValue("@num", num);
            cmd.ExecuteNonQuery();
        }
        #region search
        public string game_genre_get_by_id(int l_id)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Games.FirstOrDefault(n => n.Id == l_id);
                string char_Ratings = "";
                if (ret != null)
                {
                    char_Ratings += ret.Id.ToString();
                    char_Ratings += ". Name: ";
                    char_Ratings += ret.Name;
                    char_Ratings += ". <-----> Genre: ";
                    char_Ratings += ret.Genre;
                    char_Ratings += '\n';
                }
                return char_Ratings;
            }
        }
        public string game_dev_get_by_id(int l_id)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Games.FirstOrDefault(n => n.Id == l_id);
                string char_Ratings = "";
                if (ret != null)
                {
                    char_Ratings += ret.Id.ToString();
                    char_Ratings += ". Name: ";
                    char_Ratings += ret.Name;
                    char_Ratings += ". <-----> Developer: ";
                    char_Ratings += ret.Developer;
                    char_Ratings += '\n';
                }
                return char_Ratings;
            }
        }
        public string game_pub_get_by_id(int l_id)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Games.FirstOrDefault(n => n.Id == l_id);
                string char_Ratings = "";
                if (ret != null)
                {
                    char_Ratings += ret.Id.ToString();
                    char_Ratings += ". Name: ";
                    char_Ratings += ret.Name;
                    char_Ratings += ". <-----> Publisher: ";
                    char_Ratings += ret.Publisher;
                    char_Ratings += '\n';
                }
                return char_Ratings;
            }
        }
        public string game_plat_get_by_id(int l_id)
        {
            using (Course_workContext db = new Course_workContext())
            {
                var ret = db.Games.FirstOrDefault(n => n.Id == l_id);
                string char_Ratings = "";
                if (ret != null)
                {
                    char_Ratings += ret.Id.ToString();
                    char_Ratings += ". Name: ";
                    char_Ratings += ret.Name;
                    char_Ratings += ". <-----> Platform: ";
                    char_Ratings += ret.Platform;
                    char_Ratings += '\n';
                }
                return char_Ratings;
            }
        }
        #endregion
        #region export
        public void games_export_csv()
        {
            using (Course_workContext db = new Course_workContext())
            {
                List<Game> games = db.Games.ToList();
                Collection a = new Collection();
                foreach (Game b in games)
                {
                    collection_element c = new collection_element(b.Genre);
                    a.add(c);
                }
                for (int i = 0; i < a.genres.Count() - 1; i++)
                {
                    for (int j = 0; j < a.genres.Count() - 1; j++)
                    {
                        if (a.genres[j].k < a.genres[i].k)
                        {
                            collection_element c = new collection_element(a.genres[i].key);
                            int d = a.genres[i].k;
                            a.genres[i] = a.genres[j];
                            a.genres[j] = c;
                            a.genres[j].k = d;
                        }
                    }
                }
                var sw = new StreamWriter("D:\\DB\\course_work\\genre\\genre.csv", false);
                for (int i = 0; i < 5; i++)
                {
                    var first = a.genres[i].key;
                    var second = a.genres[i].k;
                    var line = string.Format("{0},{1}", first, second);
                    sw.WriteLine(line);
                    sw.Flush();
                }
            }
        }
        public void dev_export_csv()
        {
            using (Course_workContext db = new Course_workContext())
            {
                List<Game> games = db.Games.ToList();
                Collection a = new Collection();
                foreach (Game b in games)
                {
                    collection_element c = new collection_element(b.Developer);
                    a.add(c);
                }
                for (int i=0;i<a.genres.Count()-1;i++)
                {
                    for (int j = 0; j < a.genres.Count() - 1; j++)
                    {
                        if (a.genres[j].k<a.genres[i].k)
                        {
                            collection_element c = new collection_element(a.genres[i].key);
                            int d = a.genres[i].k;
                            a.genres[i] = a.genres[j];
                            a.genres[j] = c;
                            a.genres[j].k = d;
                        }
                    }
                }
                var sw = new StreamWriter("D:\\DB\\course_work\\developer\\developer.csv", false);
                for (int i = 0; i < 10; i++)
                {
                    var first = a.genres[i].key;
                    var second = a.genres[i].k;
                    var line = string.Format("{0},{1}", first, second);
                    sw.WriteLine(line);
                    sw.Flush();
                }
            }
        }
    }
    class collection_element
    {
        public int k;
        public string key;
        public collection_element(string genre)
        {
            this.key = genre;
            this.k++;
        }
    }
    class Collection
    {
        public List<collection_element> genres;

        public Collection()
        {
            genres = new List<collection_element>();
        }
        public void add(collection_element musecol)
        {
            foreach (collection_element m in genres)
            {
                if (musecol.key == m.key)
                {
                    m.k++;
                    return;
                }
            }
            genres.Add(musecol);
        }
        public void print()
        {
            foreach (collection_element m in genres)
            {
                Console.WriteLine(m.key + "  :  " + m.k + "\n ");
            }
        }
    }
    #endregion

}
