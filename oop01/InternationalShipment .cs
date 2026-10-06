using oop01.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace oop01
{
  public class InternationalShipment : Shipment, IInsurable
    {
        private string _destinationCountry;
        private decimal _customsFee;

        public string DestinationCountry
        {
            get => _destinationCountry;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _destinationCountry = value;
                }
            }
        }

        public decimal CustomsFee
        {
            get => _customsFee;
            set
            {
                if (value >= 0)
                {
                    _customsFee = value;
                }
            }
        }
        //Constructor Chaining (base constructor)
        public InternationalShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            string destinationCountry,
            decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        //Override EstimatedCost
        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + CustomsFee;

        // Implement IInsurable interface
        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.12m;
        }

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("Generating standard customs report...");
        }



        public override void PrintShipment()
        {
            Console.WriteLine($"[Completed Shipment] Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} KG");
            Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP\n");
            Console.WriteLine($"Destination Country: {DestinationCountry}");
            Console.WriteLine($"Customs Fee: {CustomsFee:C}");
        }


    }
}
