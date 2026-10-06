using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Security.Cryptography;

namespace oop01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // G-NET-100-OOP-02

            #region Q1 a) What is the difference between a class and a struct? 
            //class=> Reference type, supports inheritance, allocated on the heap,suitable for large data.
            //struct=> Value type, does not support inheritance, allocated on the stack suitable for small data.
            #endregion

            #region Q1 b) ) Why are classes more suitable than structs for large applications?
            // Classes are reference types and are allocated on the heap, making them more suitable for large applications where memory management is crucial. They also support inheritance and polymorphism, which are essential for building scalable and maintainable applications.
            #endregion

            #region Q2 a) Which class is the parent class? 
            //Shipment
            #endregion


            #region Q2 b) Which class is the child class?
            //ExpressShipment
            #endregion

            #region Q2 c) What members are inherited by ExpressShipment?
            //ExpressShipment inherits all public and protected members of the Shipment class, including properties, methods, and fields.
            #endregion

            #region Q2 d) Why is inheritance better than duplicating the same code in multiple classes? 
            // Inheritance promotes code reusability and maintainability. By inheriting from a parent class, child classes can reuse existing code,
            // reducing redundancy and the potential for errors. It also allows for easier updates and modifications, as changes made in the parent class automatically propagate to child classes.
            #endregion


            //Part 02 : Practical

            Console.Write("Enter Delivery Center Name: ");
            string centerName = Console.ReadLine();
            DeliveryCenter center = new DeliveryCenter(centerName);

            DeliveryAddress address = new DeliveryAddress("Cairo", "Main St", 10);

            Console.WriteLine("\n--- Standard Shipment Data ---");
            Console.Write("Tracking Code: ");
            string code1 = Console.ReadLine();
            Console.Write("Description: ");
            string desc1 = Console.ReadLine();
            Console.Write("Weight: ");
            decimal weight1 = decimal.Parse(Console.ReadLine());
            Console.Write("Delivery Fee: ");
            decimal fee1 = decimal.Parse(Console.ReadLine());

            StandardShipment standard = new StandardShipment(code1, desc1, weight1, fee1, address);

            Console.WriteLine("\n--- Express Shipment Data ---");
            Console.Write("Tracking Code: ");
            string code2 = Console.ReadLine();
            Console.Write("Description: ");
            string desc2 = Console.ReadLine();
            Console.Write("Weight: ");
            decimal weight2 = decimal.Parse(Console.ReadLine());
            Console.Write("Delivery Fee: ");
            decimal fee2 = decimal.Parse(Console.ReadLine());
            Console.Write("Extra Fee: ");
            decimal extraFee = decimal.Parse(Console.ReadLine());

            ExpressShipment express = new ExpressShipment(code2, desc2, weight2, fee2, address, extraFee);

            Console.WriteLine("\n--- International Shipment Data ---");
            Console.Write("Tracking Code: ");
            string code3 = Console.ReadLine();
            Console.Write("Description: ");
            string desc3 = Console.ReadLine();
            Console.Write("Weight: ");
            decimal weight3 = decimal.Parse(Console.ReadLine());
            Console.Write("Delivery Fee: ");
            decimal fee3 = decimal.Parse(Console.ReadLine());
            Console.Write("Destination Country: ");
            string country = Console.ReadLine();
            Console.Write("Customs Fee: ");
            decimal customsFee = decimal.Parse(Console.ReadLine());

            InternationalShipment international = new InternationalShipment(code3, desc3, weight3, fee3, address, country, customsFee);

            if (center.AddShipment(standard)) Console.WriteLine("\nShipment Added Successfully.");
            if (center.AddShipment(express)) Console.WriteLine("Shipment Added Successfully.");
            if (center.AddShipment(international)) Console.WriteLine("Shipment Added Successfully.");

            Console.WriteLine();
            center.PrintAllShipments();

            Console.Write("\nEnter Tracking Code to Search: ");
            string searchCode = Console.ReadLine();
            Shipment searchedShipment = center[searchCode];

            if (searchedShipment != null)
            {
                Console.WriteLine($"Shipment Found: {searchedShipment.TrackingCode} - {searchedShipment.Description}");
            }
            else
            {
                Console.WriteLine("Shipment Not Found!");
            }

            Console.Write("\nEnter Tracking Code to Remove: ");
            string removeCode = Console.ReadLine();

            if (center.RemoveShipment(removeCode))
            {
                Console.WriteLine("Shipment Removed Successfully.");
            }
            else
            {
                Console.WriteLine("Failed to remove shipment.");
            }

            Console.WriteLine("\n=========================");
            Console.WriteLine("Remaining Shipments");
            Console.WriteLine("===========================");

            for (int i = 0; i < 20 && center[i] != null; i++)
            {
                Console.WriteLine($"Tracking Code : {center[i].TrackingCode}");
            }




