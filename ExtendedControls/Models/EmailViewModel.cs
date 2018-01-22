using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedControls.Models
{
    public class EmailViewModel
    {
        public string EmailID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public bool Checked { get; set; }
        // 0 = None , 1 = Inbox , 2 = Sent
        public int Type { get; set; }
        public bool HasAttachment { get; set; }
        public List<AttachmentViewModel> Attachments { get; set; }
    }

    public class AttachmentViewModel
    {
        public string name { get; set; }
        public string id { get; set; }
    }
}
