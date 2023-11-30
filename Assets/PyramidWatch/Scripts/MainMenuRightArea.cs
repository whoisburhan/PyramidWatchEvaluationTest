using UnityEngine;
using UnityEngine.UI;

public class MainMenuRightArea : MonoBehaviour
{
    [SerializeField] private Image logo;

    private void Awake()
    {
        if (logo == null) logo = GetComponentInChildren<Image>();
    }

    public void SetLogo(Sprite logo) 
    {
        this.logo.sprite = logo;
    }
}
