using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] private float Speed;   //Movement Speed

    private Vector3 MovementVector = Vector3.zero;  //Used instead of creating a Vector3 Multiple Times

    private float RightSide, LeftSide; //To Hold the Left Side and Right Side of the Paddle
    private Vector3 ViewportSpace = Vector3.zero;   //Used instead of creating a Vector3 Multiple Times

    //The frame when a script is enabled just before any of the Update methods are called the first time.
    private void Start()
    {
        //Set the Speed in a usable Type
        MovementVector.Set(Speed, 0, 0);
    }

    //Update is called once per frame
    private void Update()
    {
        MovementControl();
    }

    //Controls Movement of the Paddle
    private void MovementControl()
    {
        CalculateSides();

        //You can keep moving left until you get to the edge of the screen
        if (LeftSide > 0)
        {
            //Move Left
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position -= MovementVector * Time.deltaTime;
            }
        }

        //You can keep moving right until you get to the edge of the screen
        if (RightSide < 1)
        {
            //Move Right
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += MovementVector * Time.deltaTime;
            }
        }
    }

    //Calculate the Left and Right Side of the Paddle
    private void CalculateSides()
    {
        //LeftSide = Mid Point - Half the Scale
        LeftSide = transform.position.x - (transform.localScale.x / 2);

        //RightSide = Mid Point + Half the Scale
        RightSide = transform.position.x + (transform.localScale.x / 2);

        //Transform Right and Left Side to Viewport Space
        ViewportSpace.Set(LeftSide, 0, 0);
        LeftSide = Camera.main.WorldToViewportPoint(ViewportSpace).x;

        ViewportSpace.Set(RightSide, 0, 0);
        RightSide = Camera.main.WorldToViewportPoint(ViewportSpace).x;
    }
}
