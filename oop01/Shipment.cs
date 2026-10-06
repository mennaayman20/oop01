namespace oop01
{
    public class Shipment
    {
        // Private Fields
        public string _trackingCode;
        public string _description;
        public decimal _weight;
        public decimal _deliveryFee;
        public DeliveryAddress Destination { get; set; }
        
        //default constructor
        public Shipment() { }

        // constructor overloading
        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            _trackingCode = string.IsNullOrWhiteSpace(trackingCode) ? "UNKNOWN" : trackingCode;
            _description = !string.IsNullOrWhiteSpace(description) ? description : "Unknown";
            _weight = weight > 0 ? weight : 1;
            _deliveryFee = deliveryFee > 0 ? deliveryFee : 50;
            Destination = destination;
        }

        //UpdateDeliveryFee() PrintShipment() =>>>already here


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
        public decimal Weight
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

        //Convert to a virtual property so each derived class can calculate its own cost.
        public virtual decimal EstimatedCost => DeliveryFee + (decimal)(Weight * 5);


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

 
        //public Shipment(string trackingCode, string description, double weight, decimal deliveryFee, DeliveryAddress destination)
        //{
        //    if (string.IsNullOrWhiteSpace(trackingCode))
        //    {
        //        _trackingCode = "UNKNOWN";
        //    }
        //    else
        //    {
        //        _trackingCode = trackingCode;
        //    }

        //    _description = !string.IsNullOrWhiteSpace(description) ? description : "Unknown";
        //    _weight = weight > 0 ? weight : 1;
        //    _deliveryFee = deliveryFee > 0 ? deliveryFee : 50;
        //    Destination = destination;
        //}

         //update delivery fee method
        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                _deliveryFee = newFee;
            }
        }

        //Convert to a virtual method.Every child class will override it
        public virtual void PrintShipment()
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
