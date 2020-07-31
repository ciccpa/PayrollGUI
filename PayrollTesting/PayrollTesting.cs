//******************************************************
// File: PayrollTesting.cs
//
// Purpose: Contains unit testing code for Payroll classes.
//
// Written By: Peter Ciccone
//
// Compiler: Visual Studio 2019
//
//******************************************************
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payroll;
namespace PayrollTesting
{
    [TestClass]
    public class ShiftTests
    {
        [TestMethod]
        //****************************************************
        // Method: TestDate()
        //
        // Purpose: Tests to the StreamReader to ensure the date is 
        //          read in properly.
        //****************************************************
        public void TestDate()
        {
            // Arrange
            Shift s = new Shift();

            StreamReader sr = new StreamReader("../../Shift.txt");
            DateTime expected = new DateTime(2020, 1, 17);

            // Act
            while (!sr.EndOfStream)
            {
                string workId;
                workId = sr.ReadLine();
                s.WorkerId = workId;

                string hoursWork = sr.ReadLine();
                double inputHours = Convert.ToDouble(hoursWork);
                s.HoursWorked = inputHours;

                string year = sr.ReadLine();
                int inputYear = Convert.ToInt32(year);

                string month = sr.ReadLine();
                int inputMonth = Convert.ToInt32(month);

                string day = sr.ReadLine();
                int inputDay = Convert.ToInt32(day);


                DateTime date = new DateTime(inputYear, inputMonth, inputDay);
                s.Date = date;
            }
            // Assert
            DateTime actual = s.Date;
            Assert.AreEqual(expected, actual, "Invalid date recorded.");
        }
        [TestMethod]
        //****************************************************
        // Method: TestHoursWorked()
        //
        // Purpose: Tests to the StreamReader to ensure the hours worked 
        //          is read in properly.
        //****************************************************
        public void TestHoursWorked()
        {
            // Arrange
            Shift s = new Shift();

            StreamReader sr = new StreamReader("../../Shift.txt");
            double expected = 30.0;

            // Act
            while (!sr.EndOfStream)
            {
                string workId;
                workId = sr.ReadLine();
                s.WorkerId = workId;

                string hoursWork = sr.ReadLine();
                double inputHours = Convert.ToDouble(hoursWork);
                s.HoursWorked = inputHours;

                string year = sr.ReadLine();
                int inputYear = Convert.ToInt32(year);

                string month = sr.ReadLine();
                int inputMonth = Convert.ToInt32(month);

                string day = sr.ReadLine();
                int inputDay = Convert.ToInt32(day);


                DateTime date = new DateTime(inputYear, inputMonth, inputDay);
                s.Date = date;
            }
            // Assert
            double actual = s.HoursWorked;
            Assert.AreEqual(expected, actual, "Invalid hours worked.");
        }
        [TestMethod]
        //****************************************************
        // Method: TestWorkerId()
        //
        // Purpose: Tests to the StreamReader to ensure the Worker Id 
        //          read in properly.
        //****************************************************
        public void TestWorkerId()
        {
            // Arrange
            Shift s = new Shift();

            StreamReader sr = new StreamReader("../../Shift.txt");
            string expected = "100";

            // Act
            while (!sr.EndOfStream)
            {
                string workId;
                workId = sr.ReadLine();
                s.WorkerId = workId;

                string hoursWork = sr.ReadLine();
                double inputHours = Convert.ToDouble(hoursWork);
                s.HoursWorked = inputHours;

                string year = sr.ReadLine();
                int inputYear = Convert.ToInt32(year);

                string month = sr.ReadLine();
                int inputMonth = Convert.ToInt32(month);

                string day = sr.ReadLine();
                int inputDay = Convert.ToInt32(day);


                DateTime date = new DateTime(inputYear, inputMonth, inputDay);
                s.Date = date;
            }
            // Assert
            string actual = s.WorkerId;
            Assert.AreEqual(expected, actual, "Invalid work ID.");
        }
    }

    [TestClass]
    public class WorkerTests
    {
        [TestMethod]
        //****************************************************
        // Method: TestName()
        //
        // Purpose: Tests to the StreamReader to ensure the name is 
        //          read in properly.
        //****************************************************
        public void TestName()
        {
            // Arrange
            Worker w = new Worker();

            StreamReader sr = new StreamReader("../../Worker.txt");
            string expected = "Rose Diaz";

            // Act
            while (!sr.EndOfStream)
            {
                string name;
                name = sr.ReadLine();
                w.Name = name;

                string id = sr.ReadLine();
                int inputId = Convert.ToInt32(id);
                w.Id = inputId;

                string payRate = sr.ReadLine();
                double inputPayRate = Convert.ToDouble(payRate);
                w.PayRate = inputPayRate;
            }
            // Assert
            string actual = w.Name;
            Assert.AreEqual(expected, actual, "Invalid name.");
        }

