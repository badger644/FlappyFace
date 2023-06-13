using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Face : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive;
    
   

    // Start is called before the first frame update
    void Start()
    {
        birdIsAlive = true; 
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        
        if ((transform.position.y < -18) && (transform.position.y > -19))
        {
            if (logic.alreadyPlayed == false)
            {
                logic.Explosion.Play();
                logic.alreadyPlayed = true;
            }


        }
        
        if (transform.position.y < -20)
            {
            birdIsAlive = false;
        }
        if (birdIsAlive == false)
        {
            logic.gameOver();
        }

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (logic.alreadyPlayed == false)
        {
            logic.Explosion.Play();
            logic.alreadyPlayed = true;
        }
        birdIsAlive = false;
    }    
   
}
