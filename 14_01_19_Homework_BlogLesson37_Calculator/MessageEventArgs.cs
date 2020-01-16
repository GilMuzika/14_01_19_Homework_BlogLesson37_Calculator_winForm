using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_01_19_Homework_BlogLesson37_Calculator
{
    class MessageEventArgs: EventArgs 
    {
        public string StringMessage { get; set; }
        public float NumberMessage { get; set; }

        
        public MessageEventArgs(string message)
        {
            StringMessage = message;
        }

        public MessageEventArgs(float numberMessage)
        {
            NumberMessage = numberMessage;
        }
    }
}
