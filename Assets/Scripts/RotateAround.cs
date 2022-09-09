using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject turget;
    public float velocity;

    

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(turget.transform.position, Vector3.up, velocity * Time.deltaTime);
    }

    

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, turget.transform.position);
    }*/

}
