using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {
    public Object shellExplosion;
    public AudioClip shellExplosionAudio;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(shellExplosionAudio, transform.position);
        GameObject.Instantiate(shellExplosion, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
        if (collision.collider.tag == "Tank")
        {
            collision.collider.SendMessage("Damage");
        }
    }
}
