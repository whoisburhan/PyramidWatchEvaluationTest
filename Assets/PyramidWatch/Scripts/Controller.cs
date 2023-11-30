using System;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public static Action OnSubMenuNavigationInputChnage;
    public static Action OnBackButtonTrigger;
    public static Action<int> OnHorizontalInputChange;
    public static Action<int> OnVerticalInputChange;

    public static Func<int, ProductData> OnSpecificProductDataCall;

    [SerializeField] private IUI_Input input;
    [SerializeField] private Model model;
    [SerializeField] private View view;

    private void Awake()
    {
        if(input == null) input = GetComponent<IUI_Input>();
        if(view == null) view = GetComponent<View>();
        if(model == null) model = GetComponent<Model>();
    }

    private void Start()
    {
        UpdatePlayerDetailes();
        UpdateShopUIDataAutomatic();
        UpdateSpecialTimeOffer();
    }

    private void OnEnable() => OnSpecificProductDataCall += UpdateShopUIDataOnCall;
    private void OnDisable() => OnSpecificProductDataCall -= UpdateShopUIDataOnCall;

    private void UpdatePlayerDetailes() => view.UpdatePlayerDetailes(model.GetPlayerDetails());
    private void UpdateShopUIDataAutomatic() => view.UpdateShopUIProducts(model.GetProductDatas(), ShopUISubMenuType.Blocks);

    public ProductData UpdateShopUIDataOnCall(int dataID) => model.GetSpecificProductData(dataID);
    private void UpdateSpecialTimeOffer() => view.SetSpecialTimeOfferCounter(model.GetSpecialTimeOffer());


    private void Update()
    {
        Navigatior();
    }

    private void Navigatior()
    {
        if (input.MainMenuSelectableChange()) view.UpdateMainMenuSelectedSelectable();
        if (input.SubMenuSelectableChange()) OnSubMenuNavigationInputChnage?.Invoke();
        if (input.HorizontalInputChange() != 0) OnHorizontalInputChange?.Invoke(input.HorizontalInputChange());
        if (input.VerticalInputChange() != 0) OnVerticalInputChange?.Invoke(input.VerticalInputChange());
        if(input.BackButtonTrigger()) OnBackButtonTrigger?.Invoke();
    }
}
