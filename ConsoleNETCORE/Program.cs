using Library_NETCORE.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsoleNETCORE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("sql !");
            using (var db = new DBContext())  //create DB when App Start -- DB created before
            {
                db.Database.Migrate();
            }
        }
    }
}
