using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicked : MonoBehaviour {
	public GameObject scripts;
	public int text;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnMouseDown(){
		if (scripts.GetComponent<script> ().isChoice == false && scripts.GetComponent<script> ().isItem == false) {
			text++;
			Debug.Log ("Sd");
			StartCoroutine (scripts.GetComponent<script> ().List (text));
		}
	}
}
