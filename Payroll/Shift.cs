//******************************************************
// File: Shift.cs
//
// Purpose: Contains class definitions for Shift.
//         Contains default constructor, get/set properties, and
//         an override of the toString method.
//
// Written By: Peter Ciccone
//
// Compiler: Visual Studio 2019
//
//******************************************************
using System;
using System.Runtime.Serialization;

namespace Payroll
{
    [DataContract]
    public class Shift
    {
        #region // Member Variables.
        private string m_WorkerId;
        private double m_HoursWorked;
        private DateTime m_Date;
        #endregion

        #region // Shift Class Methods.

        //****************************************************
        // Method: Shift()
        //
        // // Purpose: Default constructor. Fills member variables with
        //                               default data.
        //****************************************************
        public Shift()
        {
            m_WorkerId = "NO_ID";
            m_HoursWorked = 0.0;
            m_Date = DateTime.Now;
        }

        //****************************************************
        // Method: toString()
        //
        // Purpose: Formats member variable data to be printed on screen.
        //****************************************************
        public override string ToString()
        { 
            return m_WorkerId + ", " + m_HoursWorked + ", " + m_Date.Date + "\r\n";
        }
        #endregion

        #region // Shift Get/Set properties.
        [DataMember(Name ="workid")]
        public string WorkerId
        {
            get { return m_WorkerId; }
            set { m_WorkerId = value; }
        }


        [DataMember(Name ="hoursworked")]
        public double HoursWorked
        {
            get { return m_HoursWorked; }
            set { m_HoursWorked = value; }
        }

        [DataMember(Name ="date")]
        public DateTime Date
        {
            get { return m_Date.Date; }
            set { m_Date = value; }
        }
        #endregion 
    }
}
