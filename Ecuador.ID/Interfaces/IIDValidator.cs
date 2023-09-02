using Ecuador.ID.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecuador.ID.Interfaces
{
    public interface IIDValidator
    {
        public List<InfoID> IsValid(List<string> ids);
        public List<InfoID> IsValid(string ids, string delimiter);
        public InfoID IsValid(string id);
    }
}
