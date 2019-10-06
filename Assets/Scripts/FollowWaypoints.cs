using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    public Collider[] Waypoints;

    public int CurrentWaypoint;

    public float RotationSharpness = 0.85f;

    private new Transform transform;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }

    public void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((Waypoints[CurrentWaypoint].transform.position - transform.position).normalized), RotationSharpness * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == Waypoints[CurrentWaypoint])
        {
            CurrentWaypoint = (CurrentWaypoint + 1) % Waypoints.Length;
        }
    }
}
