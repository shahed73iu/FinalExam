using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProjectFinal.Core.Entity
{
    public class FileDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Status { get; set; } 
    }
}
