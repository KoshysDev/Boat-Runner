using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rigidbodyBoat;

    private void FixedUpdate()
    {
        rigidbodyBoat.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        rigidbodyBoat.AddForceAtPosition(Vector3.up * 0.12f, transform.position, ForceMode.Impulse);
    }
}
