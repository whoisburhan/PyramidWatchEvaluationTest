using UnityEngine;

public enum ProudctType 
{
    SingleProudct, ProductSet
}

[CreateAssetMenu(fileName ="Product Data - 0", menuName = "ProductData")]
public class ProductData : ScriptableObject
{
    public string ProductName;
    public int Price;
    public Sprite ProductImg;
    public ProudctType ProudctType;
    public Sprite ProductTypeImg;

}
