using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : PlayerBase
{
    public int sens;

    private void Start()
    {
        order = true;
    }

    void FixedUpdate()
    {
        if (ControllerUI.controllerUI.endGame)
            return;
        SetPos(-1);

        Vector3 newPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        // Debug.Log(newPos);
        transform.position = new Vector3(Mathf.Clamp(-newPos.x * sens, -1.6f, 1.6f),
            transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if (order)
        {
            order = false;
            StartCoroutine(SpeedCalculator());
        }
    }


    //private void Start()
    //{
    //    GameObject.Find("Player_goal_2").GetComponent<GoalController>().player = this.gameObject;
    //    scoreText = GameObject.Find("Score 2").GetComponent<Text>();
    //}

    //void FixedUpdate()
    // {
    //    SetPos(-1);
    // }
}
