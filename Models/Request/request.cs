using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.RequestList
{
    internal class Request
    {
        public string From { get; set; }
        public string To { get; set; }
        public TransportType Type { get; set; }
        public int Year {  get; set; }
        public string Model {  get; set; }
        public Operable IsOperable { get; set; }
        public string Email {  get; set; }

    }
    enum TransportType
    {
        Open,
        Enclosed
    }

    enum Operable
    {
        Yes,
        No
    }
}
