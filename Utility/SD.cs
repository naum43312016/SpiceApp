using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiceApp.Utility
{
    public static class SD
    {
        public const string DefaultFoodImage = "default_food.png";
        public const string ManagerUser = "Manager";
        public const string KitchenUser = "Kitchen";
        public const string FrontDesk = "FrontDesk";
        public const string CustomerEndUser = "Customer";


        public const string StatusSubmitted = "Submitted";
        public const string StatusInProcess = "Being Prepared";
        public const string StatusReady = "Ready For Pickup";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";
        public const string StatusPending = "Pending";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusRejected = "Rejected";
    }
}
