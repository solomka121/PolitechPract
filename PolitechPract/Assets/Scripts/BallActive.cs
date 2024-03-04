using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActive : MonoBehaviour
{

    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ball.active = ball.gameObject.GetComponent<SphereCollider>().enabled;
    }
}
