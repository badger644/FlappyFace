using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pipeSpawner : MonoBehaviour
{
    public GameObject Pipe;
    public float spawnRate;
    private float timer = 0;
    public float heightOffset = 10;
    public LogicScript logic;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate = (float)(3 - (0.07 * logic.playerScore));
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;


        }


    }


    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset; 

        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
