using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Vector3 initialImpulse;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(initialImpulse, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
