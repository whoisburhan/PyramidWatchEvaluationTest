using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] private MainMenu menu;
    [SerializeField] private Image bg;
    [SerializeField] private ShopUI shopUI;

    private void Awake()
    {
        if(menu == null) menu = transform.Find("MainMenu").GetComponent<MainMenu>();
        if (bg == null) bg = transform.Find("BG").GetComponent<Image>();
        if(shopUI == null) shopUI = GameObject.Find("ShopUI").GetComponent<ShopUI>();
    }


    public void UpdatePlayerDetailes(PlayerDetailes details) 
    {
        if(details == null) 
        {
            Debug.LogWarning($"Player Details Null....");
            return;
        }

        if(details.UserName != null) SetUserName(details.UserName);

        SetTotalCoinAmount(details.coinAmount);

        SetBadgeInfo(details.badePointAmount);
    }

    public void UpdateShopUIProducts(List<ProductData> productDatas, ShopUISubMenuType shopUISubMenuType) => shopUI.UpdateShopUIData(productDatas, shopUISubMenuType);

    public void SetSpecialTimeOfferCounter(int counterInSeconds) => shopUI.SetSpecialOfferTimer(counterInSeconds);

    public void SetBackground(Sprite newBackground) => bg.sprite = newBackground;

    public void SetGameLogo(Sprite logo) => menu.SetGameLogo(logo);

    public void SetUserName(string UserName) => menu.SetUserName(UserName);

    public void SetTotalCoinAmount(int coinAmount, Sprite coinSprite = null) => menu.SetTotalCoinAmount(coinAmount, coinSprite);

    public void SetBadgeInfo(int badgePointAmount, Sprite progressIndicator = null, Sprite badgeSprite = null) => menu.SetBadgeInfo(badgePointAmount, badgeSprite);

    public void UpdateMainMenuSelectedSelectable() => menu.UpdateMainMenuSelectedSelectable();
}
