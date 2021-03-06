using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Assignment1()
        {
            Console.WriteLine("---> Assignment 1 (input exception) <---");
            var person1 = new Person();
            
            //person1.AddName("", "Cristian");    //err
            //person1.AddName(null, "");          //err
<<<<<<< HEAD
<<<<<<< HEAD
            person1.AddName("", "");            //err
=======
            //person1.AddName("", "");            //err
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
            //person1.AddName("", "");            //err
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            person1.AddName("Anghelenici", "Cristian");
            Console.WriteLine(person1);
        }


        [TestMethod]
        public void Assignment2()
        {
            Console.WriteLine("---> Assignment 2 (custom exceptions) <---");

            var person2 = new Person();
            //person2.AddAge(-1);
            person2.AddAge(10);
            Console.WriteLine(person2);
        }


        [TestMethod]
        public void Assignment3()
        {
            Console.WriteLine("---> Assignment 3 (Try-catch-Finally block with multiple catch) <---");

            var person3 = new Person();

            try
            {
<<<<<<< HEAD
<<<<<<< HEAD
                NewMethod(person3);
=======
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
                try
                {
                    //person3.AddAge(23);
                    person3.AddAge(-1);
                    person3.AddName("Anghelenici", "Cristian");
                    Console.WriteLine(person3);
                }
                catch (InvalidAge e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
<<<<<<< HEAD
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            }
            catch (Exception e)
            {
                Console.WriteLine($"External catch: {e.InnerException?.Message}");
            }
            finally
            {
                Console.WriteLine("Finaly block");
            }
        }

<<<<<<< HEAD
<<<<<<< HEAD
        private static void NewMethod(Person person3)
        {
            try
            {
                //person3.AddAge(23);
                person3.AddAge(-1);
                person3.AddName("Anghelenici", "Cristian");
                Console.WriteLine(person3);
            }
            catch (InvalidAge e)
            {
                Console.WriteLine(e.Message);
                var exception = new Exception("SDS", e);
                throw exception;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
        [TestMethod]
        public void Assignment4()
        {
            Console.WriteLine("---> Assignment 4 (Use Catch WHEN Filter) <---");

<<<<<<< HEAD
<<<<<<< HEAD
            
            var person4 = new Person();


            var anon = new
            {
                a = 3,
                b = 5
            };

=======
            var person4 = new Person();

>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
=======
            var person4 = new Person();

>>>>>>> 18a9e152a9d4ca40f5adaa6c18f43b9d49cd1355
            try
            {

                try
                {
                    person4.AddAge(4);
                    //person4.AddAge(5);
                    person4.AddName("Anghelenici", "Cristian");
                    if (person4.Age == 4)
                        throw new DivideByZeroException(message: $"{person4.Age} err age=4");

                }
                catch (DivideByZeroException e) when (person4.Age == 4)
                {
                    Console.WriteLine($"Age: {person4.Age}, Err: {e.Message}");
                    throw;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(person4 + "\n" + e.Message);
            }
        }

    }
}
