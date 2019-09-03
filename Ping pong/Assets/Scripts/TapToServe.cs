using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TapToServe : MonoBehaviour
{
    public GameObject Panel;
    public GameObject youWin;
    public GameObject youLose;
    public Camera cam1;
    public Camera cam2;
    public CinemachineVirtualCamera cam;


    public PlayerMovement player;
    public ScoreManager score;

    public void tapToServe()
    {
        if (score.someoneWon == false)
        {
            player.tapToContinue = true;
            player.isServing = true;
            Panel.SetActive(false);
        }
    }

    private void Update()
    {
        YouWin();
        YouLose();
    }

    public void YouWin()
    {
        if(score.playerScore >= score.totalScore)
        {
            cam1.enabled = false;
            
            score.someoneWon = true;
            youWin.SetActive(true);
            Panel.SetActive(false);
        }
    }

    public void YouLose()
    {
        if(score.aiScore >= score.totalScore)
        {
            cam1.enabled = false;
            
            score.someoneWon = true;
            youLose.SetActive(true);
            Panel.SetActive(false);
        }
    }



    public void TapToPlay()
    {
        cam1.enabled = true;
        
        score.someoneWon = false;
        score.playerScore = 0;
        score.textPlayer.text = score.playerScore.ToString();
        score.aiScore = 0;
        score.textAI.text = score.aiScore.ToString();
        Debug.Log("button is called");
        youWin.SetActive(false);
        youLose.SetActive(false);
        Panel.SetActive(true);
        Debug.Log("button is called");
    }



}
