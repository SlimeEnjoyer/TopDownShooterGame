using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
	public Transform mainMenuPosition = null; // create an empty gameobject and assign in inspector
	public Transform playPosition = null; // create an empty gameobject and assign in inspector
	public Transform settingPosition = null; // create an empty gameobject and assign in inspector
	public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject settings;
    public GameObject playerJoinIn;

    public GameObject P1Health;
    public GameObject P2Health;
    public GameObject P3Health;
    public GameObject P4Health;
    public GameObject P1Score;
    public GameObject P2Score;
    public GameObject P3Score;
    public GameObject P4Score;

    public int numberOfPlayers;

	public MenuUI mainMenuScript;
    private PlayerInputManager playerInputManager;

    private void Start()
    {
        mainMenuScript = this.gameObject.GetComponent<MenuUI>();
        playerInputManager = GameObject.Find("PlayerManager").GetComponent<PlayerInputManager>();
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        settings.SetActive(false);
        playerJoinIn.SetActive(false);
        P1Health.SetActive(false);
        P2Health.SetActive(false);
        P3Health.SetActive(false);
        P4Health.SetActive(false);
        P1Score.SetActive(false);
        P2Score.SetActive(false);
        P3Score.SetActive(false);
        P4Score.SetActive(false);
        playerInputManager.DisableJoining();
    }
    void Update()
	{
		float camPos = mainMenuScript.camPos;
        bool play = mainMenuScript.play;
        bool playerJumpIn = mainMenuScript.playerJumpIn;

        if (GameObject.Find("PlayerOne") & GameObject.Find("PlayerTwo") == null & GameObject.Find("PlayerThree") == null & GameObject.Find("PlayerFour") == null)
        {
            numberOfPlayers = 1;
        }
        else if (GameObject.Find("PlayerOne") & GameObject.Find("PlayerTwo") & GameObject.Find("PlayerThree") == null & GameObject.Find("PlayerFour") == null)
        {
            numberOfPlayers = 2;
        }
        else if (GameObject.Find("PlayerOne") & GameObject.Find("PlayerTwo") & GameObject.Find("PlayerThree") & GameObject.Find("PlayerFour") == null)
        {
            numberOfPlayers = 3;
        }
        else if (GameObject.Find("PlayerOne") & GameObject.Find("PlayerTwo") & GameObject.Find("PlayerThree") & GameObject.Find("PlayerFour"))
        {
            numberOfPlayers = 4;
        }

        if (camPos == 1)
        {
			transform.position = Vector3.Lerp(transform.position, playPosition.position, Time.deltaTime);
			float rotateX = 90;
			transform.eulerAngles = new Vector3(rotateX, 0, 0);
			mainMenu.SetActive(false);
			playMenu.SetActive(true);
            settings.SetActive(false);
            playerJoinIn.SetActive(false);
        }
        else if (camPos == 2)
        {
            transform.position = Vector3.Lerp(transform.position, settingPosition.position, Time.deltaTime);
            float rotateY = 106;
            transform.eulerAngles = new Vector3(0, rotateY, 0);
            mainMenu.SetActive(false);
            playMenu.SetActive(false);
            settings.SetActive(true);
            playerJoinIn.SetActive(false);
        }
        else if (camPos == 3)
        {
            transform.position = Vector3.Lerp(transform.position, mainMenuPosition.position, Time.deltaTime);
            float rotateY = -20;
            transform.eulerAngles = new Vector3(0, rotateY, 0);
            mainMenu.SetActive(true);
            playMenu.SetActive(false);
            settings.SetActive(false);
            playerJoinIn.SetActive(false);
        }
        
        if (playerJumpIn == true)
        {
            playerInputManager.EnableJoining();
            mainMenu.SetActive(false);
            playMenu.SetActive(false);
            settings.SetActive(false);
            playerJoinIn.SetActive(true);
        }
        else if (playerJumpIn == false)
        {
            playerInputManager.DisableJoining();
        }

        if (play == true)
        {
            playerInputManager.DisableJoining();
            mainMenu.SetActive(false);
            playMenu.SetActive(false);
            settings.SetActive(false);
            playerJoinIn.SetActive(false);
            if (numberOfPlayers == 1)
            {
                P1Health.SetActive(true);
                P2Health.SetActive(false);
                P3Health.SetActive(false);
                P4Health.SetActive(false);
                P1Score.SetActive(true);
                P2Score.SetActive(false);
                P3Score.SetActive(false);
                P4Score.SetActive(false);
            }
            else if (numberOfPlayers == 2)
            {
                P1Health.SetActive(true);
                P2Health.SetActive(true);
                P3Health.SetActive(false);
                P4Health.SetActive(false);
                P1Score.SetActive(true);
                P2Score.SetActive(true);
                P3Score.SetActive(false);
                P4Score.SetActive(false);
            }
            else if (numberOfPlayers == 3)
            {
                P1Health.SetActive(true);
                P2Health.SetActive(true);
                P3Health.SetActive(true);
                P4Health.SetActive(false);
                P1Score.SetActive(true);
                P2Score.SetActive(true);
                P3Score.SetActive(true);
                P4Score.SetActive(false);
            }
            else if (numberOfPlayers == 4)
            {
                P1Health.SetActive(true);
                P2Health.SetActive(true);
                P3Health.SetActive(true);
                P4Health.SetActive(true);
                P1Score.SetActive(true);
                P2Score.SetActive(true);
                P3Score.SetActive(true);
                P4Score.SetActive(true);
            }
        }

    }
}