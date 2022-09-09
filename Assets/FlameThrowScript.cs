using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class FlameThrowScript : MonoBehaviour
{

    public float range = 100f;

    public GameObject smokeEffect;
    public Camera refCam;
    public GameObject fireStarter;
    public Transform pointShot;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        
        RaycastHit hit;
        Instantiate(fireStarter, pointShot.position, pointShot.rotation);
        if (Physics.Raycast(refCam.transform.position, refCam.transform.forward, out hit, range))
        {
            if (hit.collider.material)
                Instantiate(smokeEffect, hit.point, Quaternion.identity);
        }
    }
}
