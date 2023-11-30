using UnityEngine;

public class UI_Input : MonoBehaviour, IUI_Input
{
    private bool isMainuButtonPressed, isSubMenuButtonPressed, isLeftRightInputTriggered, isUpDownInputTriggered, isBackButtonPressed;
    private float isLeftRightSwitchButtonPressedValue, isUpDownSwitchButtonPressedValue;
    private int leftRightButtonValue, upDownButtonValue;
    
    private void Update()
    {
        isMainuButtonPressed = Input.GetButtonDown("MainMenu");
        isSubMenuButtonPressed = Input.GetButtonDown("SubMenu");
        isBackButtonPressed = Input.GetButtonDown("Back");

        LeftRightInput();
        UpDownInput();
    }

    public bool MainMenuSelectableChange() => isMainuButtonPressed;
    public bool SubMenuSelectableChange() => isSubMenuButtonPressed;

    public bool BackButtonTrigger() => isBackButtonPressed;
    public int HorizontalInputChange() => leftRightButtonValue;
    public int VerticalInputChange() => upDownButtonValue;


    private void UpDownInput()
    {
        isUpDownSwitchButtonPressedValue = Input.GetAxisRaw("Vertical");

        if (isUpDownSwitchButtonPressedValue != 0 && !isUpDownInputTriggered)
        {
            isUpDownInputTriggered = true;

            upDownButtonValue = (int)isUpDownSwitchButtonPressedValue;
        }
        else if (isUpDownSwitchButtonPressedValue != 0 && isUpDownInputTriggered)
        {
            upDownButtonValue = 0;
        }

        if (isUpDownSwitchButtonPressedValue == 0 && isUpDownInputTriggered)
        {
            isUpDownInputTriggered = false;
        }
    }

    private void LeftRightInput()
    {
        isLeftRightSwitchButtonPressedValue = Input.GetAxisRaw("Horizontal");


        if (isLeftRightSwitchButtonPressedValue != 0 && !isLeftRightInputTriggered)
        {
            // Set the triggered flag to true
            isLeftRightInputTriggered = true;

            leftRightButtonValue = (int)isLeftRightSwitchButtonPressedValue;
        }
        else if (isLeftRightSwitchButtonPressedValue != 0 && isLeftRightInputTriggered)
        {
            leftRightButtonValue = 0;
        }

        // If the input is zero and has been triggered
        if (isLeftRightSwitchButtonPressedValue == 0 && isLeftRightInputTriggered)
        {
            isLeftRightInputTriggered = false;
        }
    }


}
