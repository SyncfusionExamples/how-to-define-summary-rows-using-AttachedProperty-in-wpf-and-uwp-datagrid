using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo
{
    public class Model : INotifyPropertyChanged
    {
        private int employeeID;
        private string employeeName;
        private string city;
        private int employeeAge;
        private double employeeSalary;
        public int EmployeeID
        {
            get { return employeeID; }
            set
            {
                employeeID = value;
                OnPropertyChanged("EmployeeID");
            }
        }
        public string EmployeeName
        {
            get { return employeeName; }
            set
            {
                employeeName = value;
                OnPropertyChanged("EmployeeName");
            }
        }
        public int EmployeeAge
        {
            get { return employeeAge; }
            set
            {
                employeeAge = value;
                OnPropertyChanged("EmployeeAge");
            }
        }
        public double EmployeeSalary
        {
            get { return employeeSalary; }
            set
            {
                employeeSalary = value;
                OnPropertyChanged("EmployeeSalary");
            }
        }

        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
