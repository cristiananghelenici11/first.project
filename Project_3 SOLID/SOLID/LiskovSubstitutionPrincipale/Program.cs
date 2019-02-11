using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrincipale
{
    class Program
    {
        static void Main(string[] args)
        {
//
//            Vehicle vehicle = new Bus();
//            vehicle.Speed = 9;
//
//            vehicle = new Car();
//            vehicle.CubicCapacity = 2;
            ///
            ///
            ///
            ///
            ///
            ///  

            List<Employee> list = new List<Employee>();

            list.Add(new SeniorEmployee());
            list.Add(new JuniorEmployee());

            foreach (Employee emp in list)
            {
                emp.GetWorkDetails(985);
            }

            Console.ReadKey();

        }
     
    }
    //

    public abstract class Employee
    {
        public virtual string GetWorkDetails(int id)
        {
            return "Base Work";
        }

        public virtual string GetEmployeeDetails(int id)
        {
            return "Base Employee";
        }
    }

    public class SeniorEmployee : Employee
    {
        public override string GetWorkDetails(int id)
        {
            return "Senior Work";
        }

        public override string GetEmployeeDetails(int id)
        {
            return "Senior Employee";
        }
    }

    public class JuniorEmployee : Employee
    {
        // Допустим, для Junior’a отсутствует информация
        public override string GetWorkDetails(int id)
        {
            throw new NotImplementedException();        }

        
        public override string GetEmployeeDetails(int id)
        {
            return "Junior Employee";

        }
    }

    //
    
}
