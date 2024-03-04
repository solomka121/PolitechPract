using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerUI : MonoBehaviour
{
    public static ControllerUI controllerUI;
    [SerializeField] private Text player1Score;
    private int score1;
    [SerializeField] private Text player2Score;
    private int score2;

    public GameObject winPanel;
    public Text playerWin;

    public bool endGame;

    
    private void Awake()
    {
        controllerUI = this;
    }

    public void SetCounter(int player) {

        switch (player)
        {
            case 2:
                score1 += 1;
                player1Score.text = $"Score : {score1}";
                break;
            case 1:
                score2 += 1;
                player2Score.text = $"Score : {score2}";
                break;
        }
        // endGame = true;
        // playerWin.text = "PLayer" + player.ToString() + "   Win!";
        // winPanel.SetActive(true);
        // if(BallController.n <= 8)
        //     BallController.n++;
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
