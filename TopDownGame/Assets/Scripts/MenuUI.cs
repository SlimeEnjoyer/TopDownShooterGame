using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public float camPos = 1; //3 = main menu position, 1 = play position, 2= setting position
    public float levelNumber = 0; //0 = none
    public int play = 0; //0 = game not playing, 1 = game is playing
    
    public void ClickButton(int buttonClicked)
    {
       
        if (buttonClicked == 1)
        {
            camPos = 1;
            levelNumber = 1;
        }
        else if (buttonClicked == 2)
        {
            camPos = 2;
        }
        else if (buttonClicked == 3)
        {
            camPos = 3;
            levelNumber = 0;
        }
        else if (buttonClicked == 4)
        {
            play = 1;
        }
    }
}
