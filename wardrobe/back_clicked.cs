using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_clicked : MonoBehaviour {
	public GameObject scripts;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		//scripts.GetComponent<wardrobe> ().hair_anim.SetInteger ("State", 1);
		scripts.GetComponent<wardrobe> ().isHair = true;
		scripts.GetComponent<wardrobe> ().isColor = false;
		scripts.GetComponent<wardrobe> ().color = 1;
		scripts.GetComponent<wardrobe> ().hair_type = 1;
		StartCoroutine (scripts.GetComponent<wardrobe> ().Reset ());
	}
}
