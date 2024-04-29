using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{

    public float timeRemaining = 10.0f;
    public Text startText; //used for showing countdown i think I need to use a diff set of code
    public WinningItem winningItem;
    public bool timerIsRunning = false;
    private Rigidbody playerRB;
    private Text timeText; 

    // Update is called once per frame

    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timeRemaining > 0)
        { timeRemaining -= Time.deltaTime; }

        else
        {
            Debug.Log("You Win");
            timeRemaining = 0;
            timerIsRunning = false;
        }

    }
    private void OnTriggerEnter(Collider playerRB)
    {
        if (playerRB.CompareTag("WinItem"))
        {
            winningItem.PickUpItem = true; 
            timerIsRunning = true;
           
        }
    }

    void DisplayTime(float timeToDisplay)
    {

        timeToDisplay = -10f; 

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{10;00}", minutes, seconds);



    }



}
