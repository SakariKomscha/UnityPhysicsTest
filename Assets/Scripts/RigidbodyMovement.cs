﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;

    [SerializeField] private LayerMask FloorMask;
    [SerializeField] private Transform FeetTransform;
    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private Rigidbody PlayerBody;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;
    [SerializeField] private float Jumpforce;

    //private PlayerFootStepSound player_Footsteps;
    //public AudioSource FootAudioSource;
    //public AudioClip[] FootstepSounds;
    /*public float FootstepLength;
    public AudioClip JumpSound;
    public AudioClip LandingSound;*/

    
    void Awake()
    {
        //player_Footsteps = GetComponentInChildren<PlayerFootStepSound>();
    }

    // Update is called once per frame
    private void Update()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MovePlayerCamera();
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.CheckSphere(FeetTransform.position, 0.1f, FloorMask))
            {
                PlayerBody.AddForce(Vector3.up * Jumpforce, ForceMode.Impulse); 
                //FootAudioSource.PlayOneShot(JumpSound);
            }
            
        }
    }

    private void MovePlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    /*void PlayFootstep()
    {
         int n = Random.Range(1, FootstepSounds.Length);
         FootAudioSource.clip = FootstepSounds[n];
         FootAudioSource.PlayOneShot(FootAudioSource.clip);
         FootstepSounds[n] = FootstepSounds[0];
         FootstepSounds[0] = FootAudioSource.clip;
        
    }*/
}
