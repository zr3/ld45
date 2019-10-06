using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Target;
    private new Transform transform;

    public bool X;
    public bool Y;
    public bool Z;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }
    void Update()
    {
        if (Target)
        {
            transform.position = new Vector3(
                X ? Target.position.x : transform.position.x,
                Y ? Target.position.y : transform.position.y,
                Z ? Target.position.z : transform.position.z
            );
        }
    }
}
