using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShopUISubMenuType
{
    Skins, Blocks
}

public class ShopUI : CustomSelectable
{
    [SerializeField] private ShopUISubMenu[] shopUISubMenus;

    [SerializeField] private LimitedTimeOffer limitedTimeOffer;

    private void OnEnable() => Controller.OnSubMenuNavigationInputChnage += UpdateSelectedSelectable;

    private void OnDisable() => Controller.OnSubMenuNavigationInputChnage -= UpdateSelectedSelectable;


    protected override void Awake()
    {
        base.Awake();
        InitShopUISubMenu();
    }

    protected override void Start()
    {
        base.Start();
        ResetSelectedSelectableIndex();
    }

    private void InitShopUISubMenu() 
    {
        shopUISubMenus = new ShopUISubMenu[canvasGroups.Length];

        for(int i = 0; i < shopUISubMenus.Length; i++) 
        {
            shopUISubMenus[i] = canvasGroups[i].GetComponent<ShopUISubMenu>();
        }



        limitedTimeOffer = GetComponentInChildren<LimitedTimeOffer>();
    }

    public void UpdateShopUIData(List<ProductData> datas, ShopUISubMenuType shopUISubMenuType) => shopUISubMenus[(int)shopUISubMenuType].UpdateProducs(datas);

    public void SetSpecialOfferTimer(int timeInSeconds) => limitedTimeOffer.SetTimer(timeInSeconds);


}
