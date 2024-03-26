﻿using BHGroup.App.ViewModels;
using BHGroup.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BHGroup.App.Views.StudentWindow
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        public CustomStudent StudentToAdd { get; set; }
        public AddStudentWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dob = DOB.Text.Split("/").Select(d => int.Parse(d)).ToArray();
            StudentToAdd = new CustomStudent()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                StudentCode = int.Parse(StudentCode.Text),
                DateOfBirth = new DateTime(dob[2], dob[1], dob[0]),
                Gender = Gender.Text == "Male" ? Person.EGender.male : Person.EGender.female,
                JoinDate = new DateTime(),
                Status = Status.Text == "Active" ? Person.EStatus.active : Person.EStatus.inactive,
            };
            this.Close();
        }
    }
}
