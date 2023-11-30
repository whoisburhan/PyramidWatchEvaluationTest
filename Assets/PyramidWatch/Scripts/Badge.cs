using UnityEngine;
using UnityEngine.UI;

public class Badge : MonoBehaviour, IBadge
{
    [SerializeField] private Image badgeImg;
    [SerializeField] private Text badgeAmountText;
    [SerializeField] private Image badgeProgressIndicator;

    private void Awake()
    {
        if (badgeImg == null) badgeImg = transform.Find("BadgeIcon").GetComponent<Image>();
        if(badgeAmountText == null) badgeAmountText = transform.Find("BadgeAmount").GetComponent <Text>();
        if(badgeProgressIndicator == null) badgeProgressIndicator = transform.Find("Indicator").GetComponent<Image>();
    }


    public void SetIndicator(Sprite indicatorImg)
    {
        badgeProgressIndicator.sprite = indicatorImg;    
    }

    public void UpdateSprite(Sprite sprite)
    {
        badgeImg.sprite = sprite;
    }

    public void UpdateText(int amount)
    {
        badgeAmountText.text = $"{amount} SR";
    }
}
