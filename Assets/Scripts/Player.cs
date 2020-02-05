//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]  // позволяет присваивать значение переменной в среде Unity3d
    private Rigidbody rb;

    [SerializeField]
    private float speed, sideSpeed;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private int acceleratorDelaySeconds;
    
    [SerializeField]
    private float acceleratorSpeed;

    [SerializeField]
    private int numberBallsForAcceleration;
    
    [SerializeField]
    private float speedForAcceleration;

    private int coins = 0;
    private float saveSpeed;
    private float delaySeconds;
    private bool acceleratorTime;
    private bool gameVictory;

    //public Rigidbody rb;
    // Start is called before the first frame update
    private void Start()
    {
        // rb = GetComponent<Rigidbody>();
        gameVictory = false;
        scoreText.text = "0";
        saveSpeed = speed;
        acceleratorTime = false;
        delaySeconds = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (acceleratorTime == true)
        {
            delaySeconds = delaySeconds - Time.deltaTime;  // отнимаем время
            if (delaySeconds < 0)  // время ускорения вышло
            {
                speed = saveSpeed;
                acceleratorTime = false;
                delaySeconds = 0;
            }

        }

        rb.AddForce(0, 0, speed * UnityEngine.Time.deltaTime);

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideSpeed * UnityEngine.Time.deltaTime, 0, 0, ForceMode.Impulse);
        }
        
        if (Input.GetKey("d"))
        {
            rb.AddForce(sideSpeed * UnityEngine.Time.deltaTime, 0, 0, ForceMode.Impulse);
        }
        
        if (gameVictory == false)
        {
            if (transform.position.y < 0)
            {
                gameManager.GameOver(coins);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger hit " + other.tag);
        if (other.tag == "Coin")
        {
            coins++;

            if (coins == numberBallsForAcceleration)
            {
                speed = speedForAcceleration;
            }

            Destroy(other.gameObject);
        }
        if (other.tag == "Accelerator")
        {
            saveSpeed = speed;
            speed = acceleratorSpeed;
            acceleratorTime = true;  // включено ускорение на время из-за столкновения с Accelerator
            delaySeconds = acceleratorDelaySeconds;
            Destroy(other.gameObject);
        }
        if (other.tag == "FinishCube")
        {
            gameManager.GameVictory(coins);
            gameVictory = true;
        }
        scoreText.text = coins.ToString();
    }
    private void OnCollisionEnter(Collision other)  // физ.столкновение
    {
        Debug.Log("Collision hit " + other.gameObject.name);
        if (other.gameObject.tag == "Block")
        {
            this.enabled = false;
            gameManager.GameOver(coins);
        }

    }
}
