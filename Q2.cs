// 3. الفئة المشتقة: الثلاجة
public class Refrigerator : Appliance
{
    public Refrigerator(
        string serialNumber,
        string brand,
        DateTime deliveryDate)
        : base(serialNumber, brand, deliveryDate)
    {
    }

    public override decimal CalculateRepairCost()
    {
        return 150m;
    }
}

// الفئة المشتقة: الغسالة
public class WashingMachine : Appliance
{
    public WashingMachine(
        string serialNumber,
        string brand,
        DateTime deliveryDate)
        : base(serialNumber, brand, deliveryDate)
    {
    }

    public override decimal CalculateRepairCost()
    {
        return 100m;
    }
}

// الفئة المشتقة: المكيف
public class AirConditioner : Appliance
{
    public AirConditioner(
        string serialNumber,
        string brand,
        DateTime deliveryDate)
        : base(serialNumber, brand, deliveryDate)
    {
    }

    public override decimal CalculateRepairCost()
    {
        return 200m;
    }
}