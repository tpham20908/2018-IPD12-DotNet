using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quiz2Passengers
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private string _passport;
        public string Passport
        {
            get
            {
                return _passport;
            }
            set
            {
                string pattern = "^[A-Z]{2}[0-9]{6}$";
                if (Regex.IsMatch(value, pattern))
                {
                    _passport = value;
                }
                else
                {
                    throw new Exception("Passport must be in this format (AB123456)");
                }
            }
        }
        public string Destination { get; set; }
        public DateTime DepartureDateTime { get; set; }

        private bool HasDeparted
        {
            get
            {
                return this.DepartureDateTime < DateTime.Now;
            }
        }
    }
}
