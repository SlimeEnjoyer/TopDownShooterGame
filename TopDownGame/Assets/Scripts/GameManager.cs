using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MenuUI mainMenuScript;
    public GameObject MenuArea;
    public GameObject Arena01;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuScript = GameObject.Find("Main_Menu").GetComponent<MenuUI>();

    }

    // Update is called once per frame
    void Update()
    {
        float levelNumber = mainMenuScript.levelNumber;

        if (levelNumber == 0)
        {
            MenuArea.SetActive(true);
            Arena01.SetActive(false);
        }
        else if (levelNumber == 1)
        {
            MenuArea.SetActive(false);
            Arena01.SetActive(true);
        }
    }
}
