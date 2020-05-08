using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color1_clicked : MonoBehaviour {
	public GameObject scripts;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){
		scripts.GetComponent<wardrobe> ().color = 1;
	}
}
