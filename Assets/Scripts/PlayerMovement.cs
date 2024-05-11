using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody playerRb;
    public Transform cam;
    public float speed = 5.0f;


    [SerializeField] private float gravity;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpHeight;

    private bool isJumping;
    public bool isPoweredUp;
    public float powerBounceStrength;
    public float powerupTime = 7f;

    [SerializeField] private LayerMask ground;

    private Rigidbody playerRB;



    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.5f);

    }

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }


    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();

        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(isGrounded());
        }


    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveVectical = Input.GetAxis("Vertical") * Time.deltaTime * speed;


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVectical);

        playerRb.AddForce(movement * speed * Time.deltaTime);

        if (movement.magnitude > 0.1f)

        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        }



    }

    private void Jump()
    {

        if (isGrounded() == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Powerup"))
        {
            isPoweredUp = true;
            Destroy(other.gameObject);
        }


    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(powerupTime);
        isPoweredUp = false;
    }



    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && isPoweredUp == true)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 bounceDir = (collision.gameObject.transform.position - transform.position);
            enemyRb.AddForce(bounceDir * powerBounceStrength, ForceMode.Impulse);

        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
            isPoweredUp = true;

        }



    }

    public void PickUpItem(GameObject WinItem)
    {
       
        {
            //Destroy(WinningItem);
            //playerRb.PickUpItem(WinningItem); 
        }

    }

    
    












}
