using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeItem : MonoBehaviour {
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
		if (scripts.GetComponent<script> ().isItem == true) {
			scripts.GetComponent<script> ().itemTaked = true;
		}
		if (scripts.GetComponent<script> ().isItem == false && scripts.GetComponent<script> ().isChoice == false) {
			text = click_obj.GetComponent<clicked> ().text;
			text++;
			click_obj.GetComponent<clicked> ().text++;
			StartCoroutine (scripts.GetComponent<script> ().List (text));
		}
	}
}
