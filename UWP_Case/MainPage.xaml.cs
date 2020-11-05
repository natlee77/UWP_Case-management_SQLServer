using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Library_UWP.Models;
using Library_UWP.DB;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Library_UWP;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Case
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>   

    public sealed partial class MainPage : Page

    { 




        public OrderProductViewModel orderProductViewModel { get; set; }
        public  ViewModel  viewModel { get; set; }



        public MainPage()
        {
            this.InitializeComponent();

            this.DataContext = new OrderProduct();
            orderProductViewModel = new OrderProductViewModel();
            viewModel = new ViewModel();
        // PopulatePersonViewModel("file.json").GetAwaiter();
        // JsonService.WriteToFile($@"C:\Users....Documents\MyFiles", new Person("Nataliya", "Lisjo",  , "Degerfors", 69335));//connect to JsonService

    }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAllOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCompletedOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        public async Task PopulatePersonViewModel(string fileName)
        {
            // JSON
            var persons = JsonConvert.DeserializeObject<ObservableCollection<Person>>(await FileHelper.GetFileContentAsync(fileName));

            foreach (var person in persons)
            {
                viewModel.Persons.Add(person);
            }
        }

    }
}

