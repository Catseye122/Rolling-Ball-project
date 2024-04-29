using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPowerUp : MonoBehaviour
{
    private Rigidbody playerRb;
    public Transform cam;
    public float speed = 5.0f;

    
    private Rigidbody enemyRb;
    private GameObject player;

    private bool isJumping;
    public bool isPoweredUp;
    public float powerBounceStrength;
    public float powerupTime = 7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

         void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.CompareTag("Player") && isPoweredUp == true)
            {
                Rigidbody PlayerRb = collision.gameObject.GetComponent<Rigidbody>();

                Vector3 bounceDir = (collision.gameObject.transform.position - transform.position);
                enemyRb.AddForce(bounceDir * powerBounceStrength, ForceMode.Impulse);

            }

            if (collision.gameObject.CompareTag("PowerUp"))
            {
                isPoweredUp = true;

            }

        }















    }







}
