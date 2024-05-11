using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningItem : MonoBehaviour
{
    public bool PickUpItem;
    public GameObject WinItem;
    private bool hasItem;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {


        }



    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("WinItem")) 
        {
           
            hasItem = true;
            Destroy(WinItem);



        }
        //When win object x position is = to Play x postion Hide Win object Then Start Timer or When Win Object Y position is = to Y postion Hide win objectg then start timer
        //Call function to the timer to start then call back to win screen when the timer runs out. 

        // When Timer begins if Player postion whether x or y is equal to the cage postion the continue the time if not then stop timer and unhide the win object

        // If time runs out display win text

    }
}
