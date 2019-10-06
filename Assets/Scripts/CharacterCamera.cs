using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    [Header("State")]
    public Transform LookTarget;
    public Transform TranslateTarget;

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
        if (LookTarget)
        {
            lookTarget = LookTarget.position
                + LookTarget.right * LookOffset.x
                + LookTarget.up * LookOffset.y
                + LookTarget.forward * LookOffset.z;
        }
        if (TranslateTarget)
        {
            rigPosition = TranslateTarget.position
                + TranslateTarget.right * Offset.x
                + TranslateTarget.forward * Offset.z;
            rigPosition.y = Offset.y;
        }

        transform.position = Vector3.SmoothDamp(transform.position, rigPosition, ref translateVelocity, MoveSmoothness);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((lookTarget - transform.position).normalized, Vector3.up), LookSharpness * Time.deltaTime);
    }
}
