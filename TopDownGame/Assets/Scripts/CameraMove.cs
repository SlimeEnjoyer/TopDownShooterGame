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

	public MenuUI mainMenuScript;

    private void Start()
    {
        mainMenuScript = GameObject.Find("Main_Menu").GetComponent<MenuUI>();
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        settings.SetActive(false);
    }
    void Update()
	{
		float camPos = mainMenuScript.camPos;

		
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
        if (camPos == 3)
        {
            transform.position = Vector3.Lerp(transform.position, mainMenuPosition.position, Time.deltaTime);
            float rotateY = -20;
            transform.eulerAngles = new Vector3(0, rotateY, 0);
            mainMenu.SetActive(true);
            playMenu.SetActive(false);
            settings.SetActive(false);
        }

    }
}