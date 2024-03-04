using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLine : MonoBehaviour
{
    [SerializeField] private Vector2 Xlimits = new Vector2(-2, 2);
    [SerializeField] private float _speed = 0.05f;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private Transform _target;

    private float _velocity;

    private Vector3 pointOnPlane;

    private void Update()
    {
        _line.SetPosition(0, transform.position);
        _line.SetPosition(1, _target.transform.position);

        Plane plane = new Plane(transform.forward, transform.position);

        Vector3 direction = _target.position - transform.position;
        Ray ray = new Ray(_target.transform.position, transform.forward);
        plane.Raycast(ray, out float distance);

        pointOnPlane = ray.GetPoint(distance);
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 5f);

        transform.position = new Vector3(transform.position.x, transform.position.y,
            Mathf.SmoothDamp(transform.position.z, pointOnPlane.z, ref _velocity , _speed));
        
        

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, Xlimits.x, Xlimits.y),
            transform.localPosition.y, transform.localPosition.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pointOnPlane, 0.2f);
    }
}