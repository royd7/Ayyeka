using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CensusApp.Models
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string SqliteFileName { get; set; }
        public string CsvFileName { get; set; }

        public string DataInfoFileName { get; set; }
        public string DataFolder { get; set; }
    }
}
