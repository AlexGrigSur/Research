using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research_Exceptions.CustomException
{

    class CinemaAgeProtection
    {
        static public void IsAgeAllowed(int age)
        {
            if (age < 18 || age > 130)
                throw new CustomAgeException(age);
        }
    }
}
