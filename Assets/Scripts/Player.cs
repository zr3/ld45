using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum Song
    {
        Windwards,
        SlowJig,
        SadShanty,
        HappyJig,
        ToThePast,
        NorthEldritch,
        SouthEldritch
    }

    [Header("State")]
    public Quaternion IntendedDirection;
    public Vector3 WorldVelocity;
    public float PowerFactor = 5;
    public bool SailActive = false;
    public bool SailAvailable = false;
    public int SelectedSong = 0;
    public List<Song> KnownSongs;

    [Header("Configuration")]
    public float RotationSensitivity = 360;
    public float RotationSharpening = 3;
    public float KeelDrag = 5;
    public float MaxSpeed = 4;

    public float Power = 0;
    public float Drag = 0;

    private new Transform transform;

    public static Player Instance;

    private void Awake()
    {
        Instance = this;
        KnownSongs = new List<Song>(5);
    }

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
        SailActive = SailAvailable && Input.GetKey(KeyCode.LeftShift);
        if (Input.GetKeyDown(KeyCode.Q) && KnownSongs.Any())
        {
            SelectedSong--;
            if (SelectedSong < 0) SelectedSong = KnownSongs.Count - 1;
        }
        if (Input.GetKeyDown(KeyCode.E) && KnownSongs.Any())
        {
            SelectedSong++;
            if (SelectedSong >= KnownSongs.Count) SelectedSong = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && KnownSongs.Any())
        {
            GameOrchestrator.Instance.PlaySong(KnownSongs[SelectedSong]);
        }
    }

    private void HandlePhysics()
    {
        // rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, IntendedDirection, Time.deltaTime * RotationSharpening);
        var ea = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, ea.y, 0);

        // add power
        var deltaVelocity = Vector3.zero;
        var sailFactor = SailActive ? 2 : 1;
        if (WorldVelocity.magnitude < MaxSpeed * sailFactor)
        {
            var effectivePowerFactor = PowerFactor * sailFactor;
            deltaVelocity += Power * effectivePowerFactor * transform.forward * Time.deltaTime;
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

        // translate and set y
        transform.position = new Vector3(
            transform.position.x + WorldVelocity.x * Time.deltaTime,
            0,
            transform.position.z + WorldVelocity.z * Time.deltaTime
        );
    }

    void FixedUpdate()
    {
    }

    void Update()
    {
        HandleInput();
        HandlePhysics();
    }

    void OnCollisionEnter(Collision collision)
    {
        WorldVelocity /= -2;
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
