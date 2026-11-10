// 5. الفئة المسؤولة عن إدارة مركز الصيانة
public class RepairCenter
{
    // قائمة الأجهزة
    private List<Appliance> appliances;

    public RepairCenter()
    {
        appliances = new List<Appliance>();
    }

    // إضافة جهاز إلى المركز
    public void AddAppliance(Appliance appliance)
    {
        if (appliance == null)
        {
            Console.WriteLine("Invalid appliance!");
            return;
        }

        // منع تكرار الرقم التسلسلي
        foreach (Appliance item in appliances)
        {
            if (item.SerialNumber == appliance.SerialNumber)
            {
                Console.WriteLine(
                    "Serial number already exists!"
                );
                return;
            }
        }

        // الاشتراك بالحدث
        appliance.StatusChanged += ShowNotification;

        appliances.Add(appliance);
    }

    // الدالة التي تستقبل إشعارات الأجهزة
    private void ShowNotification(
        string serialNumber,
        string message)
    {
        Console.WriteLine();
        Console.WriteLine("===== NOTIFICATION =====");
        Console.WriteLine("Serial Number: " + serialNumber);
        Console.WriteLine("Message: " + message);
        Console.WriteLine("=======================");
        Console.WriteLine();
    }

    // عرض جميع الأجهزة
    public void DisplayAppliances()
    {
        Console.WriteLine();
        Console.WriteLine("===== APPLIANCE LIST =====");

        foreach (Appliance appliance in appliances)
        {
            Console.WriteLine(
                "Type: " + appliance.GetType().Name
            );

            Console.WriteLine(
                "Serial Number: " + appliance.SerialNumber
            );

            Console.WriteLine(
                "Brand: " + appliance.Brand
            );

            Console.WriteLine(
                "Status: " + appliance.GetStatus()
            );

            Console.WriteLine(
                "Delivery Date: " +
                appliance.DeliveryDate.ToShortDateString()
            );

            Console.WriteLine(
                "Repair Cost: " +
                appliance.CalculateRepairCost()
            );

            Console.WriteLine("--------------------------");
        }
    }

    // عضو ثابت لحساب عدد الأجهزة حسب الحالة
    public static int CountByStatus(
        List<Appliance> applianceList,
        string requiredStatus)
    {
        int count = 0;

        foreach (Appliance appliance in applianceList)
        {
            if (appliance.Status == requiredStatus)
            {
                count++;
            }
        }

        return count;
    }

    // عضو ثابت لحساب التكلفة الإجمالية
    public static decimal CalculateTotalCost(
        List<Appliance> applianceList)
    {
        decimal total = 0;

        foreach (Appliance appliance in applianceList)
        {
            total += appliance.CalculateRepairCost();
        }

        return total;
    }

    // إعادة قائمة الأجهزة
    public List<Appliance> GetAppliances()
    {
        return new List<Appliance>(appliances);
    }

    // فحص جميع الأجهزة المتأخرة
    public void CheckAllDeliveryDates()
    {
        foreach (Appliance appliance in appliances)
        {
            appliance.CheckDeliveryDate();
        }
    }

    // عرض إحصائيات المركز
    public void DisplayStatistics()
    {
        Console.WriteLine();
        Console.WriteLine("===== REPAIR CENTER STATISTICS =====");

        Console.WriteLine(
            "Total Appliances: " + appliances.Count
        );

        Console.WriteLine(
            "Under Maintenance: " +
            CountByStatus(
                appliances,
                "Under Maintenance"
            )
        );

        Console.WriteLine(
            "Repaired: " +
            CountByStatus(appliances, "Repaired")
        );

        Console.WriteLine(
            "Delivered: " +
            CountByStatus(appliances, "Delivered")
        );

        Console.WriteLine(
            "Total Repair Cost: " +
            CalculateTotalCost(appliances)
        );
    }
}