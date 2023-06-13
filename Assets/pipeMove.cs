using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMove : MonoBehaviour
{

    public float moveSpeed;
    public float deadZone = -50;
    public LogicScript logic;
    public Face face;
   
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        face = GameObject.FindGameObjectWithTag("Face").GetComponent<Face>();


    }

    // Update is called once per frame
    void Update()
    {

       
            
        
        if (face.birdIsAlive == false)
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = (float)(5 + (0.35 * logic.playerScore));

            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

            if (transform.position.x < deadZone)
            {
                Destroy(gameObject);
            }
        }
        
       
    }
}
