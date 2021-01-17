using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace course_work
{
    class Controller
    {
        Model model = new Model();
        View view = new View();

        public int entity_menu()
        {
            //model.backup();
            while (1 == 1)
            {
                int entity = 0;
                Int32.TryParse(view.entity(), out entity);
                if (entity == 1)
                {
                    game_menu();
                    break;
                }
                else if (entity == 2)
                {
                    player_menu();
                    break;
                }
                else if (entity == 3)
                {
                    rating_menu();
                    break;
                }
                else if (entity == 4)
                {
                    game_rating_menu();
                    break;
                }
                else if (entity == 5)
                {
                    game_find_menu();
                    break;
                }
                else if (entity == 6)
                {
                    analysis_game_menu();
                    break;
                }
                else if (entity == 7)
                {
                    search_menu();
                }
                else if (entity==8)
                {
                    return 1;  
                }
                else if (entity==9)
                {
                    int game = 0;
                    Int32.TryParse(view.get_num(), out game);
                    model.game_generation(game);
                }
                else if (entity == 10)
                {
                    model.backup();
                }
                else
                {
                    view.err_wrong_entity();
                }
            }
            return 0;
        }
        private void search_menu()
        {
            while (1 == 1)
            {
                int game = 0;
                Int32.TryParse(view.Game_search(), out game);
                if (game == 1)
                {
                    int id = 0;
                    Int32.TryParse(view.get_game_id(), out id);
                    if (model.game_genre_get_by_id(id) == null)
                    {
                        view.err_wrong_ID("Game search option ");
                    }
                    else
                    {
                        Console.WriteLine(model.game_genre_get_by_id(id));
                    }
                }
                else if (game == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_game_id(), out id);
                    if (model.game_plat_get_by_id(id) == null)
                    {
                        view.err_wrong_ID("Game search option ");
                    }
                    else
                    {
                        Console.WriteLine(model.game_plat_get_by_id(id));
                    }
                }
                else if (game == 3)
                {
                    int id = 0;
                    Int32.TryParse(view.get_game_id(), out id);
                    if (model.game_pub_get_by_id(id) == null)
                    {
                        view.err_wrong_ID("Game search option ");
                    }
                    else
                    {
                        Console.WriteLine(model.game_pub_get_by_id(id));
                    }
                }
                else if (game == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_game_id(), out id);
                    if (model.game_dev_get_by_id(id) == null)
                    {
                        view.err_wrong_ID("Game search option ");
                    }
                    else
                    {
                        Console.WriteLine(model.game_dev_get_by_id(id));
                    }
                }
                else if (game == 5)
                {
                    return;
                }
                else
                {
                    view.err_wrong_option();
                }
            }
        }
        private void analysis_game_menu()
        {
            while (1 == 1)
            {
                int game = 0;
                Int32.TryParse(view.game_analysis(), out game);
                if (game == 1)
                {
                    model.dev_export_csv();
                    var proc = Process.Start(@"cmd.exe ", @"/c D:\DB\course_work\developer\developer.html");
                }
                else if (game == 2)
                {
                    model.games_export_csv();
                    var proc = Process.Start(@"cmd.exe ", @"/c D:\DB\course_work\genre\genre.html");
                }
                else if (game == 3)
                {
                    break;
                }
                else
                {
                    view.error_option();
                }
            }
        }
        private void game_find_menu()
        {
            while (1 == 1)
            {
                int op = 0;
                Int32.TryParse(view.game_find(), out op);
                if (op == 1)
                {
                    string genre = view.Game_get_Genre();
                    while (genre.Length == 0)
                    {
                        view.error_empty_string();
                        genre = view.Game_get_Genre();
                    }
                    List<Game> games = model.game_find_genre(genre);
                    if (games.Count == 0)
                    {
                        view.error_empty_list();
                    }
                    else
                    {
                        view.print_games(games);
                    }
                }
                else if (op == 2)
                {
                    string dev = view.Game_get_developer();
                    while (dev.Length == 0)
                    {
                        view.error_empty_string();
                        dev = view.Game_get_developer();
                    }
                    List<Game> games = model.game_find_dev(dev);
                    if (games.Count == 0)
                    {
                        view.error_empty_list();
                    }
                    else
                    {
                        view.print_games(games);
                    }
                }
                else if (op == 3)
                {
                    int year = Int32.Parse(view.Game_get_release());
                    while (year < 0)
                    {
                        Console.WriteLine("Wrong year");
                        year = Int32.Parse(view.Game_get_release());
                    }
                    List<Game> games = model.game_find_year(year);
                    if (games.Count == 0)
                    {
                        view.error_empty_list();
                    }
                    else
                    {
                        view.print_games(games);
                    }
                }
                else if (op == 4)
                {
                    double rating = Double.Parse(view.Game_get_rating_user());
                    while (rating < 0 || rating > 10)
                    {
                        Console.WriteLine("Rating should be 0<=x<=10");
                        rating = Double.Parse(view.Game_get_rating_user());
                    }
                    string games = model.game_find_rating_u(rating);
                    if (games.Length == 0)
                    {
                        view.error_empty_list();
                    }
                    else
                    {
                        view.print_game_rating(games);
                    }
                }
                else if (op == 5)
                {
                    double rating = Double.Parse(view.Game_get_rating_critic());
                    while (rating < 0 || rating > 100)
                    {
                        Console.WriteLine("Rating should be 0<=x<=10");
                        rating = Double.Parse(view.Game_get_rating_critic());
                    }
                    string games = model.game_find_rating_ñ(rating);
                    if (games.Length == 0)
                    {
                        view.error_empty_list();
                    }
                    else
                    {
                        view.print_game_rating(games);
                    }
                }
                else if (op == 6)
                {
                    return;
                }
                else
                {
                    view.err_wrong_option();
                }
            }
        }
      
        #region game
        private void game_menu()
        {
            while (1 == 1)
            {
                int char_ = 0;
                Int32.TryParse(view.Game(), out char_);
                if (char_ == 1)
                {
                    List<Game> chars_ = model.Game_print();
                    if (chars_.Count == 0)
                    {
                        view.err_empty_table("Games");
                    }
                    else
                    {
                        view.print_games(chars_);
                    }
                }

                else if (char_ == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    Game char_1 = model.Game_get_by_id(id);
                    if (char_1 == null)
                    {
                        view.err_wrong_ID("Game ");
                    }
                    else
                    {
                        view.print_game(char_1);
                    }
                }
                else if (char_ == 3)
                {
                    Game m = new Game();
                    m.Name = view.game_get_name();
                    while (m.Name.Length == 0)
                    {
                        view.err_empty("Game name ");
                        m.Name = view.game_get_name();
                    }
                    m.Platform = view.Game_get_platform();
                    while (m.Name.Length == 0)
                    {
                        view.err_empty("Game platform ");
                        m.Name = view.Game_get_platform();
                    }
                    m.ReleaseYear = Int32.Parse(view.Game_get_release());
                    while (m.ReleaseYear == 0)
                    {
                        view.err_wrong_ID("Game release year ");
                        m.ReleaseYear = Int32.Parse(view.Game_get_release());
                    }
                    m.Genre = view.Game_get_Genre();
                    while (m.Genre.Length == 0)
                    {
                        view.err_empty("Game genre ");
                        m.Genre = view.Game_get_Genre();
                    }
                    m.Publisher = view.Game_get_publisher();
                    while (m.Publisher.Length == 0)
                    {
                        view.err_empty("Game publisher ");
                        m.Publisher = view.Game_get_publisher();
                    }
                    m.Developer = view.Game_get_developer();
                    while (m.Developer.Length == 0)
                    {
                        view.err_empty("Game developer ");
                        m.Developer = view.Game_get_developer();
                    }
                    m.AccessRating = view.Game_get_access();
                    while (m.AccessRating.Length == 0)
                    {
                        view.err_empty("Game access rating ");
                        m.AccessRating = view.Game_get_access();
                    }
                    int new_id = model.Game_add(m);
                    view.successfull_operation("Game", new_id, "added");
                }
                else if (char_ == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    bool del = model.Game_delete(id);
                    if (del == false)
                    {
                        view.err_wrong_ID("Game ");
                    }
                    else
                    {
                        view.successfull_operation("Game", id, "deleted");
                    }
                }
                else if (char_ == 5)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.Game_get_by_id(id) == null)
                    {
                        view.err_wrong_ID("Game ");
                    }
                    else
                    {
                        Game m = new Game();
                        m.Name = view.game_get_name();
                        while (m.Name.Length == 0)
                        {
                            view.err_empty("Game name ");
                            m.Name = view.game_get_name();
                        }
                        m.Platform = view.Game_get_platform();
                        while (m.Name.Length == 0)
                        {
                            view.err_empty("Game platform ");
                            m.Name = view.Game_get_platform();
                        }
                        m.ReleaseYear = Int32.Parse(view.Game_get_release());
                        while (m.ReleaseYear == 0)
                        {
                            view.err_wrong_ID("Game release year ");
                            m.ReleaseYear = Int32.Parse(view.Game_get_release());
                        }
                        m.Genre = view.Game_get_Genre();
                        while (m.Genre.Length == 0)
                        {
                            view.err_empty("Game genre ");
                            m.Genre = view.Game_get_Genre();
                        }
                        m.Publisher = view.Game_get_publisher();
                        while (m.Publisher.Length == 0)
                        {
                            view.err_empty("Game publisher ");
                            m.Publisher = view.Game_get_publisher();
                        }
                        m.Developer = view.Game_get_developer();
                        while (m.Developer.Length == 0)
                        {
                            view.err_empty("Game developer ");
                            m.Developer = view.Game_get_developer();
                        }
                        m.AccessRating = view.Game_get_access();
                        while (m.AccessRating.Length == 0)
                        {
                            view.err_empty("Game access rating ");
                            m.AccessRating = view.Game_get_access();
                        }
                        model.Game_edit(m);
                        view.successfull_operation("Game", id, "edited ");
                    }
                }
                else if (char_ == 6)
                {
                    break;
                }
                else
                {
                    view.err_wrong_option();
                }
            }
        }
        #endregion
        #region player
        private void player_menu()
        {
            while (1 == 1)
            {
                int Player = 0;
                Int32.TryParse(view.Player(), out Player);
                if (Player == 1)
                {
                    List<Player> Players = model.player_print();
                    if (Players.Count == 0)
                    {
                        view.err_empty_table("Player");
                    }
                    else
                    {
                        view.print_players(Players);
                    }
                }
                else if (Player == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    Player Players = model.Player_get_by_id(id);
                    if (Players == null)
                    {
                        view.err_wrong_ID("Player");
                    }
                    else
                    {
                        view.print_player(Players);
                    }
                }
                else if (Player == 3)
                {
                    Player d = new Player();
                    d.Na = Double.Parse(view.player_get_NA());
                    while (d.Na < 0 || d.Na > 100)
                    {
                        Console.WriteLine("Wrong rating 0<=x<=100");
                        d.Na = Double.Parse(view.player_get_NA()); ;
                    }
                    d.Eu = Double.Parse(view.player_get_EU());
                    while (d.Eu < 0 || d.Eu > 100)
                    {
                        Console.WriteLine("Wrong rating 0<=x<=100");
                        d.Eu = Double.Parse(view.player_get_EU()); ;
                    }
                    d.Jp = Double.Parse(view.player_get_NA());
                    while (d.Jp < 0 || d.Jp > 100)
                    {
                        Console.WriteLine("Wrong rating 0<=x<=100");
                        d.Jp = Double.Parse(view.player_get_JP()); ;
                    }
                    d.Other = Double.Parse(view.player_get_other());
                    while (d.Other < 0 || d.Other > 100)
                    {
                        Console.WriteLine("Wrong rating 0<=x<=100");
                        d.Other = Double.Parse(view.player_get_other()); ;
                    }
                    d.Global = d.Na + d.Eu + d.Jp + d.Other;
                    int new_id = model.Player_add(d);
                    view.successfull_operation("Player", new_id, "added");
                }
                else if (Player == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    bool del = model.Player_delete(id);
                    if (del == false)
                    {
                        view.err_wrong_ID("Player");
                    }
                    else
                    {
                        view.successfull_operation("Player", id, "deleted");
                    }
                }
                else if (Player == 5)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.Player_get_by_id(id) == null)
                    {
                        view.err_wrong_ID("Player");
                    }
                    else
                    {
                        Player d = new Player();
                        d.Na = Double.Parse(view.player_get_NA());
                        while (d.Na < 0 || d.Na > 100)
                        {
                            Console.WriteLine("Wrong rating 0<=x<=100");
                            d.Na = Double.Parse(view.player_get_NA()); ;
                        }
                        d.Eu = Double.Parse(view.player_get_EU());
                        while (d.Eu < 0 || d.Eu > 100)
                        {
                            Console.WriteLine("Wrong rating 0<=x<=100");
                            d.Eu = Double.Parse(view.player_get_EU()); ;
                        }
                        d.Jp = Double.Parse(view.player_get_NA());
                        while (d.Jp < 0 || d.Jp > 100)
                        {
                            Console.WriteLine("Wrong rating 0<=x<=100");
                            d.Jp = Double.Parse(view.player_get_JP()); ;
                        }
                        d.Other = Double.Parse(view.player_get_other());
                        while (d.Other < 0 || d.Other > 100)
                        {
                            Console.WriteLine("Wrong rating 0<=x<=100");
                            d.Other = Double.Parse(view.player_get_other()); ;
                        }
                        d.Global = d.Na + d.Eu + d.Jp + d.Other;
                        model.Player_edit(d);
                        view.successfull_operation("Player", id, "edited");
                    }
                }
                else if (Player == 6)
                {
                    break;
                }
                else
                {
                    view.err_wrong_option();

                }
            }
        }
        #endregion
        #region rating
        private void rating_menu()
        {
            while (1 == 1)
            {
                int rating = 0;
                Int32.TryParse(view.rating(), out rating);
                if (rating == 1)
                {
                    List<Rating> ratings = model.rating_print();
                    if (ratings.Count == 0)
                    {
                        view.err_empty_table("ratings");
                    }
                    else
                    {
                        view.print_ratings(ratings);
                    }
                }
                else if (rating == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    Rating ratings = model.Rating_get_by_id(id);
                    if (ratings == null)
                    {
                        view.err_wrong_ID("rating");
                    }
                    else
                    {
                        view.print_rating(ratings);
                    }
                }
                else if (rating == 3)
                {
                    Rating a = new Rating();
                    a.User = Double.Parse(view.rating_get_User());
                    while (a.User < 0 || a.User > 10)
                    {
                        Console.WriteLine("User rating must be in 0<=x<=10");
                        a.User = Double.Parse(view.rating_get_User());
                    }
                    a.Critic = Double.Parse(view.rating_get_User());
                    while (a.Critic < 0 || a.Critic > 100)
                    {
                        Console.WriteLine("Critic rating must be in 0<=x<=100");
                        a.User = Double.Parse(view.rating_get_User());
                    }
                    int new_id = model.Rating_add(a);
                    view.successfull_operation("rating", new_id, "added");
                }
                else if (rating == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    bool del = model.Rating_delete(id);
                    if (del == false)
                    {
                        view.err_wrong_ID("rating");
                    }
                    else
                    {

                        view.successfull_operation("rating", id, "deleted");
                    }
                }
                else if (rating == 5)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.Rating_get_by_id(id) == null)
                    {
                        view.err_wrong_ID("rating");
                    }
                    else
                    {
                        Rating a = new Rating();
                        a.User = double.Parse(view.rating_get_User());
                        while (a.User < 0 || a.User > 10)
                        {
                            Console.WriteLine("User rating must be in 0<=x<=10");
                            a.User = double.Parse(view.rating_get_User());
                        }
                        a.Critic = double.Parse(view.rating_get_User());
                        while (a.Critic < 0 || a.Critic > 100)
                        {
                            Console.WriteLine("Critic rating must be in 0<=x<=100");
                            a.User = double.Parse(view.rating_get_User());
                        }
                        model.Rating_edit(a);
                        view.successfull_operation("rating", id, "edited");
                    }
                }
                else if (rating == 6)
                {
                    break;
                }
                else
                {
                    view.err_wrong_option();
                }
            }
        }
        #endregion
        #region game_rating
        private void game_rating_menu()
        {
            while (1 == 1)
            {
                int char_rating_ = 0;
                Int32.TryParse(view.game_rating(), out char_rating_);
                if (char_rating_ == 1)
                {
                    string movies_ratings = model.game_Rating_print();
                    if (movies_ratings.Length == 0)
                    {
                        view.err_empty_table("Games - ratings");
                    }
                    else
                    {
                        view.print_game_ratings(movies_ratings);
                    }
                }
                else if (char_rating_ == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    string gr = model.game_Rating_get_by_id(id);
                    if (gr.Length == 0)
                    {
                        view.err_wrong_ID("Game - rating");
                    }
                    else
                    {
                        view.print_game_rating(gr);
                    }
                }
                else if (char_rating_ == 3)
                {
                    int game_id = 0;
                    Int32.TryParse(view.get_game_id(), out game_id);
                    while (model.Game_get_by_id(game_id) == null)
                    {
                        view.err_wrong_ID("Game");
                        Int32.TryParse(view.get_game_id(), out game_id);
                    }
                    int rating_id = 0;
                    Int32.TryParse(view.get_rating_id(), out rating_id);
                    while (model.Rating_get_by_id(rating_id) == null)
                    {
                        view.err_wrong_ID("Rating");
                        Int32.TryParse(view.get_rating_id(), out rating_id);
                    }
                    GameRating char_rating__ = new GameRating();
                    char_rating__.GameId = game_id;
                    char_rating__.RatingId = rating_id;
                    model.game_Rating_add(char_rating__);
                    view.successfull_connection();
                }

                else if (char_rating_ == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    bool del = model.game_Rating_delete(id);
                    if (del == false)
                    {
                        view.err_wrong_ID("Games - ratings");
                    }
                    else
                    {

                        view.successfull_operation("Game - rating", id, "deleted");
                    }
                }

                else if (char_rating_ == 5)
                {
                    break;
                }
                else
                {
                    view.err_wrong_option();
                }
            }
        }
        #endregion
    }
}
