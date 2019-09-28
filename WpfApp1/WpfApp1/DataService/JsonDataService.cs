using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.DataService
{
    class JsonDataService : IDataService<ObservableCollection<Student>> 
    {
        string path = "students.json";

        public void Save(ObservableCollection<Student> data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);

        }
        public ObservableCollection<Student> Load()
        {
            ObservableCollection<Student> students;
            if (!File.Exists(path))
                students = new ObservableCollection<Student>();
            string json = File.ReadAllText(path);
            return students = JsonConvert.DeserializeObject<ObservableCollection<Student>>(json);
        }
    }
}
