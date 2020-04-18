using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour {
    private Transform shotterTransform;
    public GameObject shellPrefab;
    public Object shell;
    public KeyCode fireKey=KeyCode.Space;
    public float flyingSpeed = 100;
    public AudioClip shootAudio;
    public int number = 0;
    public float shooterSpeed = 0.2f;
    public float k = 0.2f;
    private float time = 0;

	// Use this for initialization
	void Start () {
        shotterTransform = transform.Find("Shooter");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(fireKey))
        {
            time += Time.deltaTime;
            if (time > k)
            {
                time = 0;
                AudioSource.PlayClipAtPoint(shootAudio, shotterTransform.position);
                GameObject g = (GameObject)GameObject.Instantiate(shell, shotterTransform.position, shotterTransform.rotation);
                g.GetComponent<Rigidbody>().velocity = g.transform.forward * flyingSpeed;
            }

        }
        float r=Input.GetAxis("Player" + number + "ShooterRotate");
        shotterTransform.Rotate(new Vector3(shooterSpeed*r,0,0));
	}
}
