using System.Collections.Generic;

namespace EFC.Framework.Common.Dtos
{
    public class OutgoingEmail
    {
        public List<string> To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public OutgoingEmail()
        {
            To = new List<string>();
        }
    }
}
