using UnityEngine;
using UnityEngine.UI;

public class CustomSelectable : MonoBehaviour
{
    [Header("Main Menu")]
    [SerializeField] protected Button[] selectables;
    [SerializeField] protected Animator[] selectablesAnimator;
    [SerializeField] protected CanvasGroup[] canvasGroups;


    protected int currentlySelectedSelectables = 0; // As 2 is our shop UI the Evolution test main focus
    // Used hash as its faster
    private int animationSelected = Animator.StringToHash("Selected");
    private int animationNormal = Animator.StringToHash("Normal");


    protected virtual void Awake()
    {
        InitSelectables();
        InitCanvasGroups();
    }

    protected virtual void Start() 
    {
        SetUpSelectablesActions(selectables);
    }

    /// <summary>
    /// This Function Forcefully Changed Current Active Selectables.
    /// NOTE: Providing Random index value can be Risky. SO use it wisely and only if needed.
    /// </summary>
    /// <param name="index"> Default value 0 to Reset the selectable current index, But can be used to other value to change the start Selected selectables somthing else</param>
    public void ResetSelectedSelectableIndex(int index = 0) 
    {
        if(index < selectables.Length) UpdateSelectable(index);
    }

    public void UpdateSelectedSelectable()
    {
        UpdateSelectable(currentlySelectedSelectables + 1);
    }

    public void UpdateSelectedSelectable(int val)
    {
        int temp = currentlySelectedSelectables + val < 0 ? selectables.Length - 1 : currentlySelectedSelectables + val;
        UpdateSelectable(temp);
    }

    protected virtual void UpdateSelectable(int newSelectedSelectable)
    {
        // Deactivate Current One's Activity

        DeActivateSelectableAnimator(selectablesAnimator[currentlySelectedSelectables]);
        DeActivateCanvasGroup(canvasGroups[currentlySelectedSelectables]);

        currentlySelectedSelectables = newSelectedSelectable;
        currentlySelectedSelectables %= selectables.Length;

        // Activate New One's Activity

        ActivateSelectableAnimation(selectablesAnimator[currentlySelectedSelectables]);
        ActivateCanvasGroup(canvasGroups[currentlySelectedSelectables]);

       // if (canvasGroups[currentlySelectedSelectables].gameObject.TryGetComponent<CustomSelectable>(out var cs)) cs.ResetSelectedSelectableIndex();

    }



    protected void SetUpSelectablesActions(Button[] selectableList)
    {
        for (int i = 0; i < selectableList.Length; i++)
        {
            int index = i;
            selectableList[i].onClick.AddListener(()=> UpdateSelectable(index));
        }
    }


    protected virtual void InitSelectables()
    {
        if (selectables.Length == 0) selectables = transform.Find("Selectabls").GetComponentsInChildren<Button>();
        if (selectablesAnimator.Length == 0) selectablesAnimator = transform.Find("Selectabls").GetComponentsInChildren<Animator>();
    }

    protected virtual void InitCanvasGroups()
    {
        if (canvasGroups.Length == 0) canvasGroups = transform.Find("CanvasGroups").GetComponentsInChildren<CanvasGroup>();
    }

    private void ActivateCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void DeActivateCanvasGroup(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    protected void ActivateSelectableAnimation(Animator animator)
    {
        animator.Play(animationSelected);
    }

    protected void DeActivateSelectableAnimator(Animator animator)
    {
        animator.Play(animationNormal);
    }


}
