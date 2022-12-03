using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody rigidbodyCan;
    AudioPlayer audioPlayer;
    AudioSource audioSource;
    void Start()
    {
        rigidbodyCan = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioPlayer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotationCalculation(rotationThrust);
            Debug.Log("Rotating left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotationCalculation(-rotationThrust);
            Debug.Log("Rotating right");
        }
    }

    void RotationCalculation(float rotationOnThisFrame)
    {
        rigidbodyCan.freezeRotation = true; // Freezing rotation so it can be manually rotated.
        transform.Rotate(Vector3.forward * rotationOnThisFrame * Time.deltaTime);
        rigidbodyCan.freezeRotation = false; // Unfreezing rotation so the physics system can take over.
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbodyCan.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            Debug.Log("Pressed space bar - the fizz!!!");
        }
        else
        {
            audioSource.Stop();
        }
    }
}
