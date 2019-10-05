using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("State")]
    public Quaternion IntendedDirection;
    public Vector3 WorldVelocity;
    public float PowerFactor = 5;

    [Header("Configuration")]
    public float RotationSensitivity = 360;
    public float RotationSharpening = 3;
    public float KeelDrag = 5;
    public float MaxSpeed = 4;

    public float Power = 0;
    public float Drag = 0;

    private new Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
        IntendedDirection = transform.rotation;
        WorldVelocity = Vector3.zero;
    }

    private void HandleInput()
    {
        Vector2 directionInput = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );

        Power = Mathf.Clamp01(directionInput.y);
        Drag = Mathf.Clamp01(-directionInput.y);
        IntendedDirection *= Quaternion.AngleAxis(RotationSensitivity * Time.deltaTime * directionInput.x, Vector3.up);
    }

    private void HandlePhysics()
    {
        // rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, IntendedDirection, Time.deltaTime * RotationSharpening);
        var ea = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, ea.y, 0);

        // add power
        var deltaVelocity = Vector3.zero;
        if (WorldVelocity.magnitude < MaxSpeed)
        {
            deltaVelocity += Power * PowerFactor * transform.forward * Time.deltaTime;
        }

        // add drag
        if (Vector3.Dot(WorldVelocity, transform.forward) > 0)
        {
            deltaVelocity += Drag * PowerFactor * -transform.forward * Time.deltaTime;
        }

        // keel drag
        deltaVelocity += Vector3.Dot(WorldVelocity, transform.right) * -KeelDrag * transform.right * Time.deltaTime;

        // apply
        WorldVelocity += deltaVelocity;

        // drag
        WorldVelocity += -WorldVelocity.normalized * Time.deltaTime;

        // translate
        transform.position += WorldVelocity * Time.deltaTime;
    }

    void FixedUpdate()
    {
    }

    void Update()
    {
        HandleInput();
        HandlePhysics();
    }

    //private void OnDrawGizmos()
    //{
    //    var anchor = transform.position + Vector3.up * 2;
    //    var scale = 5f;
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawRay(anchor, Power * PowerFactor * transform.forward * Time.deltaTime * scale);
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(anchor, Vector3.Dot(WorldVelocity, transform.right) * -KeelDrag * transform.right * Time.deltaTime * scale);
    //    Gizmos.color = Color.magenta;
    //    Gizmos.DrawRay(anchor, -WorldVelocity.normalized * Time.deltaTime * scale);
    //}
}
