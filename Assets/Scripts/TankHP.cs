using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHP : MonoBehaviour {
    public float HP = 1000;
    public float totalHP = 1000;
    public float critPercent=50;
    public float damageHp = 100;
    public Object tankExplosion;
    public AudioClip tankExplosionAudio;
    public Slider HPSlider;
    public int number;
    public GameObject success;

	// Use this for initialization
	void Start () {
        HPSlider.value = HP / totalHP;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void Damage()
    {
        if (HP <= 0)
        {
            return;
        }
        float val = Random.Range(0, 100);
        float reduceHP = val < critPercent ? damageHp * 1.5f : damageHp;
        HP -= reduceHP;
        HPSlider.value = HP / totalHP;
        if (HP <= 0)
        {
            GameObject.FindGameObjectWithTag("Manager").SendMessage("Success");
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position+Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
