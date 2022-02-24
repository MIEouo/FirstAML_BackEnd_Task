namespace ParcelSystem;

public class Parcel
{
    private int size;
    private double weight;
    private int sizeCategory;
    private double price;
    private int pricingFactor;

    public Parcel(int size, double weight)
    {
        this.size = size;
        this.weight = weight;
        this.sizeCategory = ParcelSystem.SizeCategory.defineSizeCategory(size);
        calculateParcelPrice();
    }

    //only for creating parcel with overriden price.
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
    
    //Normal parcel, overweight parcel and heavy parcel price calculator
    private void calculateParcelPrice()
    {
        double weightLimit;
        
        //define size category: weight limitation, original price, pricing factor.
        switch (sizeCategory) //step 1
        {
            case 0: //small
                weightLimit = ParcelSystem.SizeCategory.smallWeightLimitation;
                this.price = 3;
                pricingFactor = ParcelSystem.SizeCategory.standardOverweightPrice;
                break;
            case 1: //medium
                weightLimit = ParcelSystem.SizeCategory.mediumWeightLimitation;
                this.price = 8;
                pricingFactor = ParcelSystem.SizeCategory.standardOverweightPrice;
                break;
            case 2: //large
                weightLimit = ParcelSystem.SizeCategory.largeWeightLimitation;
                this.price = 15;
                pricingFactor = ParcelSystem.SizeCategory.standardOverweightPrice;
                break;
            case 3: //xl
                weightLimit = ParcelSystem.SizeCategory.xlWeightLimitation;
                this.price = 25;
                pricingFactor = ParcelSystem.SizeCategory.standardOverweightPrice;
                break;
            case 4: //heavy
                weightLimit = ParcelSystem.SizeCategory.heavyWeightLimitation;
                this.price = 50;
                pricingFactor = ParcelSystem.SizeCategory.heavyOverweightPrice;
                break;
            default:
                throw new Exception();
        }
        
        //Price calculator
        if (this.weight - weightLimit > 0)
        {
            this.price += (this.weight - weightLimit) * pricingFactor; //step 3
        }
        
        //if price > 50, change size category to 4 - heavy parcel. //step 4
        if (this.price > 50 && sizeCategory!=4)
        {
            this.sizeCategory = 4;
            calculateParcelPrice();
        }
    }

}