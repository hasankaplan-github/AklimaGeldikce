using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AklimaGeldikce.Entities
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            this.To = new List<EmailAddress>();
            this.Bcc = new List<EmailAddress>();
            this.Cc = new List<EmailAddress>();
        }

        public EmailAddress From { get; set; }
        public IList<EmailAddress> To { get; set; }
        public IList<EmailAddress> Cc { get; set; }
        public IList<EmailAddress> Bcc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
