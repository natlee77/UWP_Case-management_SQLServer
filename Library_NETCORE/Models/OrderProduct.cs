using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Library_NETCORE.Models
{
    public partial class OrderProduct : INotifyPropertyChanged
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
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
        ////public ObservableCollection<OrderProduct> GetOrderProducts(string connectionString)
        //{
        //    const string GetProductsQuery = "select ProductID, ProductName, QuantityPerUnit," +
        //       " UnitPrice, UnitsInStock, Products.CategoryID " +
        //       " from Products inner join Categories on Products.CategoryID = Categories.CategoryID " +
        //       " where Discontinued = 0";

        //    var products = new ObservableCollection<OrderProduct>();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            if (conn.State == System.Data.ConnectionState.Open)
        //            {
        //                using (SqlCommand cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandText = GetProductsQuery;
        //                    using (SqlDataReader reader = cmd.ExecuteReader())
        //                    {
        //                        while (reader.Read())
        //                        {
        //                            var product = new Product();
        //                            product.ProductID = reader.GetInt32(0);
        //                            product.ProductName = reader.GetString(1);
        //                            product.QuantityPerUnit = reader.GetString(2);
        //                            product.UnitPrice = reader.GetDecimal(3);
        //                            product.UnitsInStock = reader.GetInt16(4);
        //                            product.CategoryId = reader.GetInt32(5);
        //                            products.Add(product);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return products;
        //    }
        //    catch (Exception eSql)
        //    {
        //        Debug.WriteLine("Exception: " + eSql.Message);
        //    }
        //    return null;
        //}

    }
}
