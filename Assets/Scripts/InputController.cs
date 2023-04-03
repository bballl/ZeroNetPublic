using UnityEngine;

/// <summary>
/// Контроллер пользовательского ввода.
/// </summary>
internal class InputController
{
    public float GetHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetVertical()
    {
        return Input.GetAxis("Vertical");
    }

    //public bool IsJumpButtonPressed()
    //{
    //    bool isJumpButtonPressed = Input.GetButtonDown("Jump");

    //    if (isJumpButtonPressed)
    //        return true;
    //    else
    //        return false;
    //}

    public bool GetFireButtonFirst()
    {
        return Input.GetButtonDown("Fire1");
    }

    public bool GetFireButtonSecond()
    {
        return Input.GetButtonDown("Fire2");
    }
}
