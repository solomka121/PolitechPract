using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public PlayerBase tempPlayer;

    Vector3 velocity;

    [Range(0, 1)]
    public float speed = 0.05f;

    public Material[] materials;

    public static int n;
  
    void Start()
    {
        gameObject.GetComponent<Renderer>().material = materials[n];
        ResetBall();
    }

    public void ResetBall() {
        tempPlayer = null;
        transform.position = new Vector3(0, transform.position.y, 0);
        float z = Random.Range(0, 2) * 2f - 1f;
        float x = Random.Range(0, 2) * 2f - 1f;
        velocity = new Vector3(x, 0, z);
    }


    void FixedUpdate()
    {
        if (ControllerUI.controllerUI.endGame)
            return;
        //Debug.Log(velocity.normalized);
       velocity = velocity.normalized * speed;

       transform.position += velocity;
    }

    public void Flip_X(float x = 0)
    {
        velocity.x *= -1f;
        // velocity.z *= Random.Range(0, 2) * 2f - 1f;
        velocity.x += x;
    }

    public void Flip_Z(float x = 0)
    {
        velocity.z *= -1f;
        //Debug.Log(x);
        velocity.x += x;
        speed += 0.001f;
    }
}
