using UnityEngine;
using UnityEngine.UI;

public class SubMenu : CustomSelectable
{
    //[Header("Sub Menu")]
    //[SerializeField] private Button[] subMenuSelectables;
    //[SerializeField] private Animator[] subMenuSelectablesAnimator;
    //[SerializeField] private CanvasGroup[] canvasGroups;

    //private void Awake()
    //{
    //    if(subMenuSelectables.Length == 0) subMenuSelectables = transform.Find("Selectabls").GetComponentsInChildren<Button>();
    //    if (subMenuSelectablesAnimator.Length == 0) subMenuSelectablesAnimator = transform.Find("Selectabls").GetComponentsInChildren<Animator>();
    //    if (canvasGroups.Length == 0) canvasGroups = transform.Find("CanvasGroups").GetComponentsInChildren<CanvasGroup>();
    //}

    protected override void Start()
    {
        base.Start();
        ResetSelectedSelectableIndex();
    }

    //public override void UpdateSelectable(int newSelectedSelectable)
    //{
    //    // Deactivate Current One's Activity

    //    DeActivateSelectableAnimator(subMenuSelectablesAnimator[currentlySelectedSelectables]);
    //    DeActivateCanvasGroup(canvasGroups[currentlySelectedSelectables]);

    //    currentlySelectedSelectables = newSelectedSelectable;
    //    currentlySelectedSelectables %= subMenuSelectables.Length;

    //    // Activate New One's Activity

    //    ActivateSelectableAnimation(subMenuSelectablesAnimator[currentlySelectedSelectables]);
    //    ActivateCanvasGroup(canvasGroups[currentlySelectedSelectables]);

    //}
}