        [TestMethod]
        //****************************************************
        // Method: TestId()
        //
        // Purpose: Tests to the StreamReader to ensure the ID is 
        //          read in properly.
        //****************************************************
        public void TestId()
        {
            // Arrange
            Worker w = new Worker();

            StreamReader sr = new StreamReader("../../Worker.txt");
            int expected = 100;

            // Act
            while (!sr.EndOfStream)
            {
                string name;
                name = sr.ReadLine();
                w.Name = name;

                string id = sr.ReadLine();
                int inputId = Convert.ToInt32(id);
                w.Id = inputId;

                string payRate = sr.ReadLine();
                double inputPayRate = Convert.ToDouble(payRate);
                w.PayRate = inputPayRate;
            }
            // Assert
            int actual = w.Id;
            Assert.AreEqual(expected, actual, "Invalid ID.");
        }
        [TestMethod]
        //****************************************************
        // Method: TestPayRate()
        //
        // Purpose: Tests to the StreamReader to ensure the PayRate is 
        //          read in properly.
        //****************************************************
        public void TestPayRate()
        {
            // Arrange
            Worker w = new Worker();

            StreamReader sr = new StreamReader("../../Worker.txt");
            double expected = 10.00;

            // Act
            while (!sr.EndOfStream)
            {
                string name;
                name = sr.ReadLine();
                w.Name = name;

                string id = sr.ReadLine();
                int inputId = Convert.ToInt32(id);
                w.Id = inputId;

                string payRate = sr.ReadLine();
                double inputPayRate = Convert.ToDouble(payRate);
                w.PayRate = inputPayRate;
            }
            // Assert
            double actual = w.PayRate;
            Assert.AreEqual(expected, actual, "Invalid name.");
        }
    }
    [TestClass]
    public class DepartmentTests
    {
        //****************************************************
        // Method: FindWorkerWithGoodId()
        //
        // Purpose: Tests the find worker method to make sure it 
        //          returns the correct worker.
        //****************************************************
        [TestMethod]
        public void FindWorkerWithGoodId()
        {
            //Arrange
            Department d = new Department();

            String filename = "dept.json";

            StreamReader sr;
            sr = new StreamReader(filename);
            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read);

            DataContractJsonSerializer inputSerializer; // Serializes JSON input.
            inputSerializer = new DataContractJsonSerializer(typeof(Department));

            d = (Department)inputSerializer.ReadObject(reader);
            reader.Close();

            // Act
            Worker w;
            int targetId = 100;

            w = d.FindWorker(targetId);

            //Assert
            Assert.AreEqual(targetId, w.Id, 0, "FindWorker failed.");
        }
        //****************************************************
        // Method: FindWorkerWithBadId()
        //
        // Purpose: Tests the find worker method with a bad ID
        //          to make sure it returns null.
        //          
        //****************************************************
        [TestMethod]
        public void FindWorkerWithBadId()
        {
            //Arrange
            Department d = new Department();

            String filename = "dept.json";

            StreamReader sr;
            sr = new StreamReader(filename);
            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read);

            DataContractJsonSerializer inputSerializer; // Serializes JSON input.
            inputSerializer = new DataContractJsonSerializer(typeof(Department));

            d = (Department)inputSerializer.ReadObject(reader);
            reader.Close();

            // Act
            Worker w;
            int targetId = 30;

            w = d.FindWorker(targetId);

            //Assert
            Assert.AreEqual(targetId, w.Id, 0, "FindWorker failed.");
        }
        //****************************************************
        // Method: TestCalculatePay()
        //
        // Purpose: Tests to ensure the proper Worker pay is 
        //          calculated in CalculatePay function.
        //          
        //****************************************************
        [TestMethod]
        public void TestCalculatePay()
        {
            // Arrange
            Department d = new Department();

            String filename = "dept.json";

            StreamReader sr;
            sr = new StreamReader(filename);
            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read);

            DataContractJsonSerializer inputSerializer; // Serializes JSON input.
            inputSerializer = new DataContractJsonSerializer(typeof(Department));

            d = (Department)inputSerializer.ReadObject(reader);
            reader.Close();

            int workerId = 100;

            Shift s = new Shift();
            Worker w = new Worker();

            double expected = 1300;
            
            // Act
            for (int i = 0; i < d.Workers.Count; i++)
            {
                if (workerId == d.Workers[i].Id)
                {
                    w = d.Workers[i];
                }
            }

            for (int i = 0; i < d.Shifts.Count; i++)
            {
                String convertId = d.Shifts[i].WorkerId;
                int workId = Convert.ToInt32(convertId);
                if (workerId == workId)
                {
                    s.HoursWorked += d.Shifts[i].HoursWorked;
                }
            }

            double workerPay = w.PayRate * s.HoursWorked;

            // Assert
            if (workerPay == expected)
            {
                Console.WriteLine("Test Calculate Pay: PASS.");
            }
            else
            {
                Console.WriteLine("Test Calculate Pay: FAIL.");
            }
        }
    }
}

