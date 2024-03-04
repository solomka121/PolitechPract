using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Process : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball") {
            var ball = collision.gameObject.GetComponent<BallController>();

            var parent = GetComponentInParent<ProcessController>();

            if (parent.ourPlayer != ball.tempPlayer && ball.tempPlayer != null && parent.zProcess == null) {
                parent.ZProcess(this);
            }
            else 
            if(parent.ourPlayer == ball.tempPlayer)
            {
                parent.ProcessesManager(this);
            }

            ball.ResetBall();

            if (ball.tempPlayer == null)
                return;

        }
    }
}
