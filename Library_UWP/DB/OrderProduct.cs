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
    public partial class OrderProduct : INotifyPropertyChanged
    {
        [Key]
        [JsonProperty(propertyName: "ordertid")]
        public int OrderId { get; set; }
        [Key]
        [JsonProperty(propertyName: "productid")]
        public int ProductId { get; set; }
        [JsonProperty(propertyName: "guantity")]
        public int Quantity { get; set; }
        [JsonProperty(propertyName: "orderstatusid")]
        public int OrderStatusId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderProduct")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(OrderStatusId))]
        [InverseProperty("OrderProduct")]
        public virtual OrderStatus OrderStatus { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderProduct")]
        public virtual Product Product { get; set; }

        //++
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //++
       
    }


    public class OrderProductViewModel
    {
        public ObservableCollection<OrderProduct> OrderProducts { get; set; }

        public OrderProductViewModel()
        {
            OrderProducts = new ObservableCollection<OrderProduct>();
        }
        public ObservableCollection<OrderProduct> GetOrderProducts(string connectionString)
        {
            const string GetOrderProductsQuery = "select OrderId, ProductId, Quantity, OrderStatusId " +
               " from OrderProducts  ";

            var orderProducts = new ObservableCollection<OrderProduct>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetOrderProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var orderProduct = new OrderProduct();
                                    orderProduct.OrderId = reader.GetInt32(0);
                                    orderProduct.ProductId = reader.GetInt32(1);
                                    orderProduct.Quantity = reader.GetInt32(2);
                                    orderProduct.OrderStatusId = reader.GetInt32(3);

                                    orderProducts.Add(orderProduct);
                                }
                            }
                        }
                    }
                }
                return orderProducts;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}
