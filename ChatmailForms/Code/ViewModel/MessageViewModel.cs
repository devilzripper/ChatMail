using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatmailForms.Code.ViewModel
{
    public class MessageViewModel
    {
        public string Text { get; set; }

        public string RecipentName { get; set; }

        public string SenderName { get; set; }

        public DateTime TimeStamp { get; set; }

        
    }
}
