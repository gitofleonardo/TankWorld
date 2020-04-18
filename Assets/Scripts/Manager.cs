using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {
    public GameObject success;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Success()
    {
        success.SetActive(true);
    }
    public void reloadGame()
    {
        SceneManager.LoadScene("main");
    }
}
