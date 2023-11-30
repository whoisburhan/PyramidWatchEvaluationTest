using UnityEngine.UI;
using UnityEngine;

public class Coin : MonoBehaviour, ICoin
{
    [SerializeField] private Image coinImg;
    [SerializeField] private Text coinText;

    private void Awake()
    {
        if(coinImg == null) coinImg = GetComponentInChildren<Image>();
        if(coinText == null) coinText = GetComponentInChildren<Text>();
    }

    public void UpdateSprite(Sprite sprite) => coinImg.sprite = sprite;
    public void UpdateText(int amount) => coinText.text = amount.ToString();
}
