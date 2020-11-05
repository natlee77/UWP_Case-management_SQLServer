using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_UWP.Models
{
   //public  class Person_g
   // {

   //     //    public Person_g()
   //     //    {
   //     //    }



   //     public Person_g(string firstName, string lastName, string adress, string city, DateTime dateOfOpen)
   //     {

   //         FirstName = firstName;
   //         LastName = lastName;
   //         Adress = adress;
   //         City = city;
   //         DateOfOpen = dateOfOpen;
   //     }

   //     public int Id { get; set; }
   //     public string FirstName { get; set; }
   //     public string LastName { get; set; }
   //     public string Adress { get; set; }
   //     public string City { get; set; }
   //     public DateTime DateOfOpen { get; private set; }
   //     public string DisplayName => $"{ FirstName }  {LastName}";
   //     public string Summary => $"{ DisplayName }  {DateOfOpen:G}";
   // }



    //public class PersonViewModel
    //{//view model använda att hämta ut och visa saker// vi vill ha  lista 
    // //lista - kan använda
    //    public ObservableCollection<Person> People { get; } = new ObservableCollection<Person>();// gör new instance- var fel-not sätt instance object


    //    public PersonViewModel()//skapa lista i ctor -kan hämta från DB här-utan DATAACCESS DELEN 
    //    {//populera
    //     //  People.Add(new Person_g("Nataliya", "Lisjö","gatan", "Örebro", new DateTime( 2020, 06, 06)));   //dataformat year/month/day
    //     //   People.Add(new Person("Max", "Lisjö", "gatan", "Degerfors", new DateTime(2017, 11, 04)));
    //    }

    //    public void RemoveItem(Person person) //delete knapp f.
    //    {
    //        People.Remove(person);
    //    }

    //    public void AddItem(Person person)
    //    {
    //        People.Add(person);
    //    }
    //} //=> till grafiska mainpage




}  /*vi ska bygga MVVM  view model utav det 
    * --finns:
    * MVC -- ASP.net--model view Controler,
    *MVVM --- Design ---model View Viewmodel    
    
    vi har Person class   ----skapa i den fil class PersonViewModel
    */
