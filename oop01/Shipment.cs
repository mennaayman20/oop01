

namespace oop01
{
    public struct Shipment
    {
        // Private Fields
        private string _trackingCode;
        private string _description;
        private double _weight;
        private decimal _deliveryFee;

        // Properties with Encapsulation & Validation

        // Read-only from outside
        public string TrackingCode => _trackingCode;

        // Read/Write with Validation
        public string Description
        {
            get => _description;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _description = value;
                }
            }
        }

        // Read/Write with Validation
        public double Weight
        {
            get => _weight;
            set
            {
                if (value > 0)
                {
                    _weight = value;
                }
            }
        }

        // Public getter and private setter
        public decimal DeliveryFee
        {
            get => _deliveryFee;
            private set
            {
                if (value > 0)
                {
                    _deliveryFee = value;
                }
            }
        }

        public DeliveryAddress Destination { get; set; }

        public decimal EstimatedCost => DeliveryFee + (decimal)(Weight * 5);


        public Shipment(string trackingCode)
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
            {
                _trackingCode = "UNKNOWN";
            }
            else
            {
                _trackingCode = trackingCode;
            }

            _description = "Unknown";
            _weight = 1;
            _deliveryFee = 50;
            Destination = new DeliveryAddress("Default City", "Default Street", 1);
        }

 
        public Shipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress destination)
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
            {
                _trackingCode = "UNKNOWN";
            }
            else
            {
                _trackingCode = trackingCode;
            }

            _description = !string.IsNullOrWhiteSpace(description) ? description : "Unknown";
            _weight = weight > 0 ? weight : 1;
            _deliveryFee = deliveryFee > 0 ? deliveryFee : 50;
            Destination = destination;
        }

 
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                _deliveryFee = newFee;
            }
        }


        public void PrintShipment()
        {
            Console.WriteLine($"Tracking Code: {TrackingCode}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Weight: {Weight} KG");
            Console.WriteLine($"Delivery Fee: {DeliveryFee} EGP");
            Console.WriteLine($"Destination: {Destination.GetFullAddress()}");
            Console.WriteLine($"Estimated Cost: {EstimatedCost} EGP\n");
        }
    }
}
