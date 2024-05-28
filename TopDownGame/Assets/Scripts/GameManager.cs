using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MenuUI mainMenuScript;
    public GameObject MenuArea;
    public GameObject Arena01;

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
    }



    public void AddPlayerToGame(PlayerController player)
    {
        // add player to players list
        players.Add(player);

        // assign player IDs
        player.playerNumber = players.Count;

        Debug.Log("Added new player to Game Manager and moved to Spawn Point.  PlayerNumber = " + player.playerNumber);
    }


    public void PlacePlayerAtSpawnPoint(PlayerController player)
    {
        // put player on appropriate spawn positions
        player.gameObject.transform.position = spawnPoints[player.playerNumber - 1].gameObject.transform.position;
    }

}
