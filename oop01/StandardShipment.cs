namespace oop01
{
    internal class StandardShipment : Shipment
    {
        // Constructor Chaining(base constructor)
        public StandardShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override void PrintShipment()
        {
            base.PrintShipment();

        }

    }
}
