using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public float camPos = 3; //3 = main menu position, 1 = play position, 2= setting position
    public float levelNumber = 0; //0 = none
    public bool playerJumpIn = false; //before game starts
    public bool play = false; //if game is playing
    public bool roundStartSetup = false;
    public int roundNumber = 1;
    public bool gameFinish = false;

    private TextMeshProUGUI textmeshproComponent;

    private int countDown;

    void Update()
    {
        
    }

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
            StartCoroutine(CountDownThenStart());
        }
    }

    public IEnumerator CountDownThenStart()
    {
        GameObject textObject = GameObject.Find("Countdown");

        if (textObject != null)
        {
            textmeshproComponent = textObject.GetComponent<TextMeshProUGUI>();

            if (textmeshproComponent != null)
            {
                GameObject.Find("Start").GetComponent<Button>().enabled = false;
                roundStartSetup = true;
                countDown = 3;
                textmeshproComponent.fontSize = 109.61f;
                textmeshproComponent.text = "" + countDown;
                yield return new WaitForSeconds(1);
                countDown = 2;
                textmeshproComponent.text = "" + countDown;
                yield return new WaitForSeconds(1);
                countDown = 1;
                textmeshproComponent.text = "" + countDown;
                yield return new WaitForSeconds(1);
                countDown = 0;
                textmeshproComponent.text = "Press start to <br>begin round " + roundNumber;
                textmeshproComponent.fontSize = 37.39f;
                roundStartSetup = false;
                roundNumber += 1;
                play = true;
                GameObject.Find("Start").GetComponent<Button>().enabled = true;
            }
        }
    }
}
