using oop01.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace oop01
{
    public abstract partial class Shipment : ITrackable
    {


        public string TrackingStatus { get; set; } = "In Transit";
        partial void OnTrackingStatusChanged(string newStatus);
        //  إرجاع حالة التتبع
        public string GetTrackingStatus()
        {
            return TrackingStatus;
        }

        //  تحديث حالة التتبع
        public void UpdateTrackingStatus(string newStatus)
        {
            if (!string.IsNullOrWhiteSpace(newStatus))
            {
                TrackingStatus = newStatus;
                Console.WriteLine($"Shipment {_trackingCode} tracking status updated to: {TrackingStatus}");

                OnTrackingStatusChanged(newStatus);

            }
        }










    }
}
