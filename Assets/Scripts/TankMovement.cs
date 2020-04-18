using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

    public float speed = 5;
    public float angularSpeed = 30;
    private Rigidbody rig;
    public int number = 1;

    public Camera followCamera;
    public Vector3 offset;
    public float smoothing = 3;
    public float angle = 30;

    public AudioClip idelAudio;
    public AudioClip drivingAudio;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        offset = followCamera.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 targetPos = transform.position + transform.TransformDirection(offset);
        followCamera.transform.position = Vector3.Lerp(followCamera.transform.position, targetPos, Time.deltaTime * smoothing);
        followCamera.transform.LookAt(transform,Vector3.up);
        followCamera.transform.Rotate(new Vector3(angle, 0, 0));
    }
    private void FixedUpdate()
    {
        float v = Input.GetAxis("Player"+number+"Vertical");
        float h = Input.GetAxis("Player"+number+"Horizontal");
        rig.velocity = transform.forward * v * speed;
        rig.angularVelocity = transform.up * h * angularSpeed;

        if (Mathf.Abs(h)>0.1 || Mathf.Abs(v) > 0.1)
        {
            audioSource.clip = drivingAudio;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            audioSource.clip = idelAudio;
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
    }
}
