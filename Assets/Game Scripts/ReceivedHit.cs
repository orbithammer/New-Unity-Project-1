using UnityEngine;
using System.Collections;

public class ReceivedHit : MonoBehaviour {
	public GameObject gameManager; //the master repository for game info
	public GameObject deadReplacement; //this will be ToastedZombie
	public GameObject smokePlume; //smoke particle system
	int damage = 0; //accumulated damage points
	bool alreadyDead = false; //flag to prevent duplicate 'deaths'

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("Game Manager"); //identify and assign the Game Manager object
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
//	void OnCollisionEnter (Collision collision) {
//		if (collision.transform.tag == "Ammo") {
			//if it was hit by something tagged as Ammo, process its destruction
//			DestroyBun ();
//		}
//	}

	void DestroyBun() {
		if (alreadyDead)
			return; //bypass the rest of the function
		alreadyDead = true; //set the flag
		if (deadReplacement) {
			//get the deadReplacvemnt's object parent
			GameObject deadParent = deadReplacement.transform.parent.gameObject;
			//instantiate the dead replacement's parent at this object's transform
			GameObject dead = (GameObject)Instantiate (deadParent, transform.position, transform.rotation);
			//trigger its default animation
			deadReplacement.GetComponent<Animator> ().Play ("Jump Shrink");
			//destroy the dead replacement's parent after a second
			Destroy (dead, 1.0f);
			GameObject plume = (GameObject) Instantiate(smokePlume, transform.position, smokePlume.transform.rotation);
			//trigger to be destroyed at its end/Durantion + max lifetime
			Destroy (plume,10f);
		}
		Destroy (gameObject, 0.001f); //destroy it after a brief pause
		//send the ammount to update the total
		gameManager.SendMessage ("UpdateCount", -1, SendMessageOptions.DontRequireReceiver);

	}
	void Terminator (int newDamage) {
		damage += newDamage; //add more damage from
		print (damage);
		if (damage > 10)
			DestroyBun (); //destroy only if there is enough damage
	}
}
