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



































    }
}