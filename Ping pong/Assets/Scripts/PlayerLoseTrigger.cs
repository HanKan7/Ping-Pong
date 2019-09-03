using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoseTrigger : MonoBehaviour
{
    public bool aiWonPoint = false;

    public Table table;
    public TapToServe tts;
    public BallController ball;
    public AIPlayerMovement ai;
    public PlayerMovement player;
    public ScoreManager score;

    private void OnTriggerEnter(Collider other)
    {
        AIWinsPoint();
        Reset();
        
    }

    void AIWinsPoint()
    {
        if(ai.aiHits == true && table.tableHitByAI == true)
        {
            Debug.Log("Player got Beaten");
            aiWonPoint = true;
            score.aiScore++;
            score.textAI.text = score.aiScore.ToString();
        }
    }

    private void Reset()
    {
        //aiWonPoint = false;
        table.Reset();
       // if (score.someoneWon == false)
        {
            tts.Panel.SetActive(true);
        }
        player.tapToContinue = false;
        ball.ballRigidbody.useGravity = false;
        ball.ballRigidbody.velocity = Vector3.zero;
        ball.transform.position = ball.initialPos;
    }
}
