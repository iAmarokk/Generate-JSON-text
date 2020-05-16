using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;


namespace GenerateJsonText
{
    class Program
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            //сохранение данных
            using (StreamWriter file = File.CreateText("user.json"))
            {
                List<Model> models = new List<Model>();
                for (int i = 1; i < 500000; i++)
                {
                    Model tom = new Model() { Identity = i, FIO = "Tom"+ random.Next(1, 10000000), City = "Kazan", Mail = "example@mail", Number = "895020"+i, Date = DateTime.Now };
                    models.Add(tom);
                }
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(file, models);
            }
            Console.WriteLine("Data has been saved to file");
        }


        public class Model
        {
            public int Identity { get; set; }
            public string FIO { get; set; }
            public string City { get; set; }
            public string Mail { get; set; }
            public string Number { get; set; }
            [DataType(DataType.Date)]
            public DateTime Date { get; set; }
        }
    }
}
