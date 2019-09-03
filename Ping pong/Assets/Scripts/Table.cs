using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public PlayerMovement player;
    public AIPlayerMovement ai;
    //
    public bool tableHitByPlayer = false;
    public bool tableHitByAI = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            if(player.playerHits == true)
            {
                tableHitByPlayer = true; 
            }

            if(ai.aiHits == true)
            {
                tableHitByAI = true;
            }
        }
    }

    public void Reset()
    {
        tableHitByAI = false;
        tableHitByPlayer = false;
    }
}
