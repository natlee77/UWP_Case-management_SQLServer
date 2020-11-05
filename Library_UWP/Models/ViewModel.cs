using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Library_UWP.DB;
using Library_UWP.Models;


namespace Library_UWP.Models
{
    


    public class ViewModel
    {
        
        public ObservableCollection<Person>  Persons { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Order>  Orders { get; set; }
        public ObservableCollection<OrderProduct> OrderProducts { get; set; }
        public ObservableCollection<StatusDescript>  StatusDescripts { get; set; }
        public ObservableCollection<OrderStatus>  OrderStatuss { get; set; }

        public ViewModel()
        {
           

            Persons = new ObservableCollection<Person>();
            Products = new ObservableCollection<Product>();
            OrderProducts = new ObservableCollection<OrderProduct>();
            Orders = new ObservableCollection<Order>();
            StatusDescripts = new ObservableCollection<StatusDescript>();
            OrderStatuss = new ObservableCollection<OrderStatus> ();
        }
    }
}
