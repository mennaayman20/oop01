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
            #region Q1 a) What happens when a DeliveryAddress variable is copied into another variable and the copy is modified?
            // A complete value copy of the struct instance is created.
            // Modifying the copied variable will not affect the original variable.
            #endregion

            #region Q1 b) What happens when a Customer variable is copied into another variable and one variable modifies the object?
            // A reference copy of the class instance is created.
            // Modifying the copied variable will affect the original variable.
            #endregion

            #region Q2 a) Identify at least three problems with this design from an encapsulation perspective.
            // Public Fields, Lack of Data Validation, Immutability
            #endregion

            #region Q2 b) How can private fields and public properties improve this design?
            // Validation, Protection, Controlled Access Control
            #endregion

            #region Practical Application

            // a. Create DeliveryCenter
            DeliveryCenter center = new DeliveryCenter();

            // b & c. Read data for three shipments and add them
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Enter Shipment {i} Data");

                Console.Write("Tracking Code: ");
                string code = Console.ReadLine();

                Console.Write("Description: ");
                string desc = Console.ReadLine();

                Console.Write("Weight: ");
                double weight = double.Parse(Console.ReadLine());

                Console.Write("Delivery Fee: ");
                decimal fee = decimal.Parse(Console.ReadLine());

                Console.Write("City: ");
                string city = Console.ReadLine();

                Console.Write("Street: ");
                string street = Console.ReadLine();

                Console.Write("Building Number: ");
                int bNo = int.Parse(Console.ReadLine());

                DeliveryAddress address = new DeliveryAddress(city, street, bNo);
                Shipment shipment = new Shipment(code, desc, weight, fee, address);

                if (center.AddShipment(shipment))
                {
                    Console.WriteLine("\nShipment added successfully.\n");
                }
            }

            // d. Print the three shipments using the integer indexer
            Console.WriteLine("--- All Shipments ---");
            for (int i = 0; i < 3; i++)
            {
                center[i].PrintShipment();
            }

            //  Search for the shipment using the string indexer
            Console.Write("Enter a tracking code to search: ");
            string searchCode = Console.ReadLine();

            Shipment found = center[searchCode];

            if (!string.IsNullOrEmpty(found.TrackingCode))
            {
                Console.WriteLine($"Shipment found: {found.TrackingCode} - {found.Description}\n");
            }
            else
            {
                Console.WriteLine("Shipment not found.\n");
            }

            // h. Demonstrate the DeliveryAddress struct copy behavior
            Console.WriteLine("--- Struct Copy Test ---");
            DeliveryAddress originalAddr = new DeliveryAddress("Cairo", "Tahrir Street", 15);
            DeliveryAddress copiedAddr = originalAddr; // Value copy

            // Modify the copy
            copiedAddr.City = "Cairo";
            copiedAddr.Street = "Makram Ebeid Street";
            copiedAddr.BuildingNumber = 20;

            Console.WriteLine($"Original Address: {originalAddr.GetFullAddress()}");
            Console.WriteLine($"Copied Address: {copiedAddr.GetFullAddress()}");

            #endregion

        }
    }
}