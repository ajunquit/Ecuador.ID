using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuador.ID.Exceptions
{
    public class ThirdDigitNotValidException: Exception
    {
        private int ThirdDigit { get; }
        public ThirdDigitNotValidException(){ }

        public ThirdDigitNotValidException(string message): base(message) { }
        
        public ThirdDigitNotValidException(string message, int thirdDigit): this(message) { 
            this.ThirdDigit = thirdDigit;
        }

        public ThirdDigitNotValidException(string message, Exception innerException): base(message, innerException) { }


    }
}
