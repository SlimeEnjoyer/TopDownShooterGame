using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public MenuUI mainMenuScript;
    public GameObject MenuArea;
    public GameObject Arena01;

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private GameObject player4;

    public int player1Score;
    public int player2Score;
    public int player3Score;
    public int player4Score;

    private TextMeshProUGUI textmeshproComponent1;
    private TextMeshProUGUI textmeshproComponent2;
    private TextMeshProUGUI textmeshproComponent3;
    private TextMeshProUGUI textmeshproComponent4;

    public List<SpawnPoint> spawnPoints = new List<SpawnPoint>();
    public List<PlayerController> players = new List<PlayerController>();


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

        ScoreBoard();
        ScoreUpdate();
    }

    public void ScoreBoard()
    {
        GameObject textObject1 = GameObject.Find("P1ScoreNumber");
        GameObject textObject2 = GameObject.Find("P2ScoreNumber");
        GameObject textObject3 = GameObject.Find("P3ScoreNumber");
        GameObject textObject4 = GameObject.Find("P4ScoreNumber");

        if (textObject1 != null)
        {
            textmeshproComponent1 = textObject1.GetComponent<TextMeshProUGUI>();

            if (textmeshproComponent1 != null)
            {
                textmeshproComponent1.text = "P1: " + player1Score;
            }
        }
        if (textObject2 != null)
        {
            textmeshproComponent2 = textObject2.GetComponent<TextMeshProUGUI>();

            if (textmeshproComponent2 != null)
            {
                textmeshproComponent2.text = "P2: " + player2Score;
            }
        }
        if (textObject3 != null)
        {
            textmeshproComponent3 = textObject3.GetComponent<TextMeshProUGUI>();

            if (textmeshproComponent3 != null)
            {
                textmeshproComponent3.text = "P3: " + player3Score;
            }
        }
        if (textObject4 != null)
        {
            textmeshproComponent4 = textObject4.GetComponent<TextMeshProUGUI>();

            if (textmeshproComponent4 != null)
            {
                textmeshproComponent4.text = "P4: " + player4Score;
            }
        }
    }

    public void ScoreUpdate()
    {
        if (player1 != null && player2 != null)
        {
            if (player1.activeSelf && !player2.activeSelf)
            {
                Debug.Log("player1 is active and player 2 is not");
            }
            else
            {
                Debug.Log("something aint working");
            }
        }
    }
    public void AddPlayerToGame(PlayerController player)
    {
        // add player to players list
        players.Add(player);

        // assign player IDs
        player.playerNumber = players.Count;

        Debug.Log("Added new player to Game Manager and moved to Spawn Point.  PlayerNumber = " + player.playerNumber);
        player1 = GameObject.Find("PlayerOne");
        player2 = GameObject.Find("PlayerTwo");
        player3 = GameObject.Find("PlayerThree");
        player4 = GameObject.Find("PlayerFour");
    }


    public void PlacePlayerAtSpawnPoint(PlayerController player)
    {
        // put player on appropriate spawn positions
        player.gameObject.transform.position = spawnPoints[player.playerNumber - 1].gameObject.transform.position;
    }

}
