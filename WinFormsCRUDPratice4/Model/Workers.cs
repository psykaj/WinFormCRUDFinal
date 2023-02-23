using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsCRUDPratice4.Model
{
    class Workers
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string gender { get; set; }
        public string states { get; set; }
        public DateTime DOB { get; set; }
        public int payments { get; set; }
        public string addressPlace { get; set; }
    }
}
