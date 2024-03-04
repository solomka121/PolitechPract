using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : PlayerBase
{
    public int sens;
    [SerializeField] private Vector2 _xLimits = new Vector2(-1, 1);
    [SerializeField] private float _speed;
    [SerializeField] private float _progress;
    private float _reverse = 1;

    private void Start()
    {
    }

    void FixedUpdate()
    {
        if (ControllerUI.controllerUI.endGame)
            return;
        // SetPos(-1);
        //
        // Vector3 newPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        // // Debug.Log(newPos);
        // transform.position = new Vector3(Mathf.Clamp(-newPos.x * sens, -1.6f, 1.6f),
        //     transform.position.y, transform.position.z);
    }

    private void Update()
    {
        transform.localPosition =
            new Vector3(Mathf.Lerp(_xLimits.x, _xLimits.y, Mathf.Abs(_progress)),
                transform.localPosition.y, transform.localPosition.z);

        _progress += Time.deltaTime * _speed * _reverse;
        if (_progress >= 1 || _progress <= 0)
        {
            _reverse *= -1;
            _progress = Mathf.Clamp(_progress , 0, 1);
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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<BallController>().Flip_X();
        }
    }
}