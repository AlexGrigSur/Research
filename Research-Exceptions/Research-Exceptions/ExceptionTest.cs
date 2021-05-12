using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Research_Exceptions.CustomException;

namespace Research_Exceptions
{
    class ExceptionTest
    {
        public void BeginTest()
        {
            DivideByZeroTest();
            Console.WriteLine("*******************");
            FileTestWithStackTrace();
            Console.WriteLine("*******************");
            ThrowNewExceptionTest();
            Console.WriteLine("*******************");
            ThrowNewExceptionCrashTest();
            Console.WriteLine("*******************");
            CustomAgeException();
        }
        private void DivideByZeroTest()
        {
            try
            {
                int zero = 0;
                int divideByZero = 5 / zero;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Finally DivideByZeroTest block. Nothing to close");
            }
        }
        private void FileTestWithStackTrace()
        {
            FileStream fs = null;
            try
            {
                fs = File.OpenWrite("C:/users/alexg/Desktop/Hello.txt");
                fs.Write(Encoding.UTF8.GetBytes("Hello"));
                throw new Exception("Exception after FS");
            }
            catch (IOException e)
            {
                Console.WriteLine("IOException stackTrace:");
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fs is not null) fs.Close();
            }
        }
        private void ThrowNewExceptionTest()
        {
            try
            {
                throw new Exception("Woop");
            }
            catch (Exception e)
            {
                Console.WriteLine("Catched error message: {0}", e.Message);
            }
        }
        private void ThrowNewExceptionCrashTest()
        {
            try
            {
                throw new Exception("Totally crashed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Catched error message: {0}", e.Message);
                //throw;
            }
        }
        private void CustomAgeException()
        {
            int age = 12;
            try
            {
                Research_Exceptions.CustomException.CinemaAgeProtection.IsAgeAllowed(age);
            }
            catch (Research_Exceptions.CustomException.CustomAgeException e)
            {
                Console.WriteLine("Custom exception message:{0}", e.StackTrace);
            }
        }
    }
}
