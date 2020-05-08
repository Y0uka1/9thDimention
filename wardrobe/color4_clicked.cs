using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color4_clicked : MonoBehaviour {
	public GameObject scripts;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		if (scripts.GetComponent<wardrobe> ().hair_type != 3 && scripts.GetComponent<wardrobe> ().hair_type != 4) {
			scripts.GetComponent<wardrobe> ().color = 4;
		}
	}
}
