using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wardrobe : MonoBehaviour {
	public GameObject hair, backButton, color1, color2, color3, color4;
	public int hair_type = 1, color = 1, hair_type_was=1;
	public bool isHair = true, isColor;
	public Animator hair_anim;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (isHair) {
			backButton.SetActive(false);
		}
		if(isColor) {
			backButton.SetActive(true);
			StartCoroutine (ChangeTypeHairs (hair_type));
		}
		/*if (color1.transform.position.x == 1.71f) {
			hair_anim.SetInteger ("State", 0);
		}*/
		StartCoroutine (ChangeHair (hair_type, color));
	}

	public IEnumerator ChangeHair(int hair_type, int color){
		hair.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair" + hair_type + "_" + color);
		yield return null;
	}
	public IEnumerator ChangeTypeHairs(int type){
		if (hair_type_was!=type){
			color = 1;
		}
		if (type == 1) {
			hair_type_was = 1;
			color1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair1_1");
			color2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair1_2");
			color3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair1_3");
			color4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair1_4");
		}
		if (type == 2) {
			hair_type_was = 2;
			color1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair2_1");
			color2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair2_2");
			color3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair2_3");
			color4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
		}
		if (type == 3) {
			hair_type_was = 3;
			color1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair3_1");
			color2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair3_2");
			color3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
			color4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
		}
		if (type == 4) {
			hair_type_was = 4;
			color1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair4_1");
			color2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair4_2");
			color3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
			color4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
		}
		yield return null;
	}
	public IEnumerator Reset(){
		color1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair1_1");
		color2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair2_1");
		color3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair3_1");
		color4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("sprites/halfsen/hair4_1");
		yield return null;
	}
}
