using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrow : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 100;

    public GameObject Grenade;
    public Transform ShotPoint;


    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject CreatedCannonball = Instantiate(Grenade, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
        }

    }
}