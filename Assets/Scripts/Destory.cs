using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour {
    public float time=1.5f;
	// Use this for initialization
	void Start () {
        GameObject.Destroy(this.gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
