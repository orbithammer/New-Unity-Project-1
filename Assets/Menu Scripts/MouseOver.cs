using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {
	Animator animator; //the component
	public string clip1;
	public string clip2;

	// Use this for initialization
	void Start () {
		animator = GetComponent <Animator> ();
		animator.Play (clip2,0,1f); //start the state in layer 0 at the end of its animation
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown () {
//		print ("ouch!");
	}
	void OnMouseEnter() {
		animator.Play (clip1);
	}
	void OnMouseExit () {
		animator.Play (clip2);
	}
}
