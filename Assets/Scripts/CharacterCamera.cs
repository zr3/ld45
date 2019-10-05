using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    [Header("State")]
    public Transform Target;

    [Header("Configuration")]
    public Vector3 LookOffset;
    public Vector3 Offset;
    public float MoveSmoothness = 0.3f;
    public float LookSharpness = 0.7f;

    private Vector3 lookTarget;
    private Vector3 rigPosition;

    private Vector3 translateVelocity;

    private new Transform transform;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        if (Target)
        {
            rigPosition = Target.position
                + Target.right * Offset.x
                + Target.up * Offset.y
                + Target.forward * Offset.z;

            lookTarget = Target.position
                + Target.right * LookOffset.x
                + Target.up * LookOffset.y
                + Target.forward * LookOffset.z;
        }

        transform.position = Vector3.SmoothDamp(transform.position, rigPosition, ref translateVelocity, MoveSmoothness);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((lookTarget - transform.position).normalized, Vector3.up), LookSharpness * Time.deltaTime);
    }
}
