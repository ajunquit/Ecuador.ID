using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuador.ID.Exceptions
{
    public class StateCodeNotFoundException: Exception
    {
        public string StateCode { get; set;}
        public string ID { get; set; }
        public StateCodeNotFoundException()
        {
        }

        public StateCodeNotFoundException(string message): base(message)
        {
        }

        public StateCodeNotFoundException(string message, string stateCode, string id): this(message)
        {
            this.StateCode = stateCode;
            this.ID = id;
        }

        public StateCodeNotFoundException(string message, Exception inner): base(message, inner)
        {   
        }

    }
}
