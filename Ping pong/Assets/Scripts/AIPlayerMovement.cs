using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayerMovement : MonoBehaviour
{
    public float AIforce = 15;
    
    //bools
    public bool aiHits;

    //GameObjects
    public GameObject ball;
 
    //Vectors
    Vector3 ballPos;
    Vector3 targetPos;
    Vector3 initialPos;
    
    //references
    public PlayerMovement player;
    public Table table;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            aiHits = true;
            player.playerHits = false;
            table.tableHitByPlayer = false;
            targetPos = new Vector3(Random.Range(-10 , 10), 0.161f, -6);
            Vector3 dir = targetPos - transform.position;
            other.GetComponent<Rigidbody>().velocity = dir.normalized * AIforce + new Vector3(0, 7, 0);
        }
    }

    void MoveAI()
    {
        if (player.tapToContinue == true)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, ball.transform.position.x,0.08f), transform.position.y, transform.position.z);
        }

        else
        {
            transform.position = initialPos;
        }
    }
}
