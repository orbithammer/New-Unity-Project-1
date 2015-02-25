using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject explosion; //the particle system associated with projectile
	public float explosionTime = 1f; //how long the effect will last
	public float explosionRadius = 0.5f; //the radius of the effect
	public float explosionPower = 50f; //he force that will be applied to nearby objects
	public int damage = 10; //the point amount of damage delivered

	// Use this for initialization
	void Start () {
		//destroy the object if this script is on 3 seconds after instantiation
		Destroy (gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter (Collision collision) {
//		Vector3 explosionPosition = transform.position; //the projectile's position at the hit
//		Instantiate (explosion, explosionPosition, Quaternion.identity);
		//get the contact point
		ContactPoint contact = collision.contacts [0];
		//get the normal of het contact point
		Quaternion rotation = Quaternion.FromToRotation (Vector3.up, contact.normal);
		//instantiate an explosion at that point, using its normal as the orientation
		Instantiate (explosion, contact.point, rotation);
		//find all nearby colliders and put them into an array
		Collider[] hitColliders = Physics.OverlapSphere (transform.position, explosionRadius);
		//apply a force to all surrounding rigid bodies & destroy anything with a Terminator function
		foreach (Collider hit in hitColliders) {
			//tell the rigidbody or any other script attached to it that the object was hit,
			//via the Terminator script
			hit.gameObject.SendMessage ("Terminator", damage + Random.Range(0,2), SendMessageOptions.DontRequireReceiver);
			if (hit.rigidbody) {//if it has a rigidbody...
				hit.rigidbody.AddExplosionForce (explosionPower, transform.position, explosionRadius);
			}
		}
		//destroy this object if this script is on 2 seconds after instantiation
		Destroy (gameObject);
	}
}
