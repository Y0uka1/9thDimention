using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choice2_clicked : MonoBehaviour {
	public GameObject scripts, click_obj;
	public int text;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}
	public void OnMouseDown()
	{
		if (scripts.GetComponent<script> ().isChoice == true) {
			scripts.GetComponent<script> ().choice = 2;
			scripts.GetComponent<script> ().choiceDone = true;
		}
		if (scripts.GetComponent<script> ().isChoice == false && scripts.GetComponent<script> ().isItem == false) {
			text = click_obj.GetComponent<clicked> ().text;
			text++;
			click_obj.GetComponent<clicked> ().text++;
			StartCoroutine (scripts.GetComponent<script> ().List (text));
		}
	}
}
