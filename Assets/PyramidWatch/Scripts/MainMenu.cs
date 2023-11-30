using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MainMenuRightArea mainManuRightArea;
    [SerializeField] private MainMenuMidArea mainMenuMidArea;
    [SerializeField] private MainMenuLeftArea mainMenuLeftArea;
    [SerializeField] private Button backButton;

    private void Awake()
    {
        if (mainManuRightArea == null) mainManuRightArea = transform.Find("Right").GetComponent<MainMenuRightArea>();
        if (mainMenuMidArea == null) mainMenuMidArea = transform.Find("Mid").GetComponent <MainMenuMidArea>();
        if (mainMenuLeftArea == null) mainMenuLeftArea = transform.Find("Left").GetComponent<MainMenuLeftArea>();
        if (backButton == null) backButton = transform.Find("BackButton").GetComponent<Button>();
    }

    private void Start()
    {
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(() => 
        {
            mainMenuMidArea.ResetSelectedSelectableIndex(); // Back to Home Panel
        });
    }

    public void SetGameLogo(Sprite logo) => mainManuRightArea.SetLogo(logo);

    public void SetUserName(string UserName) => mainMenuLeftArea.SetUserName(UserName);

    public void SetTotalCoinAmount(int coinAmount, Sprite coinSprite = null) => mainMenuLeftArea.SetCoinInfo(coinAmount, coinSprite);

    public void SetBadgeInfo(int badgePointAmount, Sprite progressIndicator = null, Sprite badgeSprite = null) => mainMenuLeftArea.SetBadgeInfo(badgePointAmount, badgeSprite);

    public void UpdateMainMenuSelectedSelectable() => mainMenuMidArea.UpdateSelectedSelectable();

    

}
