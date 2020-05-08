using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choiceForMoney : MonoBehaviour {
	public GameObject scripts;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (scripts.GetComponent<script> ().choiceForTime == true) {
		}
	}
	public IEnumerator check(int cost){
		if(cost <= scripts.GetComponent<script> ().money){
			scripts.GetComponent<script> ().money -= cost;
			StartCoroutine (send ());
		}
		yield return null;
	}
	public IEnumerator send(){
		scripts.GetComponent<script> ().choice = 1;
		scripts.GetComponent<script> ().choiceDone = true;
		yield return null;
	}
}
