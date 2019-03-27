using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using ACDB.Models;

namespace WEB
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ACDBContext db = new ACDBContext())
            {
//                foreach (var c in db.Customers)
//                {
//                    Console.WriteLine($"{c.CustomerId}, {c.LastName}, {c.FirstName}, {c.JoinDate}");
//                }

                Console.WriteLine("1.	Display the lowest last name alphabetically (Customers table)");
                Console.WriteLine(db.Customers.Max(x => x.LastName));

                var v2 = db.Customers.OrderByDescending(x=>x.LastName).Select(x=>x.LastName).Take(1);

                var v3 = (from x in db.Customers
                    orderby x.LastName
                    select (x.LastName)).Take(1);

                foreach (var v in v2)
                {
                    Console.WriteLine(v);
                }

                //----------
                Console.WriteLine("2.	Display the average monthly payment (Packages table).");
                var v4 = db.Packages.Average(x => x.MonthlyPayment);
                Console.WriteLine(v4);


                Console.WriteLine("3.	Display the highest last name alphabetically (Customers table).");
                var v5 = db.Customers.OrderBy(x => x.LastName).Select(x => x.LastName).Take(1);
                var v51 = db.Customers.Min(x => x.LastName);
                foreach (var v in v5)
                {
                    Console.WriteLine($"{v} {v51}");
                }

                //==================

                Console.WriteLine("4.	Display the number of internet packages (Packages table).");
                var v6 = db.Packages.Count();
                Console.WriteLine(v6);

                //=====================

                Console.WriteLine("5.	Display the number of records in Customers table.");
                var v7 = db.Customers.Count();
                Console.WriteLine(v7);
                //========================

                Console.WriteLine("6.	Display the number of distinct states  (Customers table).");
                var v8 = db.Customers.Select(x => x.State).Distinct().Count();
                Console.WriteLine(v8);
                //========================

                Console.WriteLine("7.	Display the number of distinct internet speeds (Packages table).");
                var v9 = db.Packages.Select(x => x.Speed).Distinct().Count();
                Console.WriteLine(v9);
                //=======================

                Console.WriteLine("8.	Display the number of values (exclude Nulls) in Fax column (Customers table).");
                var v10 = db.Customers.Where(x=>x.Fax != null).Select(x => x.Fax).Count();
                Console.WriteLine(v10);
                //======================

                Console.WriteLine("9.	Display the number of Null values in Fax column (Customers table).");
                var v11 = db.Customers.Where(x => x.Fax == null).Select(x => x.Fax).Count();
                Console.WriteLine(v11);
                //======================

                Console.WriteLine("10.	Display the highest, lowest and average monthly discount (Customers table).");
                var v12 = db.Customers.Average(x => x.MonthlyDiscount);
                var v13 = db.Customers.Min(x => x.MonthlyDiscount);
                var v14 = db.Customers.Max(x => x.MonthlyDiscount);
                Console.WriteLine($"{v12}, {v13}, {v14}");

                //========================================================================================================
                Console.WriteLine("1.	Display the state and the number of customers for each state (Customers table).");
                var v15 = db.Customers.GroupBy(x => x.State).Select(x => new
                {
                    State = x.Key,
                    CountCustomers = x.Count()
                });
                foreach (var v in v15)
                {
                    //Console.WriteLine($"{v.State}, {v.CountCustomers}");
                }
                //======================

                Console.WriteLine("2.	Display the internet speed and the average monthly payment for each speed (Packages table).");
                var v16 = db.Packages.GroupBy(x => x.Speed).Select(x => new
                {
                    Speed = x.Key,
                    AvgMontlypayment = x.Average(y => y.MonthlyPayment)
                });
                foreach (var v in v16)
                {
                    Console.WriteLine($"{v.Speed}, {v.AvgMontlypayment}");
                }
                //=======================

                Console.WriteLine("3.	Display the state and the number of distinct cities for each state (Customers table).");
                var v17 = db.Customers.GroupBy(x => x.State).Select(x => new
                {
                    State = x.Key,
                    DistinctCtities = x.Select(y=>y.City).Distinct().Count()
                });
                foreach (var v in v17)
                {
                    //Console.WriteLine($"{v.State}{v.DistinctCtities}");
                    
                }
                //==================

                Console.WriteLine("4.	Display the sector number and the highest monthly payment for each sector (Packages table).");
                var v18 = db.Packages.GroupBy(x => x.Sector).Select(x => new
                {
                    SectorsNumber = x.Key.SectorName,
                    HighMontlyPayment = x.Max(y=> y.MonthlyPayment)
                });
                foreach (var v in v18)
                {
                    Console.WriteLine($"{v.SectorsNumber}, {v.HighMontlyPayment}");   
                }

            }

            Console.ReadKey();
        }
    }
}
