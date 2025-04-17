using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson45.Models
{
    internal class Operable
    {
        public int Id { get; set; }
        public bool IsOperable { get; set; }
        public float Coefficient { get; set; }

        public Operable(bool isOperable, float coefficient, int id)
        {
            IsOperable = isOperable;
            Coefficient = coefficient;
            Id = id;
        }
    }
}
