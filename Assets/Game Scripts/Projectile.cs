using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//destroy the object if this script is on 3 seconds after instantiation
		Destroy (gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter () {
		//destroy this object if this script is on 2 seconds after instantiation
		Destroy (gameObject, 2f);
	}
}
