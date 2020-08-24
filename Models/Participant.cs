using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HammerEndPoint.Models
{
    public class Participant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
