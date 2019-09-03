using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int totalScore = 7;
    public int playerScore = 0;
    public int aiScore = 0;
    public bool someoneWon = false;
    public Text textPlayer;
    public Text textAI;
    //public TextMeshPro text;

    public AILoseTrigger aiLost;
    public PlayerLoseTrigger playerLost;
    public SideTrigger sideLeft;
    public SideTrigger sideRight;

    private void Update()
    {
       // playerScoring();
       // aiScoring();
    }
    void playerScoring()
    {
        if(aiLost.playerWonPoint == true)
        {
            playerScore++;
            aiLost.playerWonPoint = false;
            textPlayer.text = playerScore.ToString();
            //Debug.Log("playerScore in aiLost " + playerScore);
        }

        if(sideLeft.playerWonPoint == true || sideRight.playerWonPoint == true)
        {
            playerScore++;
            textPlayer.text = playerScore.ToString();
            Debug.Log("playerScore in aiSide " + playerScore);
        }

        if(sideLeft.pointWonByPlayer == 1)
        {
            playerScore++;
            textPlayer.text = playerScore.ToString();
            Debug.Log("playerScore in aiSide " + playerScore);
        }

        if(sideRight.pointWonByPlayer == 1)
        {
            playerScore++;
            textPlayer.text = playerScore.ToString();
            Debug.Log("playerScore in aiSide " + playerScore);
        }

        

    }

    void aiScoring()
    {
       // Debug.Log("fuction is called");
        if(playerLost.aiWonPoint == true)
        {
            aiScore++;
            playerLost.aiWonPoint = false;
            textAI.text = aiScore.ToString();
            Debug.Log("aiScore in playerLost " + aiScore);
        }

        if(sideLeft.aiWonPoint == true || sideRight.aiWonPoint == true)
        {
            aiScore++;
            textAI.text = aiScore.ToString();
            Debug.Log("aiScore in playerSide " + aiScore);
        }

        if(sideLeft.pointWonByAI == 1)
        {
            aiScore++;
            textAI.text = aiScore.ToString();
            Debug.Log("aiScore in playerSide " + aiScore);
        }

        if(sideRight.pointWonByAI == 1)
        {
            aiScore++;
            textAI.text = aiScore.ToString();
            Debug.Log("aiScore in playerSide " + aiScore);
        }
    }
    
}
