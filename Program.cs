using System;
using System.Text.RegularExpressions;


namespace RegexUserRegistration
{
    public class Program
    {
        static string firstname;
        public static string namePattern = "^[A-Z]{1}[a-z]{2,}";
        public static string emailPattern = "^[A-z a-z  ]{3,}[-+0-9 ]?[.]?([a-z A-z 0-9]{3,})?[@][a-z A-z 0-9]{1,}[.]?[a-z]{2,}[.]?[a-z]{2,3}$";
        public static string mobileNumPattern = "^[9][1][ ][0-9]{10}$";
        public static string passPattern = "^((?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*-_.])(?=.{8,}))";
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=======User Registration=====");
                Console.WriteLine("Enter your FirstName");
                firstname = Console.ReadLine();
                if (firstname == null | firstname.Length ==0)
                {
                    throw new CustomStringException("cannot accept Empty or null string ");
                }
                else if (NameValidation(firstname) == false)
                {
                    throw new CustomStringException("Invalid format");
                }
            }
            catch (CustomStringException e)
            {
                Console.WriteLine("String format Exception: {0}", e.Message);
            }


            Console.WriteLine("Enter your LastName");

            try
            {
                string lastname = Console.ReadLine();


                if (lastname.Length == 0 | lastname == null)
                {
                    throw new CustomStringException("cannot accept Empty or null string ");
                }
                else if (NameValidation(lastname) == false)
                {
                    throw new CustomStringException("Invalid format");
                }
            }
            catch (CustomStringException e)
            {
                Console.WriteLine("String format Exception: {0}", e.Message);
            }



            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            try
            {
               EmailValidation(email);


            }
            catch (CustomStringException e)
            {
                Console.WriteLine("String format Exception: {0}", e.Message);
            }


            Console.WriteLine("Enter Mobile Number with Countrycode, followed by space");
            string mob = Console.ReadLine();
            try
            {
                Console.WriteLine(MobileNumValidation(mob));
            }

            catch(CustomStringException e)
            {
                Console.WriteLine("String format Exception: {0}", e.Message);
            }


            Console.WriteLine("Enter a Password");
            string pass = Console.ReadLine();

            try
            {
                Console.WriteLine(PassValidation(pass));
            }

            catch (CustomStringException e)
            {
                Console.WriteLine("String format Exception: {0}", e.Message);

            }

            string[] testSampleMails = {"abc@yahoo.com", "abc-100@yahoo.com","abc.100@yahoo.com", "abc-100@abc.net","abc-100@abc.net",
                 "abc.100@abc.com.au","abc@1.com","abc@gmail.com.com","abc+100@gmail.com" };

            foreach (string item in testSampleMails)

            {
                Console.WriteLine($" {item} {EmailValidation(item)}");
            }



            ///////////////Methods////////////////////////////
        }
        public static bool NameValidation(string name)
        {
            return Regex.IsMatch(name, namePattern);
        }

        public static bool EmailValidation(string email)
        {
            if (email == null | email.Length == 0)
            {
                throw new CustomStringException("cannot accept Empty or null string ");
            }
            else if (Regex.IsMatch(email, emailPattern) == false)
            {
                throw new CustomStringException("Invalid Email format");
            }
            else
            {
                return Regex.IsMatch(email, emailPattern);
            }
           
        }


        public static bool MobileNumValidation(string mob)
        {
            if (mob.Length == 0)
            {
                throw new CustomStringException("cannot accept Empty or null string ");
            }
            else if (Regex.IsMatch(mob, mobileNumPattern) == false)
            {
                throw new CustomStringException("Invalid Mobile NO");
            }
            else
            {
                return Regex.IsMatch(mob, mobileNumPattern);

            }

        }

        public static bool PassValidation(string pass)
        {
            if (pass.Length == 0)
            {
                throw new CustomStringException("cannot accept Empty or null string ");
            }
            else if (Regex.IsMatch(pass, passPattern) == false)
            {
                throw new CustomStringException("Invalid PAssword combination");
            }
            else
            {
                return Regex.IsMatch(pass, passPattern);
            }
          
            
        }











    }
}

        


