using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 2.0f;
    private CharacterController controller;
    private Vector2 movementInput = Vector2.zero, lookInput;

    [Tooltip("Don't assign values in inspector.  This is done in code!")]
    public int playerNumber = 0;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

        //when player spawns in, find Game MAnager, and tell it to "Add Player To Game" (sets up playerNumber and spawn point position, etc)
        GameObject.Find("Camera").GetComponent<GameManager>().AddPlayerToGame(this);

        Invoke("MoveToSpawnPosition", 0.1f);
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

    void Update()
    {

        movePlayer();

        moveWithAim();
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
