using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public GameObject player;
   // public ControllerUI controllerUI;


    private void OnTriggerEnter(Collider other)
    {
        if (ControllerUI.controllerUI.endGame)
            return;
        

        if (other.gameObject.name == "p")
        {
            if (player.GetComponent<Player1>())
            {
                ControllerUI.controllerUI.SetWinPlayer(1);
               // controllerUI.SetWinPlayer(1);
            }
            else if (player.GetComponent<Player2>()) {
                ControllerUI.controllerUI.SetWinPlayer(2);
               // controllerUI.SetWinPlayer(2);
            }
        }

        if (other.gameObject.tag == "Ball") {
            other.gameObject.GetComponent<BallController>().ResetBall();
        }
    }
}
