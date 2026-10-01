
namespace oop01
{
    public class DeliveryCenter
    {
        private Shipment[] _shipments;
        private int _count;

        public DeliveryCenter()
        {
            _shipments = new Shipment[10];
            _count = 0;
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
    }
}
