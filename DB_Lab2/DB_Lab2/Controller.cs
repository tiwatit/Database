using System;
using lab2.MVC;
namespace lab2.MVC
{
    class Controller
    {
        Model model = new Model();
        View view = new View();

        public int entity_menu()
        {
            while (1 == 1)
            {
                int entity = 0;
                Int32.TryParse(view.entity(), out entity);
                if (entity == 1)
                {
                    character_menu();
                    break;
                }
                else if (entity == 2)
                {
                    item_menu();
                    break;
                }
                else if (entity == 3)
                {
                    account_menu();
                    break;
                }
                else if (entity == 4)
                {
                    Character_Items_menu();
                    break;
                }
                else if (entity == 5)
                {
                    search_menu();
                    break;
                }
                else if (entity == 6)
                {
                    return 1;
                }
                else
                {
                    view.err_wrong_entity();
                }
            }
            return 0;
        }
        #region Character
        private void character_menu()
        {
            while (1 == 1)
            {
                int character = 0;
                Int32.TryParse(view.Character(), out character);
                if (character == 1)
                {
                    string characters = model.character_print();
                    if (characters.Length == 0)
                    {
                        view.err_empty_table("Characters");
                    }
                    else
                    {
                        view.print(characters);
                    }
                }
                else if (character == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    string characters = model.character_get_by_id(id);
                    if (characters.Length == 0)
                    {
                        view.err_wrong_ID("Character ");
                    }
                    else
                    {
                        view.print(characters);
                    }
                }
                else if (character == 3)
                {
                    string name = view.chracter_get_name();
                    while (name.Length == 0)
                    {
                        view.err_empty("Character name");
                        name = view.chracter_get_name();
                    }
                    int Level = Convert.ToInt32(view.char_get_level());
                    int hp = Convert.ToInt32(view.char_get_hp());
                    int new_id = model.character_add(name, Level, hp);
                    view.successfull_operation("Character", new_id, "added");
                }
                else if (character == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.character_get_by_id(id).Length == 0)
                    {
                        view.err_wrong_ID("Character ");
                    }
                    else
                    {
                        model.character_delete(id);
                        view.successfull_operation("Character", id, "deleted");
                    }
                }
                else if (character == 5)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.character_get_by_id(id).Length == 0)
                    {
                        view.err_wrong_ID("Character ");
                    }
                    else
                    {
                        string name = view.chracter_get_name();
                        while (name.Length == 0)
                        {
                            view.err_empty("Character name");
                            name = view.chracter_get_name();
                        }
                        int Level = Convert.ToInt32(view.char_get_level());
                        int hp = Convert.ToInt32(view.char_get_hp());
                        model.character_edit(name, Level, hp, id);
                        view.successfull_operation("Character", id, "edited");
                    }
                }
                else if (character == 6)
                {
                    int num = 0;
                    while (!Int32.TryParse(view.get_num(), out num) || num <= 0 || num > 100000)
                    {
                        view.err_generation();
                    }
                    model.character_generation(num);
                    view.successfull_generation("Character", num);
                }
                else if (character == 7)
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
        #region Item
        private void item_menu()
        {
            while (1 == 1)
            {
                int item = 0;
                Int32.TryParse(view.item(), out item);
                if (item == 1)
                {
                    string directors = model.items_print();
                    if (directors.Length == 0)
                    {
                        view.err_empty_table("Item");
                    }
                    else
                    {
                        view.print(directors);
                    }
                }
                else if (item == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    string directors = model.item_get_by_id(id);
                    if (directors.Length == 0)
                    {
                        view.err_wrong_ID("Item");
                    }
                    else
                    {
                        view.print(directors);
                    }
                }
                else if (item == 3)
                {
                    string name = view.Item_get_name();
                    while (name.Length == 0)
                    {
                        view.err_empty("Item name");
                        name = view.Item_get_name();
                    }
                    int ATK = Convert.ToInt32(view.char_get_ATK());
                    int new_id = model.item_add(name, ATK);
                    view.successfull_operation("Item", new_id, "added");
                }
                else if (item == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.item_get_by_id(id).Length == 0)
                    {
                        view.err_wrong_ID("Item");
                    }
                    else
                    {
                        model.item_delete(id);
                        view.successfull_operation("Item", id, "deleted");
                    }
                }
                else if (item == 5)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.item_get_by_id(id).Length == 0)
                    {
                        view.err_wrong_ID("Item");
                    }
                    else
                    {
                        string name = view.Item_get_name();
                        while (name.Length == 0)
                        {
                            view.err_empty("Item name");
                            name = view.Item_get_name();
                        }
                        int ATK = Convert.ToInt32(view.char_get_ATK());
                        model.item_edit(name, ATK, id);
                        view.successfull_operation("Item", id, "edited");
                    }
                }
                else if (item == 6)
                {
                    int num = 0;
                    while (!Int32.TryParse(view.get_num(), out num) || num <= 0 || num > 100000)
                    {
                        view.err_generation();
                    }
                    model.Item_generation(num);
                    view.successfull_generation("items", num);
                }
                else if (item == 7)
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

        #region account
        private void account_menu()
        {
            while (1 == 1)
            {
                int acc = 0;
                Int32.TryParse(view.account(), out acc);
                if (acc == 1)
                {
                    string accounts = model.account_print();
                    if (accounts.Length == 0)
                    {
                        view.err_empty_table("Accounts");
                    }
                    else
                    {
                        view.print(accounts);
                    }
                }
                else if (acc == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    string accounts = model.account_get_by_id(id);
                    if (accounts.Length == 0)
                    {
                        view.err_wrong_ID("Account");
                    }
                    else
                    {
                        view.print(accounts);
                    }
                }
                else if (acc == 3)
                {
                    string name = view.acc_get_name();
                    while (name.Length == 0)
                    {
                        view.err_empty("Award category");
                        name = view.acc_get_name();
                    }
                    string pass = view.acc_get_pass();
                    while (pass.Length==0)
                    {
                        view.err_number("Account password");
                        pass = view.acc_get_pass();
                    }
                    int new_id = model.account_add(name, pass);
                    view.successfull_operation("Account", new_id, "added");
                }
                else if (acc == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.account_get_by_id(id).Length == 0)
                    {
                        view.err_wrong_ID("Account");
                    }
                    else
                    {
                        model.account_delete(id);
                        view.successfull_operation("Account", id, "deleted");
                    }
                }
                else if (acc == 5)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.item_get_by_id(id).Length == 0)
                    {
                        view.err_wrong_ID("Account");
                    }
                    else
                    {
                        string name = view.acc_get_name();
                        while (name.Length == 0)
                        {
                            view.err_empty("Account name");
                            name = view.acc_get_name();
                        }
                        string pass = view.acc_get_pass();
                        while (pass.Length==0)
                        {
                            view.err_number("Account password");
                            pass = view.acc_get_pass();
                        }
                        model.account_edit(name, pass, id);
                        view.successfull_operation("Account", id, "edited");
                    }
                }
                else if (acc == 6)
                {
                    int num = 0;
                    while (!Int32.TryParse(view.get_num(), out num) || num <= 0 || num > 100000)
                    {
                        view.err_generation();
                    }
                    model.acc_generation(num);
                    view.successfull_generation("Accounts", num);
                }
                else if (acc == 7)
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
        #region Characters-Items
        private void Character_Items_menu()
        {
            while (1 == 1)
            {
                int ci = 0;
                Int32.TryParse(view.char_it(), out ci);
                if (ci == 1)
                {
                    string characters_items = model.acc_item_print();
                    if (characters_items.Length == 0)
                    {
                        view.err_empty_table("Characters - Items");
                    }
                    else
                    {
                        view.print(characters_items);
                    }
                }
                else if (ci == 2)
                {
                    int char_id = 0;
                    Int32.TryParse(view.get_char_id(), out char_id);
                    while (model.character_get_by_id(char_id).Length == 0)
                    {
                        view.err_wrong_ID("Character");
                        Int32.TryParse(view.get_char_id(), out char_id);
                    }
                    int item_id = 0;
                    Int32.TryParse(view.get_item_id(), out item_id);
                    while (model.item_get_by_id(item_id).Length == 0)
                    {
                        view.err_wrong_ID("Item");
                        Int32.TryParse(view.get_item_id(), out item_id);
                    }
                    model.character_item_add(char_id, item_id);
                    view.successfull_connection();
                }
                else if (ci == 3)
                {
                    int link = 0;
                    Int32.TryParse(view.get_item_id(), out link);
                    string del = model.character_item_delete(link);
                    if (del == "0")
                    {
                        view.err_connection();
                    }
                    else
                    {
                        view.successfull_connection_delete(link);
                    }
                }
                else if (ci == 4)
                {
                    int num = 0;
                    while (!Int32.TryParse(view.get_num(), out num) || num <= 0 || num > 100000)
                    {
                        view.err_generation();
                    }
                    model.acc_item_generation(num);
                    view.successfull_generation("Connections", num);
                }
                else if (ci == 5)
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

        #region search
        private void search_menu()
        {
            while (1 == 1)
            {
                int search = 0;
                Int32.TryParse(view.search(), out search);
                if (search == 1)
                {
                    int s_lvl = 0;
                    while (!Int32.TryParse(view.search_s_lvl(), out s_lvl))
                    {
                        view.err_number("Input");
                    }
                    int e_lvl = 0;
                    while (!Int32.TryParse(view.search_e_lvl(), out e_lvl))
                    {
                        view.err_number("Input");
                    }
                    int s_id = 0;
                    while (!Int32.TryParse(view.search_s_id(), out s_id))
                    {
                        view.err_number("Input");
                    }
                    int e_id = 0;
                    while (!Int32.TryParse(view.search_e_id(), out e_id))
                    {
                        view.err_number("Input");
                    }
                    int s_ATK = 0;
                    while (!Int32.TryParse(view.search_s_ATK(), out s_ATK))
                    {
                        view.err_number("Input");
                    }
                    int e_ATK = 0;
                    while (!Int32.TryParse(view.search_e_ATK(), out e_ATK))
                    {
                        view.err_number("Input");
                    }
                    string searches = model.search_option_1(s_lvl, e_lvl, s_id, e_id, s_ATK, e_ATK);
                    if (searches.Length == 0)
                    {
                        view.err_empty_table("This");
                    }
                    else
                    {
                        view.print(searches);
                    }
                }
                else if (search == 2)
                {
                    int s_lvl = 0;
                    while (!Int32.TryParse(view.search_s_lvl(), out s_lvl))
                    {
                        view.err_number("Input");
                    }
                    int e_lvl = 0;
                    while (!Int32.TryParse(view.search_e_lvl(), out e_lvl))
                    {
                        view.err_number("Input");
                    }
                    string c_name = view.search_c_name();
                    while (c_name.Length == 0)
                    {
                        view.err_empty("Substring");
                        c_name = view.search_c_name();
                    }
                    string i_name = view.search_i_name();
                    while (i_name.Length == 0)
                    {
                        view.err_empty("Substring");
                        i_name = view.search_i_name();
                    }
                    string searches = model.search_option_2(c_name, e_lvl, s_lvl, i_name);
                    if (searches.Length == 0)
                    {
                        view.err_empty_table("This");
                    }
                    else
                    {
                        view.print(searches);
                    }
                }
                else if (search == 3)
                {
                    string c_name = view.search_c_name();
                    while (c_name.Length == 0)
                    {
                        view.err_empty("Substring");
                        c_name = view.search_c_name();
                    }
                    string i_name = view.search_i_name();
                    while (i_name.Length == 0)
                    {
                        view.err_empty("Substring");
                        i_name = view.search_i_name();
                    }
                    int s_hp = 0;
                    while (!Int32.TryParse(view.search_s_hp(), out s_hp))
                    {
                        view.err_number("Input");
                    }
                    int e_hp = 0;
                    while (!Int32.TryParse(view.search_e_hp(), out e_hp))
                    {
                        view.err_number("Input");
                    }
                    string searches = model.search_option_3(c_name, e_hp, s_hp, i_name);
                    if (searches.Length == 0)
                    {
                        view.err_empty_table("This");
                    }
                    else
                    {
                        view.print(searches);
                    }
                }
                else if (search == 4)
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
