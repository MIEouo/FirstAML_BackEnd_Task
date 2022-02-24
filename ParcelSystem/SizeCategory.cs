namespace ParcelSystem;

public class SizeCategory
{
    //Parcel Size
    public static int small = 0;
    public static int medium = 1;
    public static int large = 2;
    public static int xl = 3;
    // public static int heavy = 4;

    //Size Limitation
    public static double smallWeightLimitation = 1;
    public static double mediumWeightLimitation = 3;
    public static double largeWeightLimitation = 6;
    public static double xlWeightLimitation = 10;
    public static double heavyWeightLimitation = 50;
    
    //pricing factors
    public static int standardOverweightPrice = 2;
    public static int heavyOverweightPrice = 1;

    //Define size category by parcel size
    public static int defineSizeCategory(int size)
    {
        if (size >= 0 && size < 10)
        {
            return small;
        }
        else if(size < 50)
        {
            return medium;
        }
        else if(size < 100)
        {
            return large;
        }
        else if(size >= 100)
        {
            return xl;
        }
        else
        {
            throw new ArgumentException("Not Available.");
        }
    }
}