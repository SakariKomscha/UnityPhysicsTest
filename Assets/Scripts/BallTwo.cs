using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTwo : MonoBehaviour
{
    [SerializeField]
    private Vector3 initialVelocity;

    [SerializeField]
    private float minVelocity = 10f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rigidiB;

    private void OnEnable()
    {
        rigidiB = GetComponent<Rigidbody>();
        rigidiB.velocity = initialVelocity;
    }

    private void Update()
    {
        lastFrameVelocity = rigidiB.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        rigidiB.velocity = direction * Mathf.Max(speed, minVelocity);
    }
}


