using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeApplianceRepairCenter
{
    // 1. Abstraction: واجهة العمليات المشتركة
    public interface IRepairable
    {
        string GetStatus();
        decimal CalculateRepairCost();
    }

    // تعريف التفويض الخاص بإشعارات تغير الحالة
    public delegate void StatusChangedHandler(
        string serialNumber,
        string message
    );

    // 2. الفئة الأساسية المجردة
    public abstract class Appliance : IRepairable
    {
        // حقول خاصة لتحقيق التغليف
        private readonly string serialNumber;
        private readonly string brand;
        private string status;
        private readonly DateTime deliveryDate;

        // الحدث الخاص بتغير حالة الجهاز
        public event StatusChangedHandler StatusChanged;

        // خصائص للقراءة فقط
        public string SerialNumber
        {
            get { return serialNumber; }
        }

        public string Brand
        {
            get { return brand; }
        }

        public string Status
        {
            get { return status; }
        }

        public DateTime DeliveryDate
        {
            get { return deliveryDate; }
        }

        // المنشئ
        protected Appliance(
            string serialNumber,
            string brand,
            DateTime deliveryDate)
        {
            if (!DataValidator.IsValidSerialNumber(serialNumber))
            {
                throw new ArgumentException(
                    "Invalid serial number"
                );
            }

            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new ArgumentException(
                    "Brand cannot be empty"
                );
            }

            this.serialNumber = serialNumber;
            this.brand = brand;
            this.deliveryDate = deliveryDate;

            // الحالة الافتراضية للجهاز
            this.status = "Under Maintenance";
        }

        // إرجاع حالة الجهاز
        public string GetStatus()
        {
            return status;
        }

        // دالة مجردة تحسب تكلفة الإصلاح
        public abstract decimal CalculateRepairCost();

        // تغيير حالة الجهاز
        public void ChangeStatus(string newStatus)
        {
            if (newStatus != "Under Maintenance" &&
                newStatus != "Repaired" &&
                newStatus != "Delivered")
            {
                Console.WriteLine("Invalid status!");
                return;
            }

            if (status == newStatus)
            {
                return;
            }

            status = newStatus;

            if (newStatus == "Repaired")
            {
                OnStatusChanged(
                    "Repair completed successfully."
                );
            }
            else if (newStatus == "Delivered")
            {
                OnStatusChanged(
                    "Appliance delivered successfully."
                );
            }
            else
            {
                OnStatusChanged(
                    "Appliance returned to maintenance."
                );
            }
        }

        // فحص التأخر عن موعد التسليم
        public void CheckDeliveryDate()
        {
            if (DateTime.Today > deliveryDate.Date &&
                status == "Under Maintenance")
            {
                OnStatusChanged(
                    "WARNING: Delivery is overdue!"
                );
            }
        }

        // إطلاق الحدث بطريقة متوافقة مع C# 5
        protected virtual void OnStatusChanged(string message)
        {
            if (StatusChanged != null)
            {
                StatusChanged(serialNumber, message);
            }
        }
    }