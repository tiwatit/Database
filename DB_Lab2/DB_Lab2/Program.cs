using System;
using lab2.MVC;
namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller m = new Controller();
            while (1 == 1)
            {
                if (m.entity_menu() == 1)
                {
                    break;
                }
            }
        }
    }
}
