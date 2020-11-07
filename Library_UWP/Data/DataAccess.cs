
using Library_UWP.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Library_UWP
{
    public static class DataAccess
    {
        //  SQLConnection(connect_string) 
        //SQLite($"Filename={_dbpath}")

        private static readonly string _dbname = "SQL.db";//connect string
        private static readonly string _connect = ApplicationData.Current.LocalFolder.Path;//effectivizera  sök vägen

        public static async Task IntializeDatabaseAsync()//skapa DB local fil i system catalog--när app startar
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync(_dbname, CreationCollisionOption.OpenIfExists);//1.skapa fil
                                                                                                                     // var dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "SQLitedb.db");// sök vägen/effectiviserad - flyttad upp

            //koppling /! EntetyFramework/med traditionel SQLcode
            using (var db = new SqlConnection(_connect))
            {
                db.Open();//oppna db for komunisera med db
                var query = "CREATE TABLE IF NOT EXISTS Persons(Id INTEGER AUTOINCREMENT PRIMARY KEY, FirstName NVARCHAR(50) NULL, LastName NVARCHAR(50) NULL, Adress NVARCHAR(50) NULL, City NVARCHAR(50) NULL, DataTime  NVARCHAR(50) NULL)";//sql guery// ta borted-- AUTOINCREMENT
                                                                                                                                                                                                                                               //+++ alla tabel                                                                                        //form SQLcode / 2.skapa tabel/samma som SQL Query i ServerExplore// FLERA GÅNG FOR MÅNGA TABEL//AUTOINCREMENT-Id automatisk öka upp

                var cmd = new SqlCommand(query, db);//command

                //3.kör
                //cmd.ExecuteNonQuery();//utan svar tillbacka
                cmd.ExecuteReader();  //svar flera

                db.Close();
            }
        }


        public static async Task AddAsync(string input)//++name(text) //ta borted-Person person(object)//
        {
            //  using (var db = new SqliteConnection(_connect ) //oppna/close db 
            using SqlConnection db = new SqlConnection(_connect);
            {
                db.Open();


                var query = "INSERT INTO Persons( FirstName, LastName, Adress, City) VALUES(NULL, @FirstName, @LastName, @Adress, @City)"; //add , öka automatisk, @-parametr raise query
                var cmd = new SqlCommand(query, db);//                               

                // cmd.Parameters.AddWithValue("@Id", input);
                cmd.Parameters.AddWithValue("@FirstName", input);//mappa parametr -input text
                cmd.Parameters.AddWithValue("@LastName", input);
                cmd.Parameters.AddWithValue("@Adress", input);
                cmd.Parameters.AddWithValue("@City", input);

                await cmd.ExecuteReaderAsync();
                db.Close();
            }
        }


        public static IEnumerable<string> GetAllAsync() //hämta/return alla person i db
        {
            var list = new List<string>();//skapa list
            using (var db = new SqlConnection(_connect)) //oppna/close db 
            {
                db.Open();
                var query = "SELECT Name FROM  Persons "; //välja ,*=all
                var cmd = new SqlCommand(query, db);
                var result = cmd.ExecuteReader();//spara in var result // här problem i ASYNC 
                while (result.Read())
                {                    //++ till list
                    list.Add(result.GetString(0));             //o=column   
                }

                db.Close();
            }      
            return list;//utan den/ fel-not all code path return value
        }






        public static async Task<Person> GetAsync(int id) //hämta/return 1 person  i db
        {
            using (var db = new SqlConnection(_connect))//oppna/close db 
            {
                db.Open();
                var query = "SELECT * FROM  Persons WHERE Id= @Id "; //välja ,parametr
                var cmd = new SqlCommand(query, db);//                               
                cmd.Parameters.AddWithValue("@Id", id);
                Person result = (Person)await cmd.ExecuteScalarAsync();//spara result till att be Person
                db.Close();

                return result; //1 perosn
            }
        } // kan bygga vidare gör uppdate,delete på den access delen   

    }
}

            

