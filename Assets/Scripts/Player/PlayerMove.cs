using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbodyPlayer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float friction;
    [SerializeField] private bool grounded;
    [SerializeField] private float maxSpeed;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform aimTransform;

    public bool Grounded { get { return grounded; } }

    //private float _rotationSpeed = 15f;
    private int _jumpFrameCounter;
    private int _directionPlayer;
    private void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || grounded == false)
        {
            playerTransform.localScale = Vector3.Lerp(playerTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            playerTransform.localScale = Vector3.Lerp(playerTransform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 15f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                Jump();

            }
        }

        Vector3 aimPosition = aimTransform.position;
        float relativeX = aimPosition.x - transform.position.x;
        _directionPlayer = (relativeX > 0) ? -1 : 1;
        //Quaternion targetRotation = Quaternion.Euler(0f, angleY, 0f);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        rigidbodyPlayer.AddForce(0, jumpSpeed, 0, ForceMode.VelocityChange);
        _jumpFrameCounter = 0;
    }

    private void FixedUpdate()
    {
        rigidbodyPlayer.AddForce(0, 0, 0, ForceMode.VelocityChange);

        float speedMultiplier = 1f;
        if (grounded == false)
        {
            speedMultiplier = 0.2f;
            if (rigidbodyPlayer.velocity.x > maxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0;
            }
            if (rigidbodyPlayer.velocity.x < -maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }

        rigidbodyPlayer.AddForce(Input.GetAxis("Horizontal") * moveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        if (grounded)
        {
            rigidbodyPlayer.AddForce(-rigidbodyPlayer.velocity.x * friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 10f);
        }

        _jumpFrameCounter += 1;
        if (_jumpFrameCounter == 2)
        {
            rigidbodyPlayer.freezeRotation = false;
            rigidbodyPlayer.AddRelativeTorque(0f, 0f, _directionPlayer * 10f, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45f)
            {
                grounded = true;
                rigidbodyPlayer.freezeRotation = true;
            }
            else
            {
                grounded = false;
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }
}
