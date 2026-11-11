// 6. البرنامج الرئيسي
class Program
{
    static void Main(string[] args)
    {
        // إنشاء مركز الصيانة
        RepairCenter center = new RepairCenter();

        // إنشاء ثلاثة أجهزة
        Refrigerator refrigerator = new Refrigerator(
            "R001",
            "Samsung",
            DateTime.Today.AddDays(2)
        );

        WashingMachine washingMachine = new WashingMachine(
            "W001",
            "LG",
            DateTime.Today.AddDays(3)
        );

        AirConditioner airConditioner = new AirConditioner(
            "A001",
            "Gree",
            DateTime.Today.AddDays(-1)
        );

        // إضافة الأجهزة إلى المركز
        center.AddAppliance(refrigerator);
        center.AddAppliance(washingMachine);
        center.AddAppliance(airConditioner);

        // عرض الأجهزة
        center.DisplayAppliances();

        // تغيير حالة الثلاجة إلى تم الإصلاح
        refrigerator.ChangeStatus("Repaired");

        // تسليم الثلاجة
        refrigerator.ChangeStatus("Delivered");

        // فحص الأجهزة المتأخرة
        center.CheckAllDeliveryDates();

        // عرض الإحصائيات
        center.DisplayStatistics();

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
}