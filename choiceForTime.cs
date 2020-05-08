using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choiceForTime : MonoBehaviour {
	public GameObject scripts;
	public int timeLeft = 5;
	public float gameTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (scripts.GetComponent<script> ().choiceForTime == true) {
			gameTime += 1 * Time.deltaTime;
			if (gameTime >= 1) {
				timeLeft -= 1;
				gameTime = 0;
			}
			if (timeLeft == 0) {
				StartCoroutine (send ());
			}
		}
	}
	public IEnumerator send(){
		scripts.GetComponent<script> ().choice = 1;
		scripts.GetComponent<script> ().choiceDone = true;
		yield return null;
	}
}
