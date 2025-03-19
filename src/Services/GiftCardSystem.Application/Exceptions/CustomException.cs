using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
            
        }
       
        public CustomException(string name, object key) : base($"{name} ({key}) was not found")
        {

        }
    }
}
