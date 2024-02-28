using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CensusApp.Models
{
    public class ServerResponse
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
