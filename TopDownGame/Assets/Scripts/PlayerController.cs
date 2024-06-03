using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    private CharacterController controller;
    private Vector2 movementInput = Vector2.zero, lookInput;

    public Material Player1;
    public Material Player2;
    public Material Player3;
    public Material Player4;

    public GameObject shotGun;
    public float bulletSpeed = 20;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private bool isShotCoolDown = false;
    public float shotCoolDown = 0.5f;

    public bool isDead;

    public float playerHealth = 100f;

    private TextMeshProUGUI textmeshproComponent;

    [Tooltip("Don't assign values in inspector.  This is done in code!")]
    public int playerNumber = 0;

    public MenuUI mainMenuScript;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        mainMenuScript = GameObject.Find("Camera").GetComponent<MenuUI>();

        

        //when player spawns in, find Game MAnager, and tell it to "Add Player To Game" (sets up playerNumber and spawn point position, etc)
        GameObject.Find("Camera").GetComponent<GameManager>().AddPlayerToGame(this);

        Invoke("MoveToSpawnPosition", 0.1f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            playerHealth -= 10f;
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (!isShotCoolDown)
        {
            StartCoroutine(ShootWithDelay());
        }
    }

    private IEnumerator ShootWithDelay()
    {
        bool play = mainMenuScript.play;
        if (play == true)
        {
            if (isDead == false)
            {
                isShotCoolDown = true;

                GameObject GO = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity) as GameObject;
                GO.GetComponent<Rigidbody>().AddForce(shotGun.transform.forward * bulletSpeed, ForceMode.Impulse);

                yield return new WaitForSeconds(shotCoolDown);

                isShotCoolDown = false;
            }
        }
    }

    public void MoveToSpawnPosition()
    {
        GameObject.Find("Camera").GetComponent<GameManager>().PlacePlayerAtSpawnPoint(this);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
        //Debug.Log("lookInput = " + lookInput);
    }

    public void Health()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            isDead = true;
        }

        if (playerNumber == 1)
        {

            GameObject textObject = GameObject.Find("P1Health");

            if (textObject != null)
            {
                textmeshproComponent = textObject.GetComponent<TextMeshProUGUI>();

                if (textmeshproComponent != null)
                {
                    textmeshproComponent.text = "P1: " + playerHealth;
                }
            }
        }
        if (playerNumber == 2)
        {

            GameObject textObject = GameObject.Find("P2Health");

            if (textObject != null)
            {
                textmeshproComponent = textObject.GetComponent<TextMeshProUGUI>();

                if (textmeshproComponent != null)
                {
                    textmeshproComponent.text = "P2: " + playerHealth;
                }
            }
        }
        if (playerNumber == 3)
        {

            GameObject textObject = GameObject.Find("P3Health");

            if (textObject != null)
            {
                textmeshproComponent = textObject.GetComponent<TextMeshProUGUI>();

                if (textmeshproComponent != null)
                {
                    textmeshproComponent.text = "P3: " + playerHealth;
                }
            }
        }
        if (playerNumber == 4)
        {

            GameObject textObject = GameObject.Find("P4Health");

            if (textObject != null)
            {
                textmeshproComponent = textObject.GetComponent<TextMeshProUGUI>();

                if (textmeshproComponent != null)
                {
                    textmeshproComponent.text = "P4: " + playerHealth;
                }
            }
        }
    }

    void Update()
    {

        // add a script during the countdown that makes this script make isDead = true
        bool play = mainMenuScript.play;

        Death();

        if (play == true)
        {
            if (isDead == false)
            {
                movePlayer();
                moveWithAim();
            }
            
        }
        Health();

        if (playerNumber == 1)
        {
            this.gameObject.name = "PlayerOne";
            this.GetComponent<Renderer>().material = Player1;
        }
        else if (playerNumber == 2)
        {
            this.gameObject.name = "PlayerTwo";
            this.GetComponent<Renderer>().material = Player2;
        }
        else if (playerNumber == 3)
        {
            this.gameObject.name = "PlayerThree";
            this.GetComponent<Renderer>().material = Player3;
        }
        else if (playerNumber == 4)
        {
            this.gameObject.name = "PlayerFour";
            this.GetComponent<Renderer>().material = Player4;
        }
    }

    public void Death()
    {
        //disable every component on the character.
        if (isDead == true)
        {
            this.GetComponent<CharacterController>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            shotGun.GetComponent<MeshRenderer>().enabled = false;
        }
        if (isDead == false)
        {
            this.GetComponent<CharacterController>().enabled = true;
            this.GetComponent<CapsuleCollider>().enabled = true;
            this.GetComponent<BoxCollider>().enabled = true;
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }
    public void movePlayer()
    {
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        //Debug.Log("Input MOVE values = " + move);
        controller.Move(move * Time.deltaTime * playerSpeed);
        //if (move != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 0.15f);
        //}
    }

    public void moveWithAim()
    {
        Vector3 aimDirection = new Vector3(lookInput.x, 0f, lookInput.y);
        //Debug.Log("Input ROTATE values = " + aimDirection);
        if (aimDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(aimDirection), 0.15f);
        }
        //Vector3 movement = new Vector3(movementInput.x, 0f, movementInput.y);
        //transform.Translate(movement * playerSpeed * Time.deltaTime, Space.World);
    }
}
