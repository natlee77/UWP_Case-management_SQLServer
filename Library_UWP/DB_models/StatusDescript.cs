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
    public partial class StatusDescript : INotifyPropertyChanged
    {
        public StatusDescript()
        {
            OrderStatus = new HashSet<OrderStatus>();
        }

        [Key]
        public int Id { get; set; }
        public bool Waiting { get; set; }
        public bool Active { get; set; }
        public bool Completed { get; set; }

        [InverseProperty("StatusDescriptNavigation")]
        public virtual ICollection<OrderStatus> OrderStatus { get; set; }


        //++
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //++
        public ObservableCollection<StatusDescript> GetStatusDescript(string connectionString)
        {
            const string GetStatusDescriptsQuery = "select OrderId, Waiting, Active, Completed " +
               " from StatusDescripts  ";

            var statusDescripts = new ObservableCollection<StatusDescript>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetStatusDescriptsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var statusDescript = new StatusDescript();
                                    statusDescript.Id = reader.GetInt32(0);
                                    statusDescript.Waiting = reader.GetBoolean(1);
                                    statusDescript.Active  = reader.GetBoolean(2);
                                    statusDescript.Completed  = reader.GetBoolean(3);

                                    statusDescripts.Add(statusDescript );
                                }
                            }
                        }
                    }
                }
                return statusDescripts;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return null;
        }
    }
}

