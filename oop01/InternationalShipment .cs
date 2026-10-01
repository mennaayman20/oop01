using System;
using System.Collections.Generic;
using System.Text;

namespace oop01
{
    internal class InternationalShipment : Shipment
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

        public override decimal EstimatedCost => base.EstimatedCost + CustomsFee;

    }
}
