//******************************************************
// File: PayrollGUI.sln
//
// Purpose: Creates class instances imported from Payroll.cs
//          to be used in Event Handler code. Allows the user to choose a department 
//          JSON file. Populates data in to listviews. Performs calculations for certain
//          textboxes. Also makes use of the FindWorker() method in a textbox.
//          
//
// Written By: Peter Ciccone
//
// Compiler: Visual Studio 2019
//
//******************************************************
using Microsoft.Win32;
using Payroll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PayrollGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Department d = new Department();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;   // Sets to open in bin\Debug folder
            ofd.Title = "Open Department From JSON";    // Sets the title for the window
            ofd.Filter = "Json files (*.json)|*.json";     // Filters to only show .JSON files
     
            if (ofd.ShowDialog() == true)   // If open is clicked, runs the serialization and loads the textboxes/listview.
            {
                textBoxFilename.Text = ofd.FileName;
                string filename = ofd.FileName;

                StreamReader sr;
                sr = new StreamReader(filename);
                FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read);

                DataContractJsonSerializer inputSerializer; // Serializes JSON input.
                inputSerializer = new DataContractJsonSerializer(typeof(Department));

                d = (Department)inputSerializer.ReadObject(reader);
                reader.Close();
                sr.Close();

                string deptName = d.deptName;
                textBoxDepartment.Text = deptName;

                double totalHours = 0;
                for (int i = 0; i < d.Shifts.Count; i++)
                {
                    totalHours += d.Shifts[i].HoursWorked;
                }
                string hoursString = Convert.ToString(totalHours);
                textBoxTotalHours.Text = hoursString;

                string totalPayString = Convert.ToString(d.CalculateTotalPay(d));
                textBoxTotalPay.Text = totalPayString;

                for (int i = 0; i < d.Workers.Count; i++)
                {
                    Worker w = new Worker();
                    w.Name = d.Workers[i].Name;
                    w.Id = d.Workers[i].Id;
                    w.PayRate = d.Workers[i].PayRate;
                    listViewWorker.Items.Add(w);    // Binds with the Worker properties in order
                }                                   // to load each worker in the listview. 

                for (int i = 0; i < d.Shifts.Count; i++)
                {
                    Shift s = new Shift();
                    s.WorkerId = d.Shifts[i].WorkerId;
                    s.HoursWorked = d.Shifts[i].HoursWorked;
                    s.Date = d.Shifts[i].Date;
                    listViewShifts.Items.Add(s);    // Binded with Shift properties. 

                }
                textBoxName.Clear();        // Clears textboxes used with the FindWorker method.
                textBoxId.Clear();          
                textBoxPayrate.Clear();
                textBoxHours.Clear();
                textBoxPay.Clear();
                textBoxFind.Clear();
            }
            else
            {
                ofd.Reset();    // If the user clicks X or cancel, prevents the program from crashing.
            }
        }

        private void buttonFindWorker_Click(object sender, RoutedEventArgs e)
        {
            
            string inputId;
            int workerId;
            inputId = textBoxFind.Text;
            workerId = Convert.ToInt32(inputId);

            if (d.FindWorker(workerId) == null) // If worker is not found, the textboxes clear.
            {
                textBoxName.Clear();
                textBoxId.Clear();
                textBoxPayrate.Clear();
                textBoxHours.Clear();
                textBoxPay.Clear();
            }

            else
            {
                textBoxName.Text = d.FindWorker(workerId).Name;

                string idString = Convert.ToString(d.FindWorker(workerId).Id);
                textBoxId.Text = idString;

                string payRateString = Convert.ToString(d.FindWorker(workerId).PayRate);
                textBoxPayrate.Text = payRateString;

                double hours = 0;
                for (int i = 0; i < d.Shifts.Count; i++)
                {
                    if (inputId == d.Shifts[i].WorkerId)     // Iterates through all shifts for the specified worker
                    {                                        // and adds them up.
                        hours += d.Shifts[i].HoursWorked;
                    }
                }
                string hoursString = Convert.ToString(hours);
                textBoxHours.Text = hoursString;

                string workerPayString = Convert.ToString(d.CalculatePay(workerId));
                textBoxPay.Text = workerPayString;
            }
          
        }
    }
}
