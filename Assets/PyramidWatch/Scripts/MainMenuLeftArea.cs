using UnityEngine;
using UnityEngine.UI;

public class MainMenuLeftArea : MonoBehaviour
{
    [SerializeField] private ICoin totalGameCoin;
    [SerializeField] private IBadge badge;
    [SerializeField] private Text userName;

    private void Awake()
    {
        if(totalGameCoin == null) totalGameCoin = transform.Find("TotalCoin").GetComponent<Coin>();
        if(badge == null) badge = transform.Find("Badge").GetComponent<Badge>();
        if(userName == null) userName = transform.Find("UserName").GetComponent<Text>();
    }

    public void SetCoinInfo(int coinAmount, Sprite coinSprite = null) 
    {
        totalGameCoin.UpdateText(coinAmount);
        
        if(coinSprite != null) totalGameCoin.UpdateSprite(coinSprite);
    }

    public void SetBadgeInfo(int badgePointAmount, Sprite progressIndicator = null, Sprite badegeSprite = null) 
    {
        badge.UpdateText(badgePointAmount);

        if (progressIndicator != null) badge.SetIndicator(progressIndicator);
        if (badegeSprite != null) badge.UpdateSprite(badegeSprite);
    }

    public void SetUserName(string userName) 
    {
        this.userName.text = userName;
    }
}
