using System.Collections.Generic;

namespace Core.Dtos
{
    public class Message
    {
        public byte ResultStatus { get; set; }
        public string AlertColor { get; set; }
        public List<string> ResultMessages { get; set; }
    }
}