using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public Transform mainMenuPosition = null; // create an empty gameobject and assign in inspector
	public Transform playPosition = null; // create an empty gameobject and assign in inspector
	public Transform settingPosition = null; // create an empty gameobject and assign in inspector
	public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject settings;

    public GameObject P1Health;
    public GameObject P2Health;
    public GameObject P3Health;
    public GameObject P4Health;

    public int numberOfPlayers;

	public MenuUI mainMenuScript;

    private void Start()
    {
        mainMenuScript = GameObject.Find("Main_Menu").GetComponent<MenuUI>();
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        settings.SetActive(false);
        P1Health.SetActive(false);
        P2Health.SetActive(false);
        P3Health.SetActive(false);
        P4Health.SetActive(false);
    }
    void Update()
	{
		float camPos = mainMenuScript.camPos;
        int play = mainMenuScript.play;

        if (GameObject.Find("PlayerOne") & GameObject.Find("PlayerTwo") == null & GameObject.Find("PlayerThree") == null & GameObject.Find("PlayerFour") == null)
        {
            numberOfPlayers = 1;
            Debug.Log("there are " + numberOfPlayers + " players");
        }
        else if (GameObject.Find("PlayerOne") & GameObject.Find("PlayerTwo") & GameObject.Find("PlayerThree") == null & GameObject.Find("PlayerFour") == null)
        {
            numberOfPlayers = 2;
            Debug.Log("there are " + numberOfPlayers + " players");
        }
        else if (GameObject.Find("PlayerOne") & GameObject.Find("PlayerTwo") & GameObject.Find("PlayerThree") & GameObject.Find("PlayerFour") == null)
        {
            numberOfPlayers = 3;
            Debug.Log("there are " + numberOfPlayers + " players");
        }
        else if (GameObject.Find("PlayerOne") & GameObject.Find("PlayerTwo") & GameObject.Find("PlayerThree") & GameObject.Find("PlayerFour"))
        {
            numberOfPlayers = 4;
            Debug.Log("there are " + numberOfPlayers + " players");
        }

        if (camPos == 1)
        {
			transform.position = Vector3.Lerp(transform.position, playPosition.position, Time.deltaTime);
			float rotateX = 90;
			transform.eulerAngles = new Vector3(rotateX, 0, 0);
			mainMenu.SetActive(false);
			playMenu.SetActive(true);
            settings.SetActive(false);
        }
        else if (camPos == 2)
        {
            transform.position = Vector3.Lerp(transform.position, settingPosition.position, Time.deltaTime);
            float rotateY = 106;
            transform.eulerAngles = new Vector3(0, rotateY, 0);
            mainMenu.SetActive(false);
            playMenu.SetActive(false);
            settings.SetActive(true);
        }
        else if (camPos == 3)
        {
            transform.position = Vector3.Lerp(transform.position, mainMenuPosition.position, Time.deltaTime);
            float rotateY = -20;
            transform.eulerAngles = new Vector3(0, rotateY, 0);
            mainMenu.SetActive(true);
            playMenu.SetActive(false);
            settings.SetActive(false);
        }
        
        
        if (play == 1)
        {
            mainMenu.SetActive(false);
            playMenu.SetActive(false);
            settings.SetActive(false);
            if (numberOfPlayers == 1)
            {
                P1Health.SetActive(true);
                P2Health.SetActive(false);
                P3Health.SetActive(false);
                P4Health.SetActive(false);
            }
            else if (numberOfPlayers == 2)
            {
                P1Health.SetActive(true);
                P2Health.SetActive(true);
                P3Health.SetActive(false);
                P4Health.SetActive(false);
            }
            else if (numberOfPlayers == 3)
            {
                P1Health.SetActive(true);
                P2Health.SetActive(true);
                P3Health.SetActive(true);
                P4Health.SetActive(false);
            }
            else if (numberOfPlayers == 4)
            {
                P1Health.SetActive(true);
                P2Health.SetActive(true);
                P3Health.SetActive(true);
                P4Health.SetActive(true);
            }
        }

    }
}