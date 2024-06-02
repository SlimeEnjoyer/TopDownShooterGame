using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public float camPos = 3; //3 = main menu position, 1 = play position, 2= setting position
    public float levelNumber = 0; //0 = none
    public bool playerJumpIn = false; //before game starts
    public bool play = false; //if game is playing
    
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
            playerJumpIn = true;
        }
        else if (buttonClicked == 5)
        {
            play = true;
        }
    }
}
