using System;
using System.Collections.Generic;

namespace DB_3
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
                    char_menu();
                    break;
                }
                else if (entity == 2)
                {
                    item_menu();
                    break;
                }
                else if (entity == 3)
                {
                    acc_menu();
                    break;
                }
                else if (entity == 4)
                {
                    char_item_menu();
                    break;
                }
              /*  else if (entity == 5)
                {
                    hash_menu();
                    break;
                }
                else if (entity == 6)
                {
                    brin_menu();
                    break;
                }*/
                else if (entity == 7)
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

        #region char
        private void char_menu()
        {
            while (1 == 1)
            {
                int char_ = 0;
                Int32.TryParse(view.Character(), out char_);
                if (char_ == 1)
                {
                    List<Character> chars_ = model.character_print();
                    if (chars_.Count == 0)
                    {
                        view.err_empty_table("Characters");
                    }
                    else
                    {
                        view.print_chars(chars_);
                    }
                }

                else if (char_ == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    Character char_1 = model.character_get_by_id(id);
                    if (char_1 == null)
                    {
                        view.err_wrong_ID("Character ");
                    }
                    else
                    {
                        view.print_char(char_1);
                    }
                }
                else if (char_ == 3)
                {
                    Character m = new Character();
                    m.CharacterName = view.char_get_name();
                    while (m.CharacterName.Length == 0)
                    {
                        view.err_empty("Character name");
                        m.CharacterName = view.char_get_name();
                    }
                    m.Hp = int.Parse(view.char_get_hp());
                    while (m.Hp == 0)
                    {
                        view.err_empty("Character hp");
                        m.Hp = int.Parse(view.char_get_hp());
                    }
                    m.Level = int.Parse(view.char_get_level());
                    while (m.Level == 0)
                    {
                        view.err_empty("Character level");
                        m.Hp = int.Parse(view.char_get_level());
                    }
                    int acc_id = 0;
                    string s_acc_id = view.char_get_accid();
                    Int32.TryParse(s_acc_id, out acc_id);
                    while (model.account_get_by_id(acc_id) == null)
                    {
                        view.err_wrong_ID("Account ");
                        s_acc_id = view.char_get_accid();
                        Int32.TryParse(s_acc_id, out acc_id);
                    }
                    m.AccId = acc_id;
                    int new_id = model.character_add(m);
                    view.successfull_operation("Character", new_id, "added");
                }
                else if (char_ == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    bool del = model.character_delete(id);
                    if (del == false)
                    {
                        view.err_wrong_ID("Character ");
                    }
                    else
                    {
                        view.successfull_operation("Character", id, "deleted");
                    }
                }
                else if (char_ == 5)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.character_get_by_id(id) == null)
                    {
                        view.err_wrong_ID("Character ");
                    }
                    else
                    {
                        Character m = new Character();
                        m.CharacterName = view.char_get_name();
                        while (m.CharacterName.Length == 0)
                        {
                            view.err_empty("Character name");
                            m.CharacterName = view.char_get_name();
                        }
                        m.Hp = int.Parse(view.char_get_hp());
                        while (m.Hp == 0)
                        {
                            view.err_empty("Character HP");
                            m.Hp = int.Parse(view.char_get_hp());
                        }
                        m.Level = int.Parse(view.char_get_level());
                        while (m.Level == 0)
                        {
                            view.err_empty("Character level");
                            m.Level = int.Parse(view.char_get_level());
                        }
                        int acc_id = 0;
                        string s_acc_id = view.char_get_accid();
                        Int32.TryParse(s_acc_id, out acc_id);
                        while (model.account_get_by_id(acc_id) == null)
                        {
                            view.err_wrong_ID("Account ");
                            s_acc_id = view.char_get_accid();
                            Int32.TryParse(s_acc_id, out acc_id);
                        }
                        m.AccId = acc_id;
                        model.character_edit(m);
                        view.successfull_operation("Character", id, "edited");
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
        #region acc
        private void acc_menu()
        {
            while (1 == 1)
            {
                int account = 0;
                Int32.TryParse(view.Account(), out account);
                if (account == 1)
                {
                    List<Account> accounts = model.account_print();
                    if (accounts.Count == 0)
                    {
                        view.err_empty_table("account");
                    }
                    else
                    {
                        view.print_Accounts(accounts);
                    }
                }
                else if (account == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    Account accounts = model.account_get_by_id(id);
                    if (accounts == null)
                    {
                        view.err_wrong_ID("account");
                    }
                    else
                    {
                        view.print_Account(accounts);
                    }
                }
                else if (account == 3)
                {
                    Account d = new Account();
                    d.Name = view.acc_get_name();
                    while (d.Name.Length == 0)
                    {
                        view.err_empty("account name");
                        d.Name = view.acc_get_name();
                    }
                    d.Pword = view.acc_get_pass();
                    while (d.Pword.Length == 0)
                    {
                        view.err_empty("account country");
                        d.Pword = view.acc_get_pass();
                    }
                    int new_id = model.account_add(d);
                    view.successfull_operation("account", new_id, "added");
                }
                else if (account == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    bool del = model.account_delete(id);
                    if (del == false)
                    {
                        view.err_wrong_ID("account");
                    }
                    else
                    {
                        view.successfull_operation("account", id, "deleted");
                    }
                }
                else if (account == 5)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.account_get_by_id(id) == null)
                    {
                        view.err_wrong_ID("account");
                    }
                    else
                    {
                        Account d = new Account();
                        d.Name = view.acc_get_name();
                        while (d.Name.Length == 0)
                        {
                            view.err_empty("account name");
                            d.Name = view.acc_get_name();
                        }
                        d.Pword = view.acc_get_pass();
                        while (d.Pword.Length == 0)
                        {
                            view.err_empty("account country");
                            d.Pword = view.acc_get_pass();
                        }
                        model.account_edit(d);
                        view.successfull_operation("account", id, "edited");
                    }
                }
                else if (account == 6)
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
        #region item
        private void item_menu()
        {
            while (1 == 1)
            {
                int item = 0;
                Int32.TryParse(view.item(), out item);
                if (item == 1)
                {
                    List<Item> items = model.items_print();
                    if (items.Count == 0)
                    {
                        view.err_empty_table("items");
                    }
                    else
                    {
                        view.print_items(items);
                    }
                }
                else if (item == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    Item items = model.item_get_by_id(id);
                    if (items == null)
                    {
                        view.err_wrong_ID("item");
                    }
                    else
                    {
                        view.print_item(items);
                    }
                }
                else if (item == 3)
                {
                    Item a = new Item();
                    a.Name = view.Item_get_name();
                    while (a.Name.Length == 0)
                    {
                        view.err_empty("item category");
                        a.Name = view.Item_get_name();
                    }
                    int ATK = 0;
                    string at = view.Item_get_ATK();
                    while (!Int32.TryParse(at, out ATK))
                    {
                        view.err_number("item year");
                        at = view.Item_get_ATK();
                    }
                    a.Atk = ATK;
                    int new_id = model.item_add(a);
                    view.successfull_operation("item", new_id, "added");
                }
                else if (item == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    bool del = model.item_delete(id);
                    if (del == false)
                    {
                        view.err_wrong_ID("item");
                    }
                    else
                    {

                        view.successfull_operation("item", id, "deleted");
                    }
                }
                else if (item == 5)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    if (model.item_get_by_id(id) == null)
                    {
                        view.err_wrong_ID("item");
                    }
                    else
                    {
                        Item a = new Item();
                        a.Name = view.Item_get_name();
                        while (a.Name.Length == 0)
                        {
                            view.err_empty("item category");
                            a.Name = view.Item_get_name();
                        }
                        int ATK = 0;
                        string at = view.Item_get_ATK();
                        while (!Int32.TryParse(at, out ATK))
                        {
                            view.err_number("item year");
                            at = view.Item_get_ATK();
                        }
                        a.Atk = ATK;
                        model.item_edit(a);
                        view.successfull_operation("item", id, "edited");
                    }
                }
                else if (item == 6)
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

        #region char_item
        private void char_item_menu()
        {
            while (1 == 1)
            {
                int char_item_ = 0;
                Int32.TryParse(view.char_it(), out char_item_);
                if (char_item_ == 1)
                {
                    string movies_items = model.char_item_print();
                    if (movies_items.Length == 0)
                    {
                        view.err_empty_table("Characters - items");
                    }
                    else
                    {
                        view.print_char_items(movies_items);
                    }
                }
                else if (char_item_ == 2)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    string nominations = model.char_item_get_by_id(id);
                    if (nominations.Length == 0)
                    {
                        view.err_wrong_ID("Nomination");
                    }
                    else
                    {
                        view.print_char_item(nominations);
                    }
                }
                else if (char_item_ == 3)
                {
                    int char_id = 0;
                    Int32.TryParse(view.get_char_id(), out char_id);
                    while (model.character_get_by_id(char_id) == null)
                    {
                        view.err_wrong_ID("Character");
                        Int32.TryParse(view.get_char_id(), out char_id);
                    }
                    int item_id = 0;
                    Int32.TryParse(view.get_item_id(), out item_id);
                    while (model.item_get_by_id(item_id) == null)
                    {
                        view.err_wrong_ID("item");
                        Int32.TryParse(view.get_item_id(), out item_id);
                    }
                    CharactersItem char_item__ = new CharactersItem();
                    char_item__.CharId = char_id;
                    char_item__.CharId = item_id;
                    model.character_item_add(char_item__);
                    view.successfull_connection();
                }

                else if (char_item_ == 4)
                {
                    int id = 0;
                    Int32.TryParse(view.get_id(), out id);
                    bool del = model.character_item_delete(id);
                    if (del == false)
                    {
                        view.err_wrong_ID("Characters - items");
                    }
                    else
                    {

                        view.successfull_operation("Characters - items", id, "deleted");
                    }
                }

                else if (char_item_ == 5)
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
