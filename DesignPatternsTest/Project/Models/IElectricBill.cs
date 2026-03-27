// IElectricBill.cs - Component Interface
using System;

namespace NOPKIEMTRA.Project.Models
{
    public interface IElectricBill
    {
        double CalculateBill();
        void Display();
    }

    // ConcreteComponent - Tính tiền điện theo bậc thang
    public class ElectricBillCalculator : IElectricBill
    {
        private double _kwhUsed;

        public ElectricBillCalculator(double kwhUsed)
        {
            _kwhUsed = kwhUsed;
        }

        public double CalculateBill()
        {
            double totalBill = 0;

            if (_kwhUsed <= 100)
            {
                totalBill = _kwhUsed * 1000;
            }
            else if (_kwhUsed <= 200)
            {
                totalBill = 100 * 1000 + (_kwhUsed - 100) * 1200;
            }
            else if (_kwhUsed <= 300)
            {
                totalBill = 100 * 1000 + 100 * 1200 + (_kwhUsed - 200) * 1500;
            }
            else
            {
                totalBill = 100 * 1000 + 100 * 1200 + 100 * 1500 + (_kwhUsed - 300) * 2000;
            }

            return totalBill;
        }

        public void Display()
        {
            Console.WriteLine($"kWh sử dụng: {_kwhUsed}");
            Console.WriteLine($"Tiền điện: {CalculateBill():N0} đồng");
        }
    }

    // Decorator Base Class
    public abstract class ElectricBillDecorator : IElectricBill
    {
        protected IElectricBill _bill;

        public ElectricBillDecorator(IElectricBill bill)
        {
            _bill = bill;
        }

        public virtual double CalculateBill()
        {
            return _bill.CalculateBill();
        }

        public virtual void Display()
        {
            _bill.Display();
        }
    }

    // Decorator 1 - Giảm 5% nếu tổng tiền trong khoảng 500,000 - 1,000,000 đồng
    public class DiscountDecorator : ElectricBillDecorator
    {
        public DiscountDecorator(IElectricBill bill) : base(bill) { }

        public override double CalculateBill()
        {
            double bill = _bill.CalculateBill();
            
            if (bill >= 500000 && bill <= 1000000)
            {
                bill = bill * 0.95; // Giảm 5%
                Console.WriteLine($"Áp dụng giảm giá 5%: {bill:N0} đồng");
            }
            
            return bill;
        }
    }

    // Decorator 2 - Thêm thông báo hóa đơn đã được phát hành
    public class IssuedNotificationDecorator : ElectricBillDecorator
    {
        public IssuedNotificationDecorator(IElectricBill bill) : base(bill) { }

        public override void Display()
        {
            _bill.Display();
            Console.WriteLine("Hóa đơn đã được phát hành");
        }
    }
}