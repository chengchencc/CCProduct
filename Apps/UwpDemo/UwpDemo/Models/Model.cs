using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpDemo.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }


    public class ContactRepositories
    {
        public ObservableCollection<Contact> All()
        {
            ObservableCollection<Contact> results = new ObservableCollection<Contact>();

            results.Add(new Contact() { FirstName = "James", LastName = "Buchanan", Company = "Benton" });
            results.Add(new Contact() { FirstName = "Josephine", LastName = "Darakjy", Company = "Chanay" });
            results.Add(new Contact() { FirstName = "Art", LastName = "Venere", Company = "Chemel" });
            results.Add(new Contact() { FirstName = "Lenna", LastName = "Paprocki", Company = "Feltz Printing Service" });
            results.Add(new Contact() { FirstName = "Donette", LastName = "Foller", Company = "Printing Dimensions" });
            results.Add(new Contact() { FirstName = "Simona", LastName = "Morasca", Company = "Chapman" });
            results.Add(new Contact() { FirstName = "Mitsue", LastName = "Tollner", Company = "Morlong Associates" });
            results.Add(new Contact() { FirstName = "Leota", LastName = "Dilliard", Company = "Commercial Press" });
            results.Add(new Contact() { FirstName = "Sage", LastName = "Wieser", Company = "Truhlar And Truhlar Attys" });
            results.Add(new Contact() { FirstName = "Kris", LastName = "Marrier", Company = "King" });
            results.Add(new Contact() { FirstName = "Minna", LastName = "Amigon", Company = "Dorl" });
            results.Add(new Contact() { FirstName = "Abel", LastName = "Maclead", Company = "Rangoni Of Florence" });
            results.Add(new Contact() { FirstName = "Kiley", LastName = "Caldarera", Company = "Feiner Bros" });
            results.Add(new Contact() { FirstName = "Graciela", LastName = "Ruta", Company = "Buckley Miller & Wright" });
            results.Add(new Contact() { FirstName = "Cammy", LastName = "Albares", Company = "Rousseaux" });

            return results;
        }
    }

}
