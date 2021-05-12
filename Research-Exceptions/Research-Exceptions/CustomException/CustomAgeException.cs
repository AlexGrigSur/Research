using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Research_Exceptions.CustomException
{
    [Serializable]
    public class CustomAgeException : Exception
    {
        public CustomAgeException()
        {
        }

        public CustomAgeException(int age) 
            : base($"Invalid age: {age}")
        {
        }
    }
}
