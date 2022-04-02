using System;
using System.Collections.Generic;
using ListLibrary;


namespace CustomList
{

    class Program
    {

        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            MyCustomList<string> Brands = new MyCustomList<string>(10);

            Brands.Add("Apple");
            Brands.Add("Google");
            Brands.Add("Intel");
            Brands.Add("Microsoft");
            Brands.Add("Tensent");
            Brands.Add("Nvidia");
            Brands.Add("Google");
            Brands.Insert(2, "MyBrand");
            Brands.Add("Facebook");
            Brands.Add("Oracle");

            for (int i = 0; i < Brands.Count; i++)
            {
                Console.WriteLine(Brands[i]);
            }


            //Predicate<string> predicate = word => word == "Google";

            //MyCustomList<string> customList = Brands.FindAll(predicate);

            //for (int i = 0; i < customList.Count; i++)
            //{
            //    Console.WriteLine(customList[i]);
            //}

            //-----------------------------

            //Predicate<string> predicate = word => word.Length == 7;
            //Console.WriteLine(Brands.Find(predicate));

            //-----------------------------

            //cities.Reverse();
            //for (int i = 0; i < Brands.Count; i++)
            //{
            //    Console.WriteLine(Brands[i]);
            //}

            //-----------------------------

            //Console.WriteLine(Brands.Contains("Facebook"));

            //-----------------------------

            //Console.WriteLine(Brands.IndexOf("Google")); 

            //-----------------------------

            //Console.WriteLine(Brands.LastIndexOf("Intel"));

            //-----------------------------

            //Brands.Clear();

        }
    }
}
