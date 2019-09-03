using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILoseTrigger : MonoBehaviour
{
    public bool playerWonPoint = false;

    public PlayerMovement player;
    public Table table;
    public TapToServe tts;
    public BallController ball;
    public ScoreManager score;




    private void OnTriggerEnter(Collider other)
    {
        PlayerWinsPoint();
        Reset();
        
    }

    void PlayerWinsPoint()
    {
        if(player.playerHits == true && table.tableHitByPlayer == true)
        {
            Debug.Log("AI got beaten");
            playerWonPoint = true;
            score.playerScore++;
            score.textPlayer.text = score.playerScore.ToString();
        }
    }

    private void Reset()
    {
        if (score.someoneWon == false)
        {
            tts.Panel.SetActive(true);
        }
        table.Reset();
        player.tapToContinue = false;
        ball.ballRigidbody.velocity = Vector3.zero;
        ball.ballRigidbody.useGravity = false;
        ball.transform.position = ball.initialPos;
    }
}
