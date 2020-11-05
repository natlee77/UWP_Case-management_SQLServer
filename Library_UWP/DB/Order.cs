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
    public partial class Order : INotifyPropertyChanged
    {
        public Order()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }


        [ForeignKey(nameof(PersonId))]
        [InverseProperty(nameof(Order))]      
        public virtual Person Person { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }

        //++

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //++
        public ObservableCollection<Order> GetOrders(string connectionString)
        {
            const string GetOrdersQuery = "select  Id, CustomerId, OrderDate" +
               " from Orders inner join Persons on Orders.PersonId = Persons.PersonId " ;

            var orders = new ObservableCollection<Order>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetOrdersQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var order = new Order();
                                    order.Id = reader.GetInt32(0);
                                    order.PersonId = reader.GetInt32(1);
                                    order.OrderDate = reader.GetDateTime(2);
                                   
                                    orders.Add(order);
                                }
                            }
                        }
                    }
                }
                return orders;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}
