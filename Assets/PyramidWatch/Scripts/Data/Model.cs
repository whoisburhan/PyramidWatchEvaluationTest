using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    [SerializeField] private int specialTimeOffer;
    [Space]
    [SerializeField] private PlayerDetailes playerDeatails;
    [SerializeField] private List<ProductData> productDatas;

    public PlayerDetailes GetPlayerDetails() => playerDeatails;

    ///Using List index as Data ID for now as lack of Evloution Test Time :), As i promised to deliver within 30th Nov but its already late wkwkwk
    public ProductData GetSpecificProductData(int dataID) 
    {
        if(dataID < 0 || dataID >= productDatas.Count) 
        {
            Debug.LogWarning("DATA ID NOT FOUND!!!");
            return null;
        }
        return productDatas[dataID];
    }

    public List<ProductData> GetProductDatas() => productDatas;

    public int GetSpecialTimeOffer() => specialTimeOffer;

}
