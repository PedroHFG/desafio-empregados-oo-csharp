using Course.Entities;
using System.Globalization;

namespace Course
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nome do Departamento: ");
            string departmentName = Console.ReadLine();
            Console.Write("Dia do pagamento: ");
            int payDay = int.Parse(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Telefone: ");
            string phone = Console.ReadLine();
            Address address = new Address(email, phone);
            Department dept = new Department(departmentName, payDay, address);

            Console.Write("Quantos funcionários tem o departamento? ");
            int empQuantity = int.Parse(Console.ReadLine());

            for (int i = 1; i <= empQuantity; i++)
            {
                Console.WriteLine($"Dados do funcionário {i}: ");
                Console.Write("Nome: ");
                string employeeName = Console.ReadLine();
                Console.Write("Salário: ");
                double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Employee emp = new Employee(employeeName, salary);

                dept.AddEmployee(emp);
            }

            ShowReport(dept);
        }

        static void ShowReport(Department dept)
        {
            Console.WriteLine();
            Console.WriteLine("FOLHA DE PAGAMENTO:");
            Console.WriteLine("Departamento " + dept.Name + " = R$ " + dept.PayRoll().ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Pagamento realizado no dia " + dept.PayDay);
            Console.WriteLine("Funcionários:");

            foreach (Employee emp in dept.Employees)
            {
                Console.WriteLine(emp.Name);
            }

            Console.WriteLine("Para dúvidas favor entrar em contato: " + dept.Address.Email);
        }
    }
}
