using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace dz_09_03
{
    class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Year { get; set; }
        public int Price { get; set; }

        public Phone() { }
        public Phone(string name, string company, string year, int price)
        {
            Name = name;
            Company = company;
            Year = year;
            Price = price;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Phone> list = new List<Phone>
            {
                new Phone("Iphone 13", "Apple", "2021", 920),
                new Phone("sad", "Lenovo", "2022", 350),
                new Phone("3310", "Nokia", "2022", 630)
            };

            XDocument xdoc = XDocument.Load("phones.xml");

            //ex ADD
            XElement root = xdoc.Element("phones");
            Console.Write("Enter new name: ");
            string n = Console.ReadLine();
            Console.Write("Enter new company: ");
            string c = Console.ReadLine();
            Console.Write("Enter new year: ");
            string y = Console.ReadLine();
            Console.Write("Enter new price: ");
            string p = Console.ReadLine();
            if (root != null) {
                root.Add(new XElement("phone",
                    new XAttribute("name", n),
                    new XElement("company", c),
                    new XElement("year", y),
                    new XElement("price", p)));
                xdoc.Save("phones.xml");
                Console.WriteLine(xdoc);
            }
            

            //ex 2 Search
            Console.Write("Enter name of phone to search it: ");
            string s_name = Console.ReadLine();
            var element = xdoc.Element("phones")?   
                .Elements("phone")            
                .FirstOrDefault(p => p.Attribute("name")?.Value == s_name);
            var name = element?.Attribute("name")?.Value;
            var company = element?.Element("company")?.Value;
            var year = element?.Element("year")?.Value;
            var price = element?.Element("price")?.Value;
            Console.WriteLine($"Name: {name}\nCompany: {company}\nYear: {year}\nPrice: {price}");
            

            //ex 3 Delete
            XElement root = xdoc.Element("phones");
            if (root != null) {
                var element = root.Elements("phone")
                    .FirstOrDefault(p => p.Attribute("name")?.Value == "A53");
                
                if (element != null) {
                    element.Remove();
                    xdoc.Save("phones.xml");
                }
            }
            Console.WriteLine(xdoc);
            

            //ex 4 Edit
            Console.Write("Enter element to change: ");
             string name = Console.ReadLine();
             var element = xdoc.Element("phones")?
                 .Elements("phone")
                 .FirstOrDefault(a => a.Attribute("name")?.Value == name);
             if(element != null) {
                 var new_name = element.Attribute("name");
                 if (new_name != null) {
                     Console.Write("Enter new name: ");
                     string n = Console.ReadLine();
                     new_name.Value = n;
                 }
                 var new_company = element.Attribute("company");
                 if (new_company != null) {
                     Console.Write("Enter new company: ");
                     string c = Console.ReadLine();
                     new_company.Value = c;
                 }
                 var new_year = element.Attribute("year");
                 if (new_company != null) {
                     Console.Write("Enter new year: ");
                     string y = Console.ReadLine();
                     new_company.Value = y;
                 }
                 var new_price = element.Attribute("price");
                 if (new_company != null) {
                     Console.Write("Enter new price: ");
                     string p = Console.ReadLine();
                     new_company.Value = p;
                 }
             }
             Console.WriteLine(xdoc);
            

            //ex 5 input
            XElement phones = xdoc.Element("phones");
            foreach (XElement p in phones.Elements("phone")) {
                XAttribute name = p.Attribute("name");
                XElement company = p.Element("company");
                XElement year = p.Element("year");
                XElement price = p.Element("price");
                Console.WriteLine($"Name: {name?.Value}");
                Console.WriteLine($"Company: {company?.Value}");
                Console.WriteLine($"Year: {year?.Value}");
                Console.WriteLine($"Price: {price?.Value}");
                Console.WriteLine();
            }
            

        }
    }
}