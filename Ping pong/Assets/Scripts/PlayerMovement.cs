using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5;
    public float force = 15;
    public float servingForce = 12;
   

    //Vector3
    Vector3 initialPos;

    //bools
    public bool playerHits = false;
    public bool pointWon = false;
    public bool tapToContinue = false;
    public bool isServing = true;
    //GameObjects
    public GameObject aimTarget;
    public GameObject ball;

    //references
    public AIPlayerMovement ai;
    public Table table;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            tapToContinue = true;
            ball.GetComponent<BallController>().ballRigidbody.useGravity = true;
            if (tapToContinue == true)
            {
                playerHits = true;
                ai.aiHits = false;
                table.tableHitByAI = false;
                if (isServing == true)
                {
                    //Debug.Log("Serving");
                    Vector3 servDir = aimTarget.transform.position - transform.position;
                    other.GetComponent<Rigidbody>().velocity = servDir.normalized * servingForce + new Vector3(0, -7, 0);
                    isServing = false;
                }
                else
                {
                    Vector3 dir = aimTarget.transform.position - transform.position;
                    other.GetComponent<Rigidbody>().velocity = dir.normalized * force + new Vector3(0, 7, 0);
                }
            }
        }
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");

        //transform.Translate(h * playerSpeed * Time.deltaTime, 0, 0);
        if (tapToContinue == true)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, ball.transform.position.x, 0.08f), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = initialPos;
        }
    }
}
