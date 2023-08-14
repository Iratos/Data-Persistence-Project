using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneManagerScript: MonoBehaviour
{

    

    public TMP_InputField playerName;
    public  Button startButton;

    public string erroMsg = "Please enter your name";
    public string enterMsh = "Enter your name here";
    private Text enterNewName;
    void Start()
    {
        
        playerName.text = enterMsh;

    }


   public  void StartGame()
    {
        
        string username = playerName.text;

        if ( enterMsh == username || erroMsg == username)
        {
            playerName.text = erroMsg;
        }
         else
        {
            playerName.text = playerName.text;
            
            PlayersAndScores.Instance.SavePlayer();
            PlayersAndScores.Instance.LoadPlayer();
            SceneManager.LoadScene(1);
                        
        }
        
    }

    //public void PlayerNamePlaying()
    //{

        //PlayersAndScores.Instance.playerName = playerName.text;

    //}

}
