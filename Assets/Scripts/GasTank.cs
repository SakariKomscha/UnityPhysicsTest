using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTank : MonoBehaviour
{
    public GameObject GasEffect;
    bool hasExploded = false;
    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;

        }
    }

    void OnCollisionEnter()
    {
        Instantiate(GasEffect, transform.position, transform.rotation);
    }

    void Explode()
    {
        

        Destroy(gameObject, 2);

    }

}
