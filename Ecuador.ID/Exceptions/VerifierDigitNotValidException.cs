using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuador.ID.Exceptions
{
    public class VerifierDigitNotValidException:Exception
    {
        private string VerifierDigitNotValid { get; }
        public VerifierDigitNotValidException()
        {
        }

        public VerifierDigitNotValidException(string message): base(message)
        {
        }

        public VerifierDigitNotValidException(string message, string verifierDigitNotValid): this(message){
            this.VerifierDigitNotValid = verifierDigitNotValid;
        }

        public VerifierDigitNotValidException(string message, Exception exception):base(message, exception)
        {
        }
    }
}
