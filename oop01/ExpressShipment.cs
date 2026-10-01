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
        public ExpressShipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination, decimal _extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = _extraFee;
        }

        public override decimal EstimatedCost => base.EstimatedCost + ExtraFee;




    }
}