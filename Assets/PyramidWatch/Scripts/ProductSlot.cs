using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProductSlot : MonoBehaviour
{
    [SerializeField] private ProductSkinDetails skinDetails;
    [SerializeField] private Coin coin;
    [SerializeField] private Image productImg;
    
    private Animator animator;
    private Button button;
    

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();

        if (coin == null ) coin = transform.Find("Coin").GetComponent<Coin>();
        if (skinDetails == null) skinDetails = transform.Find("SkinDetails").GetComponent<ProductSkinDetails>();
        if (productImg == null) productImg = transform.Find("ItemImg").GetComponent<Image>();
    }

    protected virtual void Start()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(Expend);
    }

    public void Expend() 
    {
        animator.Play("Selected");
        //var selectables = expendedProductSlotArea.GetSelectables();
        //selectables[0].Select();
        
    }

    public void UpdateProductSlotView(ProductData data) 
    {
        if(data == null) return;

        productImg.sprite = data.ProductImg;
        skinDetails.UpdateDetails(data.ProductName, data.ProductTypeImg,data.ProudctType);
        coin.UpdateText(data.Price);
    }

}
