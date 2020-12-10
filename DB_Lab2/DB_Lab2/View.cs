using System;
using lab2.MVC;
namespace lab2.MVC
{
    class View
    {
        public string entity()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Menu:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1.Characters\n2.Items\n3.Accounts\n4.Characters - Items\n5.Search operations\n6.Exit");
            return Console.ReadLine();
        }
        #region Character
        public string Character()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Character Menu:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1.Print list of Characters\n2.Print character by ID\n3.Add chracter\n4.Delete character by ID\n5.Edit character by ID\n6.Random Generation of chracters\n7.Choose another entity");
            return Console.ReadLine();
        }
        public string chracter_get_name()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Chracter name:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string char_get_level()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Level:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string char_get_hp()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Character HP:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string char_get_ATK()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Character ATK:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        #endregion
        #region Items
        public string item()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Item Menu:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1.Print list of items\n2.Print item by ID\n3.Add item\n4.Delete item by ID\n5.Edit item by ID\n6.Random Generation of items\n7.Choose another entity");
            return Console.ReadLine();
        }
        public string Item_get_name()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Item name:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        #endregion
        #region Account
        public string account()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Account Menu:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1.Print list of Accounts\n2.Print account by ID\n3.Add ccount\n4.Delete account by ID\n5.Edit account by ID\n6.Random Generation of accounts\n7.Choose another entity");
            string a = Console.ReadLine();
            return a;
        }
        public string acc_get_name()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Account Name:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }

        public string acc_get_pass()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Account password:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        #endregion
        #region Characters-Items
        public string char_it()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Characters-items Menu:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1.Print connections\n2.Add connection\n3.Delete connection\n4.Random Generation of connections\n5.Choose another entity");
            string a = Console.ReadLine();
            return a;
        }
        public string get_char_id()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input ID of a Character:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string get_item_id()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input ID of an Item:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        #endregion
        #region search
        public string search()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Search Operations:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1.Search for the character with limited id,ATK and Level\n2.Search for the character with limited lvl and similia char/weapon name\n3.Search for the character with limited HP and similiar char/weapon name\n4.Go to entities menu");
            string a = Console.ReadLine();
            return a;
        }
        public string search_s_lvl()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input lower border of the lvl:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string search_e_lvl()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input upper border of the lvl:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string search_s_id()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input lower border of the ID interval:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string search_e_id()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input uper border of the ID interval:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string search_s_ATK()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input lower border of the ATK interval:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string search_e_ATK()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input upper border of the ATK interval:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string search_c_name()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input substring from characters`s name:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string search_i_name()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input substring from item`s name:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string search_s_hp()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input lower border of the HP interval:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string search_e_hp()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input upper border of the HP interval:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        #endregion

        public void print(string entities)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("A list of entities:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(entities);
        }
        public string get_id()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input ID of entity:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }
        public string get_num()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Input number of randomly generated entities:");
            Console.ForegroundColor = ConsoleColor.Gray;
            return Console.ReadLine();
        }


        #region errors
        public void err_wrong_entity()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The entity with such a number does not exist or you've entered a string");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void err_wrong_option()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The option with such a number does not exist or you've entered a string");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void err_empty_table(string entity)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(entity + " table is empty");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void err_wrong_ID(string entity)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(entity + " with ID does not exist or you've entered a string");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void err_empty(string entity)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(entity + " cannot be empty");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void err_number(string entity)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(entity + " shold be a number");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void err_generation()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Number shold be between 0 and 100 000");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void err_connection()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Connection does not exist");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion
        #region successfull
        public void successfull_operation(string entity, int ID, string operation)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(entity + " with ID " + ID + " " + operation + "  successfully");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void successfull_generation(string entity, int num)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(num + " " + entity + " generated successfully");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void successfull_connection()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("New connection added successfully");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void successfull_connection_delete(int link)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Connection " + link + " deleted successfully");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        #endregion
    }
}

