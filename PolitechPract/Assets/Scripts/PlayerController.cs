using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    private enum Player{ 
        Player1,
        Player2
    }

    [SerializeField]
    Player player;

    int score = 0;


    private void FixedUpdate()
    {
        // if (player == Player.Player1) {
        //     gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.51f, 3.8f);
        // }
        //
        // if (player == Player.Player2)
        // {
        //     gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.51f, -3.8f);
        // }
        //
        //
        // gameObject.transform.rotation = Quaternion.EulerAngles(0, 0, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<BallController>().Flip_X();
        }
    }
}