// G-NET-100-OOP-03

        //Q1  Overloading, Overriding, and Binding

        #region a)  What is the difference between Method Overloading and Method Overriding?
        // Method Overloading: It allows multiple methods in the same class to have the same name but different parameters (different type, number, or order of parameters).
        //method Overriding: It allows a subclass to provide a specific implementation of a method that is already defined in its superclass. The method in the subclass must have the same name, return type, and parameters as the method in the superclass.
        #endregion

        #region b)  What is the difference between Static Binding and Dynamic Binding?
        //static Binding: It occurs at compile time, where the method to be called is determined based on the reference type. It is associated with method overloading and early binding.
        //Dynamic Binding: It occurs at runtime, where the method to be called is determined based on the actual object type. It is associated with method overriding and late binding.
        #endregion

        //Q2  Sealed Classes and Methods
        #region a)  What is the purpose of the sealed keyword when applied to a class?
        // The sealed keyword is used to prevent a class from being inherited. When a class is marked as sealed, it cannot serve as a base class for any other class. This is useful when you want to restrict the inheritance hierarchy and ensure that the implementation of the class remains unchanged.
        #endregion

        #region b)  What is the difference between a sealed class and a sealed method?
        // A sealed class is a class that cannot be inherited by any other class. When a class is marked as sealed, it cannot serve as a base class for any other class.
        // A sealed method is a method that cannot be overridden by any subclass. When a method is marked as sealed, it can be overridden by subclasses, but those subclasses cannot override it again.
        #endregion

        #region c)  Can a sealed method be overridden? Why?
        // No, a sealed method cannot be overridden.
        // The purpose of sealing a method is to prevent further overriding in derived classes. This ensures that the implementation of the method remains fixed and cannot be changed by subclasses, which can be important for maintaining consistent behavior and preventing unintended side effects in the class hierarchy.
        #endregion

        Driver driver = new Driver("Ahmed Mohamed");

        DeliveryCenter centerr = new DeliveryCenter("Cairo Central Hub");

        centerr.Driver = driver;


            StandardShipment Standard = new StandardShipment(
                "SH001",
                "Books and Stationery",
                10.0m,
                50.0m,
                new DeliveryAddress("123 Main St", "Cairo", 9)
            );


            ExpressShipment Express = new ExpressShipment(
                "SH002",
                "Mobile Phone",
                2.5m,
                30.0m,
                new DeliveryAddress("456 Nile St", "Giza", 10),
                15.0m // ExtraFee
            );


            InternationalShipment International = new InternationalShipment(
                "SH003",
                "Laptop",
                3.0m,
                100.0m,
                new DeliveryAddress("789 Berlin Rd", "Berlin", 11),
                "Germany", // Destination Country
                50.0m      // CustomsFee
            );

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);
            Console.WriteLine("--- Printing All Shipments from Delivery Center ---");
            center.PrintAllShipments();

            Console.WriteLine("\n--- Printing Details Using DeliveryHelper ---");
            DeliveryHelper.PrintShipmentDetails(standard);
            DeliveryHelper.PrintShipmentDetails(express);
            DeliveryHelper.PrintShipmentDetails(international);

            Console.WriteLine("\n--- Demonstrating UpdateWeight() Overloads ---");
            Console.WriteLine($"Original Weight: {standard.Weight} kg");

            standard.UpdateWeight(12.5m);
            Console.WriteLine($"Updated Weight (Direct): {standard.Weight} kg");

            standard.UpdateWeight(12.5m, 1.5m);
            Console.WriteLine($"Updated Weight (With Extra Packing): {standard.Weight} kg");

           
            Console.WriteLine("\n--- Printing Mixed Shipment Array (Dynamic Binding Loop) ---");
            Shipment[] mixedShipments = new Shipment[]
            {
                standard,
                express,
                international,
                new CompletedShipment("SH004", "Delivered Parcel", 1.0m, 20.0m, new DeliveryAddress("Cairo", "Egypt",8))
            };

            foreach (Shipment s in mixedShipments)
            {
                // يتم استدعاء الدالة الخاصة بكل نوع تلقائياً في وقت التشغيل (Runtime)
                s.PrintShipment();
                Console.WriteLine("------------------------------------------");
            }

            // l. Demonstrate the sealed class and sealed method (comments or code)
            // توضيح مفاهيم الـ Sealed Class والـ Sealed Method
            Console.WriteLine("\n--- Demonstrating Sealed Class & Sealed Method ---");

            // 1. Sealed Class Demonstration:
            // الكلاس CompletedShipment مغلق بـ sealed وبالتالي لا يمكن الوراثة منه.
            CompletedShipment completed = new CompletedShipment("SH005", "Finished Order", 5.0m, 40.0m, new DeliveryAddress("Alexandria", "Egypt",11));
            completed.PrintShipment();
            // ملاحظة: لو حاولنا كتابة: class SubCompleted : CompletedShipment {} سيعطي الكومبايلر خطأ.

            // 2. Sealed Method Demonstration:
            // الكلاس PriorityInternationalShipment يحتوي على دالة GenerateCustomsReport() مغلقة بـ sealed override.
            PriorityInternationalShipment priorityInt = new PriorityInternationalShipment(
                "SH006",
                "Medical Equipment",
                8.0m,
                200.0m,
                new DeliveryAddress("Paris St", "Paris", 12),
                "France",
                100.0m
            );

            // استدعاء الدالة المختومة
            priorityInt.GenerateCustomsReport();
            // ملاحظة: إذا ورث كلاس آخر من PriorityInternationalShipment، لن يستطيع إعادة تعريف (override) لهذه الدالة.
        }




        // G-NET-100-OOP-04

        //Q1 Abstraction
        #region a)  What is Abstraction in Object-Oriented Programming?
        // Abstraction is a fundamental concept in object-oriented programming (OOP)
        // that focuses on exposing only the essential features of an object while hiding the unnecessary details.
        #endregion
        #region b)  Why is abstraction considered one of the four pillars of OOP?
        // Abstraction is considered one of the four pillars of OOP because it
        // allows developers to create simplified models of complex systems, making it easier to understand, design, and maintain software.

        #endregion

        //Q2 Abstract Classes vs. Interfaces
        #region a) What is the difference between an Abstract Class and an Interface?
        //abstract Class: An abstract class can have both abstract methods(without implementation) and concrete methods(with implementation).
        // and constructors.Abstract classes are used when there is a common base behavior that multiple derived classes can share.
        #endregion

        #region b)  When would you choose an Interface instead of an Abstract Class?
        //  to define a contract that multiple classes can implement, regardless of their position in the class hierarchy.
        //  Interfaces are ideal for defining capabilities that can be shared across unrelated classes, promoting flexibility and decoupling in your design.

        #endregion

        #region c)  Can a class inherit from multiple abstract classes? Can it implement multiple interfaces?
        // A class cannot inherit from multiple abstract classes due to the single inheritance model in C#. However,
        // a class can implement multiple interfaces, allowing it to inherit behavior from multiple sources.
        #endregion

















    }
}