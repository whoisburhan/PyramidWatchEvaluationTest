using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUISubMenu : CustomSelectable
{
    [SerializeField] private ProductSlot[] productSlot;

    private void OnEnable() => Controller.OnHorizontalInputChange += UpdateSelectedSelectable;

    private void OnDisable() => Controller.OnHorizontalInputChange -= UpdateSelectedSelectable;

    protected override void Awake()
    {
        InitSelectables();
    }

    protected override void Start()
    {
        base.Start();
        ResetSelectedSelectableIndex();
    }

    protected override void InitSelectables()
    {
        productSlot = GetComponentsInChildren<ProductSlot>();
        selectables = new Button[productSlot.Length];
        selectablesAnimator = new Animator[productSlot.Length];
        for(int i = 0; i < productSlot.Length; i++) 
        {
            selectables[i] = productSlot[i].GetComponent<Button>();
            selectablesAnimator[i] = productSlot[i].GetComponent<Animator>();
        }
    }

    protected override void UpdateSelectable(int newSelectedSelectable)
    {
        // Deactivate Current One's Activity

        DeActivateSelectableAnimator(selectablesAnimator[currentlySelectedSelectables]);

        currentlySelectedSelectables = newSelectedSelectable;
        currentlySelectedSelectables %= selectables.Length;

        // Activate New One's Activity

        ActivateSelectableAnimation(selectablesAnimator[currentlySelectedSelectables]);
        
    }


    public void UpdateProducs(List<ProductData> datas) 
    {
        if(datas.Count <= productSlot.Length) 
        {
            for(int i = 0; i < Mathf.Min(datas.Count, productSlot.Length); i++) 
            {
                productSlot[i].UpdateProductSlotView(datas[i]);
            }
        }
        else
        {
            // Dynamically Increase Slot by Instantiate slot
            // Need Couple of more hours to implement but i am already late for my promised deadline :(
        }
    }

    public void UpdateProduct(ProductData data, ProductSlot slot) 
    {
        if (data == null) return;

        slot.UpdateProductSlotView(data);
    }
}
