// Worker.cs - Interface
using System;
using System.Collections.Generic;

namespace NOPKIEMTRA.Project.Models
{
    public interface IWorker
    {
        void ShowDetails();
        long GetSalary();
    }

    // Constructor : Worker
    public class Constructor : IWorker
    {
        private long id;
        private string name;
        private int workingDay;
        private int salaryPerDay;
        private double baseSalary;

        public Constructor(long id, string name, int workingDay, int salaryPerDay, double baseSalary)
        {
            this.id = id;
            this.name = name;
            this.workingDay = workingDay;
            this.salaryPerDay = salaryPerDay;
            this.baseSalary = baseSalary;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Constructor: ID={id}, Name={name}, WorkingDay={workingDay}, SalaryPerDay={salaryPerDay}, BaseSalary={baseSalary:N0}");
        }

        public long GetSalary()
        {
            return (long)(baseSalary + workingDay * salaryPerDay);
        }
    }

    // Manager : Worker
    public class Manager : IWorker
    {
        private long id;
        private string name;
        private int workingDay;
        private int salaryPerDay;

        public Manager(long id, string name, int workingDay, int salaryPerDay)
        {
            this.id = id;
            this.name = name;
            this.workingDay = workingDay;
            this.salaryPerDay = salaryPerDay;
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Manager: ID={id}, Name={name}, WorkingDay={workingDay}, SalaryPerDay={salaryPerDay}");
        }

        public long GetSalary()
        {
            return workingDay * salaryPerDay;
        }
    }

    // Director : Worker (Composite)
    public class Director : IWorker
    {
        private long id;
        private string name;
        private int workingDay;
        private int salaryPerDay;
        private double bonus;
        private List<IWorker> subordinates; // Danh sách nhân viên quản lý

        public Director(long id, string name, int workingDay, int salaryPerDay, double bonus)
        {
            this.id = id;
            this.name = name;
            this.workingDay = workingDay;
            this.salaryPerDay = salaryPerDay;
            this.bonus = bonus;
            this.subordinates = new List<IWorker>();
        }

        public void AddSubordinate(IWorker worker)
        {
            subordinates.Add(worker);
        }

        public void RemoveSubordinate(IWorker worker)
        {
            subordinates.Remove(worker);
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Director: ID={id}, Name={name}, WorkingDay={workingDay}, SalaryPerDay={salaryPerDay}, Bonus={(bonus * 100):F1}%");
            Console.WriteLine("Subordinates:");
            foreach (var worker in subordinates)
            {
                Console.Write("  ");
                worker.ShowDetails();
            }
        }

        public long GetSalary()
        {
            return (long)(workingDay * salaryPerDay * (1 + bonus));
        }

        // Tính tổng lương của tất cả nhân viên trong công ty
        public long GetTotalSalary()
        {
            long totalSalary = GetSalary(); // Lương director

            foreach (var worker in subordinates)
            {
                if (worker is Director director)
                {
                    totalSalary += director.GetTotalSalary(); // Recursive
                }
                else
                {
                    totalSalary += worker.GetSalary();
                }
            }

            return totalSalary;
        }

        public List<IWorker> GetSubordinates()
        {
            return subordinates;
        }
    }

    // Adapter - Tính lương theo cách thức của công ty
    public class SalaryAdapter
    {
        public static void DisplayCompanySalary(Director director)
        {
            Console.WriteLine("\n===== Tính Lương Công Ty =====");
            director.ShowDetails();
            Console.WriteLine($"\nTổng lương công ty: {director.GetTotalSalary():N0} đồng");
        }
    }
}