using System;
using System.Collections.Generic;
using System.Text;

namespace oop01
{
    internal sealed class CompletedShipment : Shipment
    {
        public CompletedShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }


        public override decimal EstimatedCost => DeliveryFee + (Weight * 5);
        public override void PrintShipment()
        {
            Console.WriteLine($"[Completed Shipment] Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} KG");
            Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP\n");
        }

        public override string GetTrackingStatus() => $"Shipment {TrackingCode} has been Delivered.";
    }
}
