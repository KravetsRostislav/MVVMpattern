﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.DataService;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        //[JsonProperty("Students")]

        #region Properties
        private ObservableCollection<Student> student;
        public ObservableCollection<Student> Students
        {
            get => student;
            set
            {
                student = value;
                Notify();
            }
        }
        public Student SelectedStudent { get; set; }
        public JsonDataService Json { get; set; } = new JsonDataService();
        #endregion

        public MainViewModel()
        {
            if (Students == null)
            {
                Students = new ObservableCollection<Student>();
            }
            AddCommand = new RelayCommand(x =>
            {
                AddToStudents();
            });
            RemoveCommand = new RelayCommand(x =>
            {
                RemoveSelected();
            });
            SaveJson = new RelayCommand(x =>
            {
                Json.Save(Students);
            });
            LoadJson = new RelayCommand(x =>
            {
                var students = Json.Load();
                InitStudents(students);

            });


        }

        #region Commands 
        public ICommand AddCommand { get; set; }
        public ICommand RemoveCommand { get; set; }
        public ICommand SaveJson { get; set; }
        public ICommand LoadJson { get; set; }


        #endregion

        #region Methods
        public void AddToStudents()
        {
            var student = new Student { Name = "NULL", Lastname = "NULL", Year = 0, Group = "NULL" };
            Students.Add(student);
        }
        public void RemoveSelected()
        {
            Students.Remove(SelectedStudent);
        }
        public void InitStudents(ObservableCollection<Student> students)
        {
            Students = students; //
            Notify();
        }
        protected void Notify([CallerMemberName]string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


    }
}
