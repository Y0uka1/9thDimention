﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hair4_clicked : MonoBehaviour {
	public GameObject scripts;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		if (scripts.GetComponent<wardrobe> ().hair_type != 2 && scripts.GetComponent<wardrobe> ().hair_type != 3 && scripts.GetComponent<wardrobe> ().hair_type != 4) {
			if (scripts.GetComponent<wardrobe> ().isHair) {
				//scripts.GetComponent<wardrobe> ().hair_anim.SetInteger ("State", 1);
				scripts.GetComponent<wardrobe> ().isHair = false;
				scripts.GetComponent<wardrobe> ().isColor = true;
				scripts.GetComponent<wardrobe> ().hair_type = 4;
			}
			if (scripts.GetComponent<wardrobe> ().isColor) {
				scripts.GetComponent<wardrobe> ().color = 4;
			}
		}
	}
}