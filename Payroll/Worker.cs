//******************************************************
// File: Worker.cs
//
// Purpose: Contains class definitions for Worker.
//         Contains default constructor, get/set properties, and
//         an override of the toString method.
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
    public class Worker
    {
        #region // Member Variables.
        private string m_Name;
        private int m_Id;
        private double m_PayRate;
        #endregion

        #region // Worker Class Methods.

        //****************************************************
        // Method: Worker()
        //
        // Purpose: Default constructor. Fills member variables with
        //                               default data.
        //****************************************************
        public Worker()
        {
            m_Name = "NO_NAME";
            m_Id = 0;
            m_PayRate = 0.0;
        }

        //****************************************************
        // Method: toString()
        //
        // Purpose: Formats member variable data to be printed on screen.
        //****************************************************
        public override string ToString()
        {
            return m_Name + ", " + m_Id + ", " + m_PayRate + "\r\n";
        }
        #endregion

        #region // Worker Get/Set properties.
        [DataMember(Name ="name")]
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        [DataMember(Name ="id")]
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        [DataMember(Name ="payrate")]
        public double PayRate
        {
            get { return m_PayRate; }
            set { m_PayRate = value; }
        }
        #endregion
    }
}
