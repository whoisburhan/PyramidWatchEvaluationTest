using UnityEngine;
using UnityEngine.UI;

public class ProductSkinDetails : MonoBehaviour
{
    [SerializeField] private Image singleProductImg;
    [SerializeField] private Image productSetImg;
    [SerializeField] private Text productName;

    private void Awake()
    {
        if (singleProductImg == null) singleProductImg = transform.Find("SkinImg").GetComponent<Image>(); 
        if(productSetImg == null) productSetImg = transform.Find("SkinSetImg").GetComponent <Image>();
        if (productName == null) productName = transform.Find("SkinName").GetComponent<Text>();
    }


    public void UpdateDetails(string productName,Sprite ProductImg = null, ProudctType productType = ProudctType.SingleProudct) 
    {
        this.productName.text = productName;
        if(productType == ProudctType.SingleProudct) 
        {
            if(ProductImg != null) singleProductImg.sprite = ProductImg;
            singleProductImg.gameObject.SetActive(true);
            productSetImg.gameObject.SetActive(false);
        }
        else
        {
            if (ProductImg != null) productSetImg.sprite = ProductImg;
            singleProductImg.gameObject.SetActive(false);
            productSetImg.gameObject.SetActive(true);
        }
    }
}
