using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuador.ID.Exceptions
{
    public class FormatInputNotValidException: Exception
    {
        public string ID { get; set; }
        public FormatInputNotValidException()
        {
        }

        public FormatInputNotValidException(string message) : base(message)
        {
        }

        public FormatInputNotValidException(string message, string id) : this(message)
        {
            this.ID = id;
        }

        public FormatInputNotValidException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
