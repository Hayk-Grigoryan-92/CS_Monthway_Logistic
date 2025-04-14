using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Models.ContainerType
{
    internal class ContainerType
    {
        public bool IsOpen { get; set; }

        public float Coefficient { get; set; }

        public ContainerType(bool isOpen, float coefficient)
        {
            IsOpen = isOpen;
            Coefficient = coefficient;
        }
    }
}
