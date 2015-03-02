using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	int currentLevel; //the currently active level
	public int gameState=0;//0,new game, 1,staging area, 2, in garden

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
	// Use this for initialization
	void Start () {
		print ("Starting " + Application.loadedLevelName);
		currentLevel = Application.loadedLevel;//its index number
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel != currentLevel) {
			currentLevel = Application.loadedLevel;
//			print ("new level = " + Application.loadedLevel + ", " + Application.loadedLevelName);
		}
	
	}
}
