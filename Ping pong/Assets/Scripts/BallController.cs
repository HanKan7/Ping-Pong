using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector3 initialPos;
    public Rigidbody ballRigidbody;

    public PlayerMovement player;
    public Table table;
    public AILoseTrigger aiLost;
    public SideTrigger rightSideTrigger;
    public SideTrigger leftSideTrigger;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        ballRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.tapToContinue == true)
        {
            ballRigidbody.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            ballRigidbody.velocity = Vector3.zero;
            transform.position = initialPos;
            ResetValues();
        }
    }

    void ResetValues()
    {
        aiLost.playerWonPoint = false;
        rightSideTrigger.Reset();
        leftSideTrigger.Reset();
        table.Reset();

    }
}
