using UnityEngine;
using System.Collections;

public class ChildVisibility : MonoBehaviour {
	public Component[] spriteRenderers;
	public GUILayer hudText; //the Camera GUI's GUILayer component

	// Use this for initialization
	void Start () {
		hudText = GameObject.Find ("Camera GUI").GetComponent<GUILayer> ();
		SpriteToggle (false); //turn off at start
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SpriteToggle(bool newState) {
		spriteRenderers = GetComponentsInChildren<SpriteRenderer> ();
		foreach (SpriteRenderer sprite in spriteRenderers) {
			sprite.enabled = newState;
		}
		hudText.enabled = newState;
	}
}