using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    [SerializeField] private int Value = 100;

    private GameManagerScript gm; //Store the Game Manager Script

    private void Start()
    {
        //Safely set the Game Manager Script
        if (GameObject.FindGameObjectWithTag("Game Manager") != null)
        {
            gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManagerScript>();
        }
        else
        {
            Debug.LogError("Ball Script: Game Manager not found");
        }
    }

    //If something Collides with this object destroy it
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gm.IncreaseScore(Value);

        Destroy(gameObject);
    }
}
