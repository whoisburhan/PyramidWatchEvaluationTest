using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSlotExtended : ProductSlot
{
    [SerializeField] private ExpendedProductSlotArea expendedProductSlotArea;
    protected override void Awake()
    {
        base.Awake();
        if (expendedProductSlotArea == null) expendedProductSlotArea = transform.Find("Expend").GetComponent<ExpendedProductSlotArea>();
    }
}
