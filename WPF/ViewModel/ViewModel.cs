using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;

namespace SfDataGridDemo {
    internal class ViewModel : INotifyPropertyChanged
    {
        private List<GridSummaryColumn> _summarycols;

        public List<GridSummaryColumn> SummaryColumns
        {
            get { return _summarycols; }
            set
            {
                _summarycols = value;
                RaisePropertyChanged("SummaryColumns");
            }
        }


        public ObservableCollection<Model> employeelist;

        public ObservableCollection<Model> EmployeeDetails
        {
            get { return employeelist; }
            set
            {
                value = employeelist;
                RaisePropertyChanged("EmployeeDetails");
            }
        }

        public ViewModel()
        {
            PopulateEmployeeDetails();
            SetSummaryColumns();
        }

        private void PopulateEmployeeDetails()
        {
            employeelist = new ObservableCollection<Model>();

            employeelist.Add(new Model
            {
                EmployeeID = 101,
                EmployeeName = "Jacobs",
                EmployeeAge = 25,
                EmployeeSalary = 20000,
                City = "Belgium"
            });
            employeelist.Add(new Model
            {
                EmployeeID = 102,
                EmployeeName = "Antony",
                EmployeeAge = 32,
                EmployeeSalary = 21000,
                City = "Bracke"
            });
            employeelist.Add(new Model
            {
                EmployeeID = 103,
                EmployeeName = "Markus",
                EmployeeAge = 45,
                EmployeeSalary = 22000,
                City = "Arhus"
            });
            employeelist.Add(new Model
            {
                EmployeeID = 104,
                EmployeeName = "Antony",
                EmployeeAge = 26,
                EmployeeSalary = 23000,
                City = "Montreal"
            });
            employeelist.Add(new Model
            {
                EmployeeID = 105,
                EmployeeName = "Bergius",
                EmployeeAge = 29,
                EmployeeSalary = 24000,
                City = "Oulu"
            });
            employeelist.Add(new Model
            {
                EmployeeID = 106,
                EmployeeName = "Thomas",
                EmployeeAge = 38,
                EmployeeSalary = 25000,
                City = "Torino"
            });
            employeelist.Add(new Model
            {
                EmployeeID = 107,
                EmployeeName = "Martin",
                EmployeeAge = 32,
                EmployeeSalary = 35000,
                City = "Lille"
            });
            employeelist.Add(new Model
            {
                EmployeeID = 108,
                EmployeeName = "Christopher",
                EmployeeAge = 32,
                EmployeeSalary = 34000,
                City = "Geneve"
            });
            employeelist.Add(new Model
            {
                EmployeeID = 109,
                EmployeeName = "Bradman Toy",
                EmployeeAge = 38,
                EmployeeSalary = 35000,
                City = "Strasbourg"
            });
        }
        private void SetSummaryColumns()
        {
            SummaryColumns = new List<GridSummaryColumn>();
            SummaryColumns.Add(new GridSummaryColumn()
            {
                MappingName = "EmployeeID",
                Name = "EmployeeID",
                SummaryType = SummaryType.CountAggregate,
                Format = "Total: {Count}"
            });
            SummaryColumns.Add(new GridSummaryColumn()
            {
                MappingName = "EmployeeSalary",
                Name = "EmployeeSalary",
                SummaryType = SummaryType.DoubleAggregate,
                Format = "Total: {Sum}"
            });
        }
        private void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}