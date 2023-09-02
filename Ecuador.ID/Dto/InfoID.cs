
using Ecuador.ID.Enums;

namespace Ecuador.ID.Dto
{
    public class InfoID
    {
        public string ID { get; set; }
        public bool IsValid { get; set; }
        public List<Exception> Exceptions { get; set; }
        public string Message { get; set; }
        public DocumentType Type { get; set; }
        public InfoID()
        {
            Exceptions = new List<Exception>();
        }
    }
}
