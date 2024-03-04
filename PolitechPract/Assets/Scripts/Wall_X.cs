using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_X : MonoBehaviour
{   
    

     void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<BallController>().Flip_X();
        }   
    }
}
