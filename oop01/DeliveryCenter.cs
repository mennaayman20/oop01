
namespace oop01
{
    public class DeliveryCenter
    {

        public string CenterName { get; set; }
        private Shipment[] _shipments = new Shipment[20];
        private int _count = 0;
        public DeliveryCenter()
        {
            _shipments = new Shipment[10];
            _count = 0;
        }

        public DeliveryCenter(string centerName)
        {
            CenterName = centerName;
        }
        public Shipment this[int index]
        {
            get
            {
                if (index >= 0 && index < _count)
                {
                    return _shipments[index];
                }
                return default;
            }
            set
            {
                if (index >= 0 && index < _count)
                {
                    _shipments[index] = value;
                }
            }
        }

        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < _count; i++)
                {
                    if (_shipments[i].TrackingCode.Equals(trackingCode, StringComparison.OrdinalIgnoreCase))
                    {
                        return _shipments[i];
                    }
                }
                return default;
            }
        }
        public bool AddShipment(Shipment shipment)
        {
            if (_shipments == null)
            {
                _shipments = new Shipment[10];
            }

            if (_count < 10)
            {
                _shipments[_count] = shipment;
                _count++;
                return true;
            }
            return false;
        }


        public bool RemoveShipment(string trackingCode)
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
                return false;

            for (int i = 0; i < _count; i++)
            {
                if (_shipments[i].TrackingCode.Equals(trackingCode, StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = i; j < _count - 1; j++)
                    {
                        _shipments[j] = _shipments[j + 1];
                    }

                    _shipments[_count - 1] = null;
                    _count--;
                    return true;
                }
            }

            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine($"==========================================");
            Console.WriteLine($"Delivery Center : {CenterName}");
            Console.WriteLine($"==========================================");

            if (_count == 0)
            {
                Console.WriteLine("No shipments available.");
                return;
            }
            //Dynamic Binding
            for (int i = 0; i < _count; i++)
            {
                _shipments[i].PrintShipment();
                Console.WriteLine("------------------------------------------");
            }
        }











    }
}

