using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.DataService;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class MainViewModel
    {
        #region Properties
        [JsonProperty("Students")]
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public Student SelectedStudent { get; set; }
        private JsonDataService json = new JsonDataService();
        #endregion

        public MainViewModel()
        {
            AddCommand = new RelayCommand(x =>
            {
                AddToStudents(new Student { Name = "None", Lastname = "None", Year = 0, Group = "None" });
            });
            RemoveCommand = new RelayCommand(x =>
            {
                RemoveSelected();
            });
            SaveJson = new RelayCommand(x =>
            {
                json.Save(Students);
            });
            LoadJson = new RelayCommand(x =>
            {
                ReturnLoad();
            });
        }

        #region Commands 
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveJson { get; set; }
        public ICommand LoadJson { get; set; }
        #endregion

        #region Methods
        public void AddToStudents(Student student)
        {
            Students.Add(student);
        }
        public void RemoveSelected()
        {
            Students.Remove(SelectedStudent);
        }
        public void ReturnLoad()
        {
            Students = json.Load();
        }
        #endregion
    }
}
