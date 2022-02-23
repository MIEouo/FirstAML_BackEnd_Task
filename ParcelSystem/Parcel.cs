namespace ParcelSystem;

public class Parcel
{
    private int size;
    private double weight;
    private int sizeCategory;
    private double price;

    public Parcel(int size, double weight)
    {
        this.size = size;
        this.weight = weight;
        this.sizeCategory = ParcelSystem.SizeCategory.defineSizeCategory(size);
        calculateParcelPrice();
    }

    public Parcel(double price)
    {
        this.price = price;
    }

    public int Size
    {
        get => size;
        set => size = value;
    }

    public double Weight
    {
        get => weight;
        set => weight = value;
    }

    public int SizeCategory
    {
        get => sizeCategory;
        set => sizeCategory = ParcelSystem.SizeCategory.defineSizeCategory(size);
    }

    public double Price
    {
        get => price;
        set => price = value;
    }

    //Normal parcel price and overweight parcel price calculator
    private void calculateParcelPrice() 
    {
        double weightLimit;
        int overWeightPrice = 2;
        switch (sizeCategory)
        {
            case 0:
                weightLimit = ParcelSystem.SizeCategory.smallWeightLimitation;
                this.price = 3;
                break;
            case 1:
                weightLimit = ParcelSystem.SizeCategory.mediumWeightLimitation;
                this.price = 8;
                break;
            case 2:
                weightLimit = ParcelSystem.SizeCategory.largeWeightLimitation;
                this.price = 15;
                break;
            case 3:
                weightLimit = ParcelSystem.SizeCategory.xlWeightLimitation;
                this.price = 25;
                break;
            default:
                throw new Exception();
        }

        if (this.weight - weightLimit > 0)
        {
            this.price += (this.weight - weightLimit) * overWeightPrice;
        }
        
    }

}