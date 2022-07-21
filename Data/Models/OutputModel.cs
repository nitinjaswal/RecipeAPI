using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class OutputModel<T>
    {
        public bool Status { get; set; }
        public T Output { get; set; }
        public string Message { get; set; }
    }
}
