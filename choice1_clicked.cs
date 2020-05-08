using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choice1_clicked : MonoBehaviour {
	public GameObject scripts, click_obj;
	public int text, cost;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
	}
	public void OnMouseDown()
	{
		if (scripts.GetComponent<script> ().isChoice == true && scripts.GetComponent<script> ().choiceForMoney == false) {
			scripts.GetComponent<script> ().choice = 1;
			scripts.GetComponent<script> ().choiceDone = true;
		}
		if (scripts.GetComponent<script> ().isChoice == true && scripts.GetComponent<script> ().choiceForMoney == true) {
			StartCoroutine (check(cost));
		}
		if (scripts.GetComponent<script> ().isChoice == false && scripts.GetComponent<script> ().isItem == false) {
			text = click_obj.GetComponent<clicked> ().text;
			text++;
			click_obj.GetComponent<clicked> ().text++;
			StartCoroutine (scripts.GetComponent<script> ().List (text));
		}
	}
	public IEnumerator check(int cost){
		StartCoroutine(scripts.GetComponent<choiceForMoney> ().check(cost));
		yield return null;
	}
}
