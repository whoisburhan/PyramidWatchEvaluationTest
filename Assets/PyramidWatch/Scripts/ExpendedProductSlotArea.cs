using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExpendedProductSlotArea : CustomSelectable
{
    [SerializeField] private int productDataID;
    private ProductSlot productSlot;

    private void OnEnable()
    {
        Controller.OnVerticalInputChange += UpdateSelectedSelectable;
        ResetSelectedSelectableIndex();
    }

    private void OnDisable() => Controller.OnVerticalInputChange -= UpdateSelectedSelectable;

    protected override void Awake()
    {
        InitSelectables();
    }

    protected override void Start()
    {
        base.Start();
        productSlot = GetComponentInParent<ProductSlot>();
        
        selectables[0].onClick.AddListener(() => { Debug.Log("DOWNLOAD NOW CALLED!"); });
        selectables[1].onClick.AddListener(() => { productSlot.UpdateProductSlotView(Controller.OnSpecificProductDataCall?.Invoke(productDataID)); });
    }


    protected override void InitSelectables()
    {
        selectables = GetComponentsInChildren<Button>();
        selectablesAnimator = GetComponentsInChildren<Animator>();
    }

    protected override void UpdateSelectable(int newSelectedSelectable)
    {
        // Deactivate Current One's Activity

        DeActivateSelectableAnimator(selectablesAnimator[currentlySelectedSelectables]);

        currentlySelectedSelectables = newSelectedSelectable;
        currentlySelectedSelectables %= selectables.Length;

        // Activate New One's Activity

        ActivateSelectableAnimation(selectablesAnimator[currentlySelectedSelectables]);
        selectables[currentlySelectedSelectables].Select();

    }
    public Button[] GetSelectables() => selectables;
}
