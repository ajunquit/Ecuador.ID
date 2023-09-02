using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuador.ID.Exceptions
{
    public class ConsequentNumberNotValidException: Exception
    {
        private string ConsequentNumber { get; }
        public ConsequentNumberNotValidException(){ }

        public ConsequentNumberNotValidException(string message): base(message) { }

        public ConsequentNumberNotValidException(string message, string consequentNumer): this(message)
        {
            this.ConsequentNumber = consequentNumer;
        }

        public ConsequentNumberNotValidException(string message, Exception innerException): base(message, innerException){ }
    }
}
