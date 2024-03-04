using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    protected Vector3 startPoint;
    protected Vector3 finishPoint;

    protected bool order;

    protected Vector3 dif;

    protected void SetPos(int n) {
        gameObject.transform.rotation = Quaternion.EulerAngles(0, 0, 0);
        gameObject.transform.position = new Vector3(transform.position.x, 0.51f, 4.05f* n);
    }

    

    protected void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ball")
        {
            other.gameObject.GetComponent<BallController>().Flip_Z(dif.x/4.8f);
            other.gameObject.GetComponent<BallController>().tempPlayer = this;
        }
    }





    protected IEnumerator SpeedCalculator()
    {
        //Debug.Log(Vector3.Distance(startPoint, finishPoint).ToString("f1") + " / 1 sec");
        startPoint = transform.position;
        yield return new WaitForSeconds(0.2f);
        finishPoint = transform.position;
        dif = finishPoint - startPoint;
        Debug.Log(dif.x/3.2f);
        //Debug.Log(Vector3.Distance(startPoint, finishPoint).ToString("f1") + " / 1 sec");
        order = true;
    }


}
