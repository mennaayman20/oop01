using System;
using System.Collections.Generic;
using System.Text;

namespace oop01.Extensions
{
    public static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            return $"{shipment.TrackingCode} | {shipment.Description} | {shipment.Weight} KG | {shipment.TrackingStatus}";
        }

        public static bool IsDelivered(this Shipment shipment)
        {
            return shipment.TrackingStatus.Equals("Delivered", StringComparison.OrdinalIgnoreCase);
        }
    }
}
