using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    private bool isJumping;
    public bool isPoweredUp;
    public float powerBounceStrength;
    public float powerupTime = 7f;





    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();  
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
      if(player != null)
        {
            enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
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
