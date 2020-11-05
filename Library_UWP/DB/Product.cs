using Newtonsoft.Json;
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
    public partial class Product : INotifyPropertyChanged
    {
        public Product()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }
        [JsonProperty(propertyName: "id")]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }
        [Required]
        [JsonProperty(propertyName: "description")]
        public string Description { get; set; }
        [Column(TypeName = "money")]
        [JsonProperty(propertyName: "unitprice")]
        public decimal UnitPrice { get; set; }

        [InverseProperty("Product")]


        //++
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }




    public class ProductViewModel
    {//view model använda att hämta ut och visa saker// vi vill ha  lista 
     //lista - kan använda
        public ObservableCollection<Product> Product { get; } = new ObservableCollection<Product>();// gör new instance- var fel-not sätt instance object

        public ObservableCollection<Product> GetProducts(string connectionString)
        {
            const string GetProductsQuery = "select  Id,  Name,  Description, UnitPrice" +
               " from Products ";

            var products = new ObservableCollection<Product>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var product = new Product();
                                    product.Id = reader.GetInt32(0);
                                    product.Name = reader.GetString(1);
                                    product.Description = reader.GetString(2);
                                    product.UnitPrice = reader.GetDecimal(3);


                                    products.Add(product);
                                }
                            }
                        }
                    }
                }
                return products;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
        //public ProductViewModel()//skapa lista i ctor -kan hämta från DB här-utan DATAACCESS DELEN 
        //{//populera
        // //  People.Add(new Person_g("Nataliya", "Lisjö","gatan", "Örebro", new DateTime( 2020, 06, 06)));   //dataformat year/month/day
        // //   People.Add(new Person("Max", "Lisjö", "gatan", "Degerfors", new DateTime(2017, 11, 04)));
        //}

        public void RemoveItem(Product product) //delete knapp f.
        {
            Product.Remove(product);
        }

        public void AddItem(Product product)
        {
            Product.Add(product);
        }
    }
}
