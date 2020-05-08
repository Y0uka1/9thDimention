using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {
	public GameObject background, backgroundAnimated, charLeft, charRight, textRight, textRightName, textLeft, textLeftName, textCenter, camera, music, sound, choise1, choise1Text, choise1BG, c1_click_obj, c2, tc2, co, item_name, item_icon, take_item, moneyValue;
	public Animator c1_anim, c2_anim, tr_anim, tc_anim, tl_anim, i_anim;
	public bool isRead, isChoice, isItem, choiceDone, itemTaked, choiceForTime, choiceForMoney;
	public int text, choice, money;

	// Use this for initialization
	void Start () {
		StartCoroutine (MoveToPosition(backgroundAnimated, new Vector3(5.11f, -0.003f, 1f), 0f));
	}
	
	// Update is called once per frame
	void Update () {
		moneyValue.GetComponent<UnityEngine.UI.Text> ().text = money.ToString ();
	}

	public IEnumerator MoveToPosition(GameObject otm, Vector3 position, float timeToMove)
	{
		var currentPos = otm.transform.position;
		var t = 0f;
		while(t < 1)
		{
			t += Time.deltaTime / timeToMove;
			otm.transform.position = Vector3.Lerp(currentPos, position, t);
			yield return null;
		}
	}
	public IEnumerator Alpha(GameObject ota, float timeToAlpha)
	{
		var t = 0f;
		while(t < 1)
		{
			t += Time.deltaTime / timeToAlpha;
			Material mat = ota.GetComponent<Renderer>().material;
			Color color = mat.color;
			color.a = t;
			mat.color = color;
			yield return null;
		}
	}
	public IEnumerator Hide(GameObject oth)
	{
		Material mat = oth.GetComponent<Renderer>().material;
		Color color = mat.color;
		color.a = 0f;
		mat.color = color;
		yield return null;
	}
	public IEnumerator Text(int textType, string text, string name="", bool isStarting=false)//right=1, left=2, author=3
	{
		if (textType == 1) {
			textRight.GetComponent<UnityEngine.UI.Text> ().text = "";
			textRightName.GetComponent<UnityEngine.UI.Text> ().text = name;
			if (isStarting == true) {
				tr_anim.SetInteger ("State", 1);
				StartCoroutine(printByLetter(text, textRight));
			} 
			else {
				StartCoroutine(printByLetter(text, textRight));
			}
		}
		if (textType == 2) {
			textLeft.GetComponent<UnityEngine.UI.Text> ().text = "";
			textLeftName.GetComponent<UnityEngine.UI.Text> ().text = name;
			if (isStarting == true) {
				tl_anim.SetInteger ("State", 1);
				StartCoroutine(printByLetter(text, textLeft));
			} 
			else {
				StartCoroutine(printByLetter(text, textLeft));
			}
		}
		if (textType == 3) {
			textCenter.GetComponent<UnityEngine.UI.Text> ().text = "";
			if (isStarting == true) {
				tc_anim.SetInteger ("State", 1);
				StartCoroutine(printByLetter(text, textCenter));
			} 
			else {
				StartCoroutine(printByLetter(text, textCenter));
			}
		}
		yield return null;
	}
	public IEnumerator HideText(int textType, bool anim=false){
		if (anim == true) {
			if (textType == 1) {
				tr_anim.SetInteger ("State", 2);
			}
			if (textType == 2) {
				tl_anim.SetInteger ("State", 2);
			}
			if (textType == 3) {
				tc_anim.SetInteger ("State", 2);
			}
		} else {
			if (textType == 1) {
				tr_anim.SetInteger ("State", 0);
			}
			if (textType == 2) {
				tl_anim.SetInteger ("State", 0);
			}
			if (textType == 3) {
				tc_anim.SetInteger ("State", 0);
			}
		}
		yield return null;
	}
	public IEnumerator printByLetter(string text, GameObject ob) {
		foreach(char c in text) {
			ob.GetComponent<UnityEngine.UI.Text> ().text += c;
			yield return new WaitForFixedUpdate();
		}
	}
	public IEnumerator Emotion(GameObject otc, string name)
	{
		var sprite = Resources.Load<Sprite>(name);
		otc.GetComponent<SpriteRenderer>().sprite = sprite;
		yield return null;
	}
	public IEnumerator PlayMusic(string name){
		music.GetComponent<AudioSource> ().Stop ();
		var audio = Resources.Load<AudioClip> ("music/" + name);
		music.GetComponent<AudioSource> ().clip = audio;
		music.GetComponent<AudioSource> ().Play ();
		yield return null;
	}
	public IEnumerator PlaySound(string name){
		sound.GetComponent<AudioSource> ().Stop ();
		var audio = Resources.Load<AudioClip> ("sounds/" + name);
		sound.GetComponent<AudioSource> ().clip = audio;
		sound.GetComponent<AudioSource> ().Play ();
		yield return null;
	}
	public IEnumerator Choice(int num, List<string> list, bool forTime=false, bool forMoney=false, int cost=0){
		choise1BG.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("gui/choice");
		isChoice = true;
		choiceDone = false;
		if (forTime == true) {
			choiceForTime = true;
			if (num == 2) {
				c1_anim.SetInteger ("State", 1);
				c2_anim.SetInteger ("State", 1);
				choise1Text.GetComponent<UnityEngine.UI.Text> ().text = list [0];
				tc2.GetComponent<UnityEngine.UI.Text> ().text = list [1];
				yield return new WaitUntil (() => choiceDone == true);
				c1_anim.SetInteger ("State", 2);
				c2_anim.SetInteger ("State", 2);
				isChoice = false;
				choiceForTime = false;
				co.GetComponent<clicked> ().text++;
				StartCoroutine (List (co.GetComponent<clicked> ().text));
			}
		}
		if (forMoney == true) {
			choiceForMoney = true;
			if (num == 2) {
				choise1BG.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite> ("gui/choice_paid");
				c1_anim.SetInteger ("State", 1);
				c2_anim.SetInteger ("State", 1);
				choise1Text.GetComponent<UnityEngine.UI.Text> ().text = list [0];
				tc2.GetComponent<UnityEngine.UI.Text> ().text = list [1];
				c1_click_obj.GetComponent<choice1_clicked> ().cost = cost;
				yield return new WaitUntil (() => choiceDone == true);
				c1_anim.SetInteger ("State", 2);
				c2_anim.SetInteger ("State", 2);
				isChoice = false;
				choiceForMoney = false;
				co.GetComponent<clicked> ().text++;
				StartCoroutine (List (co.GetComponent<clicked> ().text));
			}
		}
		yield return null;
	}
	public IEnumerator Item(string name, string spriteName){
		isItem = true;
		var sprite = Resources.Load<Sprite> ("items/" + spriteName);
		item_icon.GetComponent<SpriteRenderer> ().sprite = sprite;
		i_anim.SetInteger("State", 1);
		item_name.GetComponent<UnityEngine.UI.Text> ().text = name;
		yield return new WaitUntil(() => itemTaked == true);
		i_anim.SetInteger("State", 2);
		isItem = false;
		co.GetComponent<clicked> ().text++;
		StartCoroutine (List (co.GetComponent<clicked> ().text));
		yield return null;
	}
	public IEnumerator List(int text){
		if (text == 1) {
			StartCoroutine (MoveToPosition(backgroundAnimated, new Vector3(-0.004f, -0.003f, 1f), 3f));
			StartCoroutine (Text (3, "Мы расскажем вам легенду об одном юноше по имени Хальфсен. Ему предстоит очень важная миссия - спасти народы девяти миров. Не мало препятствий будет на его пути, но мы надеемся, что он справится.", "", true));
		}
		if (text == 2) {
			StartCoroutine (Text (3, "А пока он спокойно живёт в Мидгарде, мире людей, и не подозревает, что вот-вот начнется его история.", "", true));
		}
		if (text == 3) {
			StartCoroutine (HideText (3, true));
		}
		if (text == 4) {
			StartCoroutine (Alpha (charRight, 0.5f));
			StartCoroutine (MoveToPosition(charRight, new Vector3(1.14f, 0.723f, 0f), 0.5f));
			StartCoroutine (MoveToPosition(backgroundAnimated, new Vector3(-0.5f, -0.003f, 1f), 1f));
			StartCoroutine (Text (1, "Если то, что ты говоришь – правда...", "???(Рунгерд)", true));
		}
		if (text == 5) {
			StartCoroutine (HideText (1));
			StartCoroutine (Hide (charRight));
			StartCoroutine (Alpha (charLeft, 0.5f));
			StartCoroutine (MoveToPosition(backgroundAnimated, new Vector3(0.5f, -0.003f, 1f), 1f));
			StartCoroutine (MoveToPosition(charLeft, new Vector3(-1.31f, 0.723f, 0f), 0.5f));
			StartCoroutine (Text (2, "Я видел это своими глазами!", "???(Ноа)", true));
		}
		if (text == 6) {
			StartCoroutine (HideText (2));
			StartCoroutine (Hide (charLeft));
			StartCoroutine (Alpha (charRight, 0.5f));
			StartCoroutine (MoveToPosition(backgroundAnimated, new Vector3(-0.5f, -0.003f, 1f), 1f));
			StartCoroutine (Text (1, "Ты отправляешься в Мидгард, чтобы украсть священный свет, соединяющий все миры.", "???(Рунгерд)", true));
		}
		if (text == 7) {
			StartCoroutine (HideText (1));
			StartCoroutine (Hide (charRight));
			StartCoroutine (Alpha (charLeft, 0.5f));
			StartCoroutine (MoveToPosition(backgroundAnimated, new Vector3(0.5f, -0.003f, 1f), 1f));
			StartCoroutine (Text (2, "Бифрёст?", "???(Ноа)", true));
		}
		if (text == 8) {
			StartCoroutine (HideText (2));
			StartCoroutine (Hide (charLeft));
			StartCoroutine (Alpha (charRight, 0.5f));
			StartCoroutine (MoveToPosition(backgroundAnimated, new Vector3(-0.5f, -0.003f, 1f), 1f));
			StartCoroutine (Text (1, "Да, и будешь хранить его столько, сколько понадобится. Ты понял меня, Ноа?.", "???(Рунгерд)", true));
		}
		if (text == 9) {
			StartCoroutine (HideText (1));
			StartCoroutine (Hide (charRight));
			StartCoroutine (Alpha (charLeft, 0.5f));
			StartCoroutine (MoveToPosition(backgroundAnimated, new Vector3(0.5f, -0.003f, 1f), 1f));
			StartCoroutine (Text (2, "Я...", "Ноа", true));
		}
	yield return null;
	}
}
