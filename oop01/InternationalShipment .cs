using System;
using System.Collections.Generic;
using System.Text;

namespace oop01
{
  public class InternationalShipment : Shipment
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
        public override decimal EstimatedCost => base.EstimatedCost + CustomsFee;
        

        public virtual void GenerateCustomsReport()
        {
            Console.WriteLine("Generating standard customs report...");
        }



        public override void PrintShipment()
        {
            base.PrintShipment();
            Console.WriteLine($"Destination Country: {DestinationCountry}");
            Console.WriteLine($"Customs Fee: {CustomsFee:C}");
        }
    }
}
