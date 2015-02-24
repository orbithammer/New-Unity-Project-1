using UnityEngine;
using System.Collections;

public class RandomSound : MonoBehaviour {
	public AudioClip[] soundFX; //audio clips


	// Use this for initialization
	void Start () {
		int num = Random.Range(0,soundFX.Length); //get a random number
		audio.PlayOneShot(soundFX[num]);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
