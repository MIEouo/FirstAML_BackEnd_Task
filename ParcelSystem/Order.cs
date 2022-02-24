namespace ParcelSystem;

public class Order
{
    // private Parcel[] parcels;
    private List<Parcel> parcels;
    private bool isSpeedy;
    
    //Constructor
    public Order(List<Parcel> parcels, bool isSpeedy)
    {
        this.parcels = parcels;
        this.isSpeedy = isSpeedy;
    }
    
    //orderTotal
    private double calculateTotal() 
    {
        double total = 0;
        foreach (Parcel parcel in parcels)
        {
            total += parcel.Price;
        }
        if (isSpeedy) // step 2
        {
            parcels.Add(new Parcel(price:total));
            total += total;
        }
        return total;
    }
}