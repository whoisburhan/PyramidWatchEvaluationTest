using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuMidArea : CustomSelectable
{

    [Header("Play Button")]
    [SerializeField] private Button playNow;


    private void OnEnable() => Controller.OnBackButtonTrigger += ReestToHome;
    private void OnDisable() => Controller.OnBackButtonTrigger -= ReestToHome;


    protected override void Awake()
    {
        base.Awake();

        if (playNow == null) playNow = transform.Find("PlayNow").GetComponent<Button>();
    }

    protected override void Start()
    {
        base.Start();
        ResetSelectedSelectableIndex(2); // Set ShopUI As Default Selected Canvas As Thats main Evolution Test Focus, Should be Index 0 for Home Canvas as Default
    }

    protected override void InitCanvasGroups()
    {
        if (canvasGroups.Length == 0)
        {
            canvasGroups = GameObject.Find("SubMenus").GetComponentsInChildren<CanvasGroup>();
            canvasGroups = canvasGroups.Where(cg => cg.tag == "SubMenu").ToArray();
        }
    }

    private void ReestToHome() 
    {
        ResetSelectedSelectableIndex(0);
    }
}
