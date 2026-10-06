using System;

namespace oop01
{
    public class ExpressShipment : Shipment
    {
        private decimal _extraFee;
        public decimal ExtraFee
        {
            get { return _extraFee; }
            set
            {
                if (value >= 0)
                {
                    _extraFee = value;
                }
            }

        }
        //Constructor Chaining(base constructor)
        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal _extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = _extraFee;
        }

        //Override EstimatedCost
        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + ExtraFee;

        public override void PrintShipment()
        {

            Console.WriteLine($"[Completed Shipment] Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} KG");
            Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP\n");
            Console.WriteLine($"Extra Fee: {ExtraFee:C}");
        }




    }
}