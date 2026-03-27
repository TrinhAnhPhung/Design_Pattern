using System;
using NOPKIEMTRA.Project.Models;
// Bài 1
// FruitJuice bananaJuice = new Banana();
// FruitJuice strawberryJuice = new Strawberry();
// FruitJuice mangoJuice = new Mango();
// bananaJuice.Print();
// strawberryJuice.Print();
// mangoJuice.Print();

// Bài 2 - Decorator Pattern
// IElectricBill bill = new ElectricBillCalculator(250); // 250 kWh
// bill = new DiscountDecorator(bill);
// bill = new IssuedNotificationDecorator(bill);

// Console.WriteLine("===== Hóa Đơn Điện =====");
// bill.Display();
// Console.WriteLine($"Tiền cuối cùng: {bill.CalculateBill():N0} đồng\n");


// Bài 3 - Prototype Pattern với Binary Search Tree
// Console.WriteLine("\n===== Bài 3: Binary Search Tree - Prototype Pattern =====");
// BinarySearchTree bst = new BinarySearchTree();

// // Insert values
// int[] values = { 50, 30, 70, 20, 40, 60, 80 };
// foreach (int val in values)
// {
//     bst.Insert(val);
// }

// Console.WriteLine("Tree gốc:");
// bst.Display();
// bst.Inorder();

// // Sử dụng Prototype Pattern - Clone tree
// BinarySearchTree clonedBst = bst.CloneTree();
// Console.WriteLine("\nTree sau khi clone:");
// clonedBst.Display();
// clonedBst.Inorder();

// // Search
// Console.WriteLine("\nSearch 40: " + (bst.Search(40) ? "Tìm thấy" : "Không tìm thấy"));
// Console.WriteLine("Search 100: " + (bst.Search(100) ? "Tìm thấy" : "Không tìm thấy"));


// Bài 4 - Composite Pattern & Adapter Pattern
Console.WriteLine("\n===== Bài 4: Composite Pattern - Quản Lý Nhân Viên =====");

// Tạo công ty với cấu trúc phân cấp
Director directorMain = new Director(1, "Nguyễn Văn A", 22, 500000, 0.1);

// Manager cấp 1
Manager manager1 = new Manager(2, "Trần Thị B", 22, 300000);
Manager manager2 = new Manager(3, "Lê Văn C", 22, 300000);

// Constructor
Constructor constructor1 = new Constructor(4, "Phạm Minh D", 22, 200000, 5000000);
Constructor constructor2 = new Constructor(5, "Hoàng Thanh E", 22, 200000, 5000000);
Constructor constructor3 = new Constructor(6, "Võ Kim F", 22, 200000, 5000000);

// Sub-director
Director subDirector = new Director(7, "Đỗ Nhân G", 22, 400000, 0.05);

// Xây dựng cấu trúc
directorMain.AddSubordinate(manager1);
directorMain.AddSubordinate(manager2);
directorMain.AddSubordinate(subDirector);

manager1.ShowDetails();
Console.WriteLine($"Lương Manager1: {manager1.GetSalary():N0} đồng\n");

manager2.ShowDetails();
Console.WriteLine($"Lương Manager2: {manager2.GetSalary():N0} đồng\n");

constructor1.ShowDetails();
Console.WriteLine($"Lương Constructor1: {constructor1.GetSalary():N0} đồng\n");

// Sub-director quản lý constructor
subDirector.AddSubordinate(constructor1);
subDirector.AddSubordinate(constructor2);
subDirector.AddSubordinate(constructor3);

Console.WriteLine($"Lương SubDirector: {subDirector.GetSalary():N0} đồng\n");

// Sử dụng Adapter để hiển thị lương công ty
SalaryAdapter.DisplayCompanySalary(directorMain);