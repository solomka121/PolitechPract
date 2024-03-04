using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerUI : MonoBehaviour
{
    public static ControllerUI controllerUI;

    public GameObject winPanel;
    public Text playerWin;

    public bool endGame;

    
    private void Awake()
    {
        controllerUI = this;
    }

    public void SetWinPlayer(int player) {
        endGame = true;
        playerWin.text = "PLayer" + player.ToString() + "   Win!";
        winPanel.SetActive(true);
        if(BallController.n <= 8)
            BallController.n++;
    }

    public void PlayAgain() {
        SceneManager.LoadScene("Game Process");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
