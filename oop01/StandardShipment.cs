using oop01.interfaces;

namespace oop01
{
    internal class StandardShipment : Shipment , IInsurable
    {
        // Constructor Chaining(base constructor)
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) ;


        public override void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} KG");
            Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP\n");

        }

        // Implement IInsurable interface
        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m;
        }

        public override string GetTrackingStatus() => $"Shipment {TrackingCode} is Ready.";
    }
}
