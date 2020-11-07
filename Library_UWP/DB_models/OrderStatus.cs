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
    public partial class OrderStatus : INotifyPropertyChanged
    {
        public OrderStatus()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }
        public int StatusDescript { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderEditDate { get; set; }

        [ForeignKey(nameof(StatusDescript))]
        [InverseProperty("OrderStatus")]
        public virtual StatusDescript StatusDescriptNavigation { get; set; }
        [InverseProperty("OrderStatus")]
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }

        //++
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //++
        public ObservableCollection<OrderStatus> GetOrderStatuss(string connectionString)
        {
            const string GetOrderStatussQuery = "select  Id, StatusDescript , OrderEditDate, OrderStatusId " +
               " from OrderStatuss  ";

            var orderStatuss = new ObservableCollection<OrderStatus>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetOrderStatussQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var orderStatus = new OrderStatus();
                                    orderStatus. Id = reader.GetInt32(0);
                                    orderStatus.StatusDescript = reader.GetInt32(1);
                                    orderStatus.OrderEditDate = reader.GetDateTime(2);
                                    

                                    orderStatuss.Add(orderStatus);
                                }
                            }
                        }
                    }
                }
                return orderStatuss;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}
 
