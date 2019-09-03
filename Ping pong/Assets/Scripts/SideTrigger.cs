using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTrigger : MonoBehaviour
{
    public bool aiWonPoint = false;
    public bool playerWonPoint = false;
    public int pointWonByPlayer = 0;
    public int pointWonByAI = 0;
    public AIPlayerMovement ai;
    public PlayerMovement player;
    public Table table;
    public TapToServe tts;
    public BallController ball;
    public ScoreManager score;

    

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
           // Debug.Log("Ball touched the sides");
            WhoWon();
        }
    }

    void WhoWon()
    {
        if (player.playerHits == true && table.tableHitByPlayer == false)
        {
            Debug.Log("AI Won Point");
            aiWonPoint = true;
            pointWonByAI = 1;
            score.aiScore++;
            score.textAI.text = score.aiScore.ToString();
            Debug.Log(aiWonPoint + " in whoWon");
            Reset();
        }

        if(ai.aiHits == true && table.tableHitByAI == true)
        {
            Debug.Log("Ai won by hitting side trigger");
            aiWonPoint = true;
            score.aiScore++;
            score.textAI.text = score.aiScore.ToString();
           // Debug.Log(aiWonPoint + "in whoWonSideTrigger");
            Reset();
        }

        if(player.playerHits == true && table.tableHitByPlayer == true)
        {
            Debug.Log("Player won by hitting side trigger");
            playerWonPoint = true;
            score.playerScore++;
            score.textPlayer.text = score.playerScore.ToString();
           // Debug.Log(playerWonPoint + "in whiWonSideTrigger");
            Reset();
        }

        if(ai.aiHits == true && table.tableHitByAI == false)
        {
            Debug.Log("Player Won Point");
            playerWonPoint = true;
            pointWonByPlayer = 1;
            score.playerScore++;
            score.textPlayer.text = score.playerScore.ToString();
            Reset();
        }
    }

    public void Reset()
    {
        aiWonPoint = false;
        playerWonPoint = false;
        // pointWonByPlayer = 0;
        //  pointWonByAI = 0;
       // if (score.someoneWon == false)
        {
            tts.Panel.SetActive(true);
        }
        player.tapToContinue = false;
        player.playerHits = false;
        ai.aiHits = false;
        table.tableHitByAI = false;
        table.tableHitByPlayer = false;
        ball.ballRigidbody.velocity = Vector3.zero;
        ball.ballRigidbody.useGravity = false;
        ball.transform.position = ball.initialPos;
       
    }
}
