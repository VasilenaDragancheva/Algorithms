namespace Salaries
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class Employee
    {
        public Employee(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }

        public BigInteger Salary { get; set; }
    }

    public class Program
    {
        public static Employee[] employees;

        public static List<int>[] managersAndEmployees;

        public static List<int> bosses;

        public static int count;

        public static void Main(string[] args)
        {
            count = int.Parse(Console.ReadLine());
            managersAndEmployees = new List<int>[count];
            employees = new Employee[count];
            bosses = Enumerable.Range(0, count).ToList();

            for (int r = 0; r < count; r++)
            {

                string line = Console.ReadLine();

                managersAndEmployees[r] = GetEmployeesId(line);

                employees[r] = new Employee(r);

                if (managersAndEmployees[r].Count == 0)
                {
                    employees[r].Salary = 1;
                }
                else
                {
                    foreach (var employee in managersAndEmployees[r])
                    {
                        bosses.Remove(employee);
                    }
                }
            }

            foreach (var boss in bosses)
            {
                CalculateSalary(boss);
            }

            RenderResult();

        }

        private static void RenderResult()
        {
            BigInteger sum = 0;
            foreach (var emp in employees)
            {
                sum += emp.Salary;
            }

            Console.WriteLine(sum);
        }

        private static List<int> GetEmployeesId(string line)
        {
            var index = new List<int>();
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == 'Y')
                {
                    index.Add(i);
                }
            }

            return index;
        }

        private static void CalculateSalary(int boss)
        {
            if (employees[boss].Salary == 1)
            {
                return;
            }

            foreach (var employee in managersAndEmployees[boss])
            {
                if (employees[employee].Salary == 0)
                {
                    CalculateSalary(employee);
                }
            }

            employees[boss].Salary = SumSalaries(boss);
        }

        private static BigInteger SumSalaries(int boss)
        {
            BigInteger sum = 0;

            foreach (var employee in managersAndEmployees[boss])
            {
                sum += employees[employee].Salary;
            }

            return sum;
        }
    }
}