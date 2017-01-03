using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;
    [SerializeField]
    private float xRotationLock = 0f;
    [SerializeField]
    private float zRotationLock = 0f;
    [SerializeField]
    private float interactDistance = 10f;

    public List<Quest> questList;

    private bool interacting = false;

    private GameObject currentNPCInteractingWith = null;

    private PlayerMotor motor;
    private ControlTracker ctrl;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        ctrl = GetComponent<ControlTracker>();
    }

    void Update()
    {
        calculateMovement();

        //Calculate rotation as a 3D Vector (TURNING)
        calculateRotation();

        //Calculate camera rotaion as a 3D vector
        calculateCameraRotation();

        //Lock player in upright position
        transform.rotation = Quaternion.Euler(xRotationLock, transform.rotation.eulerAngles.y, zRotationLock);

        //Check if the player is attempting to interact with anything
        checkForInteractions();

        if(currentNPCInteractingWith != null && interacting == false)
        {
            interacting = true;

            currentNPCInteractingWith.GetComponent<QuestGiver>().createNPCInteractionScreen();
        }
    }

    //Perform key listens from player for interactions
    private void checkForInteractions()
    {
        if (Input.GetKeyDown(ctrl.Interact))
        {
            //Check what the player is interacting with
            checkInteraction();
        }
    }

    private void checkInteraction()
    {
        RaycastHit hit;

        if(Physics.Raycast(Input.mousePosition, new Vector3(0f,0f,interactDistance), out hit))
        {
            if (hit.collider.CompareTag("NPC"))
            {
                currentNPCInteractingWith = hit.collider.gameObject;
            }
        }
    }

    private void calculateCameraRotation()
    {
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * lookSensitivity;

        motor.rotateCamera(cameraRotation.x);
    }

    private void calculateRotation()
    {
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * lookSensitivity;

        //Apply rotation
        motor.rotate(rotation);
    }

    private void calculateMovement()
    {
        //Calculate movement as 3D Vector
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        //Final movement vector
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.move(velocity);
    }

}
