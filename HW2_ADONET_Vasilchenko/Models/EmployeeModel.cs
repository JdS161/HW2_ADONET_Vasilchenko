using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_ADONET_Vasilchenko.Models
{
    internal class EmployeeModel
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public int PositionID { get; set; }

        public EmployeeModel(int _ID, string _lastName, string _firstName, DateTime _birthDate, int _positionID)
        {
            ID = _ID;
            LastName = _lastName;
            FirstName = _firstName;
            BirthDate = _birthDate;
            PositionID = _positionID;
        }

        public override string ToString()
        {
            return $"{ID}\t{LastName}\t{FirstName}\t{BirthDate.ToShortDateString()}\t{PositionID}";
        }
    }
}
