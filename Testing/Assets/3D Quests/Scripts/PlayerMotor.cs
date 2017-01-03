using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera playerCam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float cameraRotation = 0f;
    private float currentCameraRotation = 0f;

    [SerializeField]
    private float cameraRotationLimit;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    } 

    //Get movement vector
    public void move(Vector3 _velocity)
    {
        velocity = _velocity;
    } 

    public void rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void rotateCamera(float _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    void FixedUpdate()
    {
        performMovement();
        performRotation();
    }

    void performMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void performRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if(playerCam != null)
        {
            //Set rotation and clamp it
            currentCameraRotation -= cameraRotation;
            currentCameraRotation = Mathf.Clamp(currentCameraRotation, -cameraRotationLimit, cameraRotationLimit);

            //Apply rotation
            playerCam.transform.localEulerAngles = new Vector3(currentCameraRotation, 0f, 0f);
        }
    }
}
