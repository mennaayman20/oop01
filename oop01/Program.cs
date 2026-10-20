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


        //Part 02 — Practical

        // G-NET-100-OOP-05
        //Object Copying
        #region a) What happens when you assign one object variable to another object variable?
        // When you assign one object variable to another object variable, both variables refer to the same object in memory.
        // Any changes made through one variable will affect the other
        #endregion

        #region b) Does assigning one object to another create a new object? Explain.
        // No, assigning one object to another does not create a new object. Both variables refer to the same object in memory.
        #endregion

        #region c) What is the difference between copying an object and copying its reference?
        // Copying an object creates a new instance of the object with the same values,
        // while copying its reference means both variables point to the same object in memory. 
        #endregion

        //Shallow Copy vs Deep Copy

        #region a) What is a Shallow Copy?
        // A shallow copy creates a new object,
        // but it copies the references of the original object's fields rather than duplicating the actual objects those references point to.
        // As a result,changes made to the referenced objects in the shallow copy will affect the original object and vice versa.
        #endregion

        #region b) What is a Deep Copy?
        // A deep copy creates a new object and recursively copies all objects referenced by the original object.
        #endregion

        #region c) What happens to reference-type members when a Shallow Copy is created?
        // When a shallow copy is created, reference-type members of the original object are not duplicated;
        // instead, the new object contains references to the same instances as the original object.
        #endregion

        #region d) What happens to reference-type members when a Deep Copy is created?
        // When a deep copy is created, reference-type members of the original object are also duplicated,
        #endregion

        #region e) Give one situation where Deep Copy would be safer than Shallow Copy.
        // Deep Copy would be safer than Shallow Copy in situations where the original object contains mutable reference-type members (like lists or other objects) that should not be shared between the original and the copied object.
        // For example, if you have a class representing a shopping cart with a list of items, using a deep copy ensures that changes to the items in the copied cart do not affect the original cart.
        #endregion

        //Static Members
        #region a) What is a static field, and how is it different from an instance field?
        // A static field is a variable that belongs to the class itself rather than to any specific instance of the class. It is shared among all instances of the class,
        // meaning that there is only one copy of the static field regardless of how many objects are created from the class. In contrast,
        // an instance field is unique to each object created from the class, and each object has its own copy of the instance field.

        #endregion

        #region b) What is a static method? Can a static method directly access instance members?
        // A static method is a method that belongs to the class itself rather than to any specific instance of the class.
        // It can be called without creating an instance of the class.
        #endregion

        #region c) What is a static constructor, and when is it executed?
        // A static constructor is a special constructor that is used to initialize static members of a class.
        // It is executed automatically by the runtime before any static members are accessed or any instances of the class are created.
        #endregion

        #region d) What is a static class? Can you create an object from a static class?
        // A static class is a class that cannot be instantiated. It can only contain static members.
        // You cannot create an object from a static class.
        #endregion

        //Extension Methods

        #region a) What is an Extension Method?
        // An extension method allows you to add new methods to an existing type without modifying its original source code or creating a derived class.
        #endregion

        #region b) What keyword must be used in the first parameter of an extension method?
        // The this keyword must precede the first parameter type.
        #endregion

        #region c) Where must an extension method be declared?
        //An extension method must be declared inside a static class, and the method itself must be static.
        #endregion

        #region d) Can an extension method access private members of the class it extends?
        //No, an extension method cannot access private or protected members of the extended class;
        //it can only interact with its public interface.
        #endregion


        //Partial Classes and Partial Methods

        #region a) What is a Partial Class?
        //A partial class allows the definition of a single class to be split across multiple files using the partial keyword,
        //which are then combined into a single class at compile time.
        #endregion

        #region b) Why would a developer split one class into multiple files?
        //To organize large codebases, improve readability,
        //and separate automatically generated code from custom handwritten code.
        #endregion

        #region c) What is a Partial Method?
        //A partial method is a method whose signature is declared in one part of a partial class,
        //and its optional implementation can be provided in another part (or omitted entirely).
        #endregion

        #region d) What happens if a declared partial method has no implementation?
        //the compiler automatically removes the method declaration and any calls to it, resulting in zero performance overhead.
        #endregion

        //Part 02 — Practical

        StandardShipment shipment1 = new StandardShipment("SH001", "Books", 5.0m, 50.0m, new DeliveryAddress("Cairo", "Main St", 10));
            Shipment shipment2 = shipment1;

            Console.WriteLine("--- Demonstration of Reference Assignment ---");
            Console.WriteLine($"Original Shipment Code: {shipment1.TrackingCode}");
            Console.WriteLine($"Assigned Shipment Code: {shipment2.TrackingCode}");

            // عشان نثبت إنهم نفس الكائن في الذاكرة، بنستخدم ReferenceEquals:
            bool areTheyTheSameObject = ReferenceEquals(shipment1, shipment2);
            Console.WriteLine($"Are shipment1 and shipment2 the exact same object in memory? {areTheyTheSameObject}");
            // النتيجة هتكون True لأنهم نفس الشيء بالضبط!


            // 3. تجربة الـ Actual Copy (النسخ الحقيقي باستخدام CopyShipment):
            Shipment actualCopy = shipment1.CopyShipment();

            Console.WriteLine("\n--- Demonstration of Actual Copy ---");
            bool isTheCopyTheSameObject = ReferenceEquals(shipment1, actualCopy);
            Console.WriteLine($"Is shipment1 and the actualCopy the same object? {isTheCopyTheSameObject}");


            Shipment shallowCopied = shipment1.ShallowCopy();

            Console.WriteLine("--- Shallow Copy Demonstration ---");
            Console.WriteLine($"Original Address City: {shipment1.Destination.City}");
            Console.WriteLine($"Copied Address City: {shallowCopied.Destination.City}");

            // تغيير العنوان من خلال الشحنة المنسوخة
            // نعمل أوبجكت جديد للعنوان ونحطه في الـ Destination مباشرة
            shallowCopied.Destination = new DeliveryAddress("Giza", shallowCopied.Destination.Street, shallowCopied.Destination.BuildingNumber);
            Console.WriteLine($"Original Address City after change: {shipment1.Destination.City}"); // هتتغير لـ Giza!























        }






















    }
}