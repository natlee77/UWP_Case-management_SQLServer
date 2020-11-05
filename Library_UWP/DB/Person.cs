using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Library_UWP.DB
{
    public partial class Person : INotifyPropertyChanged
    {
        public Person()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Adress { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
        public int PostCode { get; set; }

        [InverseProperty("Person")]
        public virtual ICollection<Order> Order { get; set; }


        //++
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //++


       
    }



    public class PersonViewModel
    {
        public ObservableCollection<Person> Persons { get; set; }

        public PersonViewModel()
        {
            Persons = new ObservableCollection<Person>();
        }


        public ObservableCollection<Person> GetPersons(string connectionString)
        {
            const string GetPersonsQuery = "select Id, FirstName, LastName, Adress, City, PostCode " +
       " from Persons ";


            var persons = new ObservableCollection<Person>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetPersonsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var person = new Person();
                                    person.Id = reader.GetInt32(0);
                                    person.FirstName = reader.GetString(1);
                                    person.LastName = reader.GetString(2);
                                    person.Adress = reader.GetString(3);
                                    person.City = reader.GetString(4);
                                    person.PostCode = reader.GetInt32(5);

                                    persons.Add(person);
                                }
                            }
                        }
                    }
                }
                return persons;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}
