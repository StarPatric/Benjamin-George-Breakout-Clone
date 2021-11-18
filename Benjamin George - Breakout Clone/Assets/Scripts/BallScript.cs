using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private float LaunchForce = 1000;  //Force to launch the Ball with

    private Transform Paddle;  //Store the Paddle Position
    private Vector3 InitialPos = Vector3.zero;  //Store the location of the ball in relation to the paddle

    private Rigidbody2D rb; //Store the rigidbody

    private bool isLaunched = false;    //To Check if the ball has been launched

    private float LaunchAngle_f = 0.0f;   //Used instead of creating a float Multiple Times
    private Vector2 LaunchAngle_v = Vector2.zero;   //Used instead of creating a Vector3 Multiple Times

    // Start is called before the first frame update
    private void Start()
    {
        //Set the Initial Position
        InitialPos = transform.localPosition;

        //Safely set the rigidbody
        if (GetComponent<Rigidbody2D>() != null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        else
        {
            Debug.LogError("Ball Script: Rigidbody not found");
        }

        //Safely set the Paddle
        if (transform.parent != null)
        {
            Paddle = transform.parent;
        }
        else
        {
            Debug.LogError("Ball Script: Paddle not found");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Launch the ball if space is pressed
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            LaunchBall();

            isLaunched = true;
        }
    }

    //Launches the Ball 
    private void LaunchBall()
    {
        //Un-Freeze Constraints
        rb.constraints = RigidbodyConstraints2D.None;

        //Un-Parent the Ball
        transform.SetParent(null);

        //Between -45 and 45 degrees
        LaunchAngle_f = Random.Range(-0.5f, 0.5f);

        LaunchAngle_v = new Vector2(LaunchAngle_f, 1.0f);

        rb.AddForce(LaunchAngle_v * LaunchForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //On Collision with the Death Wall
        if (collision.gameObject.CompareTag("Death Wall"))
        {
            ResetBall();
        }
    }

    //Resets the Ball, as though it had not been launched
    private void ResetBall()
    {
        //Freeze Constraints
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        //Parent the Ball
        transform.SetParent(Paddle);

        //Reset the Location
        transform.localPosition = InitialPos;

        //Enable a relaunch
        isLaunched = false;
    }
}
