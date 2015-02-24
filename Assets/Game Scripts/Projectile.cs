using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject explosion; //the particle system associated with projectile

	// Use this for initialization
	void Start () {
		//destroy the object if this script is on 3 seconds after instantiation
		Destroy (gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter () {
		Vector3 explosionPosition = transform.position; //the projectile's position at the hit
		Instantiate (explosion, explosionPosition, Quaternion.identity);
		//destroy this object if this script is on 2 seconds after instantiation
		Destroy (gameObject);
	}
}
