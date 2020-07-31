//******************************************************
// File: Department.cs
//
// Purpose: Contains class definition for Department.
//         Contains default constructor, get/set properties,
//         override of the toString method and FindWorker/CalculatePay
//         methods. 
//
// Written By: Peter Ciccone
//
// Compiler: Visual Studio 2019
//
//******************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Payroll
{
    [DataContract]
    public class Department
    {
        #region // Member Variables
        private string m_DeptName;
        private List<Worker> m_Workers;
        private List<Shift> m_Shifts;
        #endregion

        #region // Department Class Methods
        //****************************************************
        // Method: Department()
        //
        // // Purpose: Default constructor. Fills member variables with
        //                               default data.
        //****************************************************
        public Department()
        {
            m_DeptName = "NO_DEPT_NAME";
            m_Workers = new List<Worker>();
            m_Shifts = new List<Shift>();

            // Foreach is created to iterate through
            // Worker/Shift lists and give all elements default values:
            foreach (Worker w in m_Workers)
            {
                w.Name = "NO_NAME";
                w.Id = 0;
                w.PayRate = 0.0;
            }

            foreach (Shift s in m_Shifts)
            {
                s.WorkerId = "NO_ID";
                s.HoursWorked = 0.0;
                s.Date = DateTime.Now;
            }
        }

        //****************************************************
        // Method: FindWorker(int workerId)
        //
        // Purpose: Searches Worker list and returns the worker
        //           based on the ID the user enters.
        //                               
        //****************************************************
        public Worker FindWorker(int workerId)
        {
            Worker w = null;
            for (int i = 0; i < m_Workers.Count; i++)
            {
                if (workerId == m_Workers[i].Id)
                {
                    w = m_Workers[i];
                }
            }
            return w;
        }

        //****************************************************
        // Method: CalculatePay(int workerId)
        //
        // Purpose: Searches m_Workers for the payrate of 
        //          the worker based on ID the user enters.
        //          Also searches m_Shifts for hours worked and
        //          calculates total pay for that worker.                               
        //
        //****************************************************
        public double CalculatePay(int workerId)
        {
            Shift s = new Shift();
            Worker w = new Worker();

            // First loop iterates to find the correct worker so that
            // the payrate can be accessed
            for(int i = 0; i < m_Workers.Count; i++)
            {
                if (workerId == m_Workers[i].Id)
                {
                    w = m_Workers[i];
                }
            }
         
            // Second loop searches shifts for the workerId
            // and adds up total hours worked
            for (int i = 0; i < m_Shifts.Count; i++)
            {
                String convertId = m_Shifts[i].WorkerId;
                int workId = Convert.ToInt32(convertId);
                if (workerId == workId)
                {
                    s.HoursWorked += m_Shifts[i].HoursWorked;
                }
            }

            double workerPay = w.PayRate * s.HoursWorked;
            return workerPay;
        }
        //****************************************************
        // Method: CalculateTotalPay(int Department d)
        //
        // Purpose: Takes in a department instance and goes through
        //          every worker in the department, calculating their pay
        //          and totaling it.       
        //
        //  (added 3/31/20)
        //****************************************************
        public double CalculateTotalPay(Department d)
        {
            double totalPay = 0;
            for (int i = 0; i < m_Workers.Count; i++)
            {
                totalPay += d.CalculatePay(m_Workers[i].Id);
            }
            return totalPay;
        }
        //****************************************************
        // Method: toString()
        //
        // Purpose: Formats all department data to be printed on screen.
        //****************************************************
        public override string ToString()
        {
            String returnString = "";
            for (int i = 0; i < m_Workers.Count; i++)
            {
               returnString += m_Workers[i].ToString();
            }

            for (int i = 0; i < m_Shifts.Count; i++)
            {
                returnString += m_Shifts[i].ToString();
            }
            return m_DeptName + "\r\n" + returnString;
        }
        #endregion

        #region // Department Get/Set Methods
        [DataMember(Name = "name")]
        public string deptName
        {
            get { return m_DeptName; }
            set { m_DeptName = value; }
        }

        [DataMember(Name = "workers")]
        public List<Worker> Workers
        {
            get { return m_Workers; }
            set { m_Workers = value; }
        }

        [DataMember(Name = "shifts")]
        public List<Shift> Shifts
        {
            get { return m_Shifts; }
            set { m_Shifts = value; }
        }
        #endregion
    }
}

