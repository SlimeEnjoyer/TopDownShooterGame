using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public float camPos = 1; //3 = main menu position, 1 = play position, 2= setting position
    
    public void ClickButton(int buttonClicked)
    {
       
        if (buttonClicked == 1)
        {
            camPos = 1;
        }
        else if (buttonClicked == 2)
        {
            camPos = 2;
        }
        else if (buttonClicked == 3)
        {
            camPos = 3;
        }
    }
}
