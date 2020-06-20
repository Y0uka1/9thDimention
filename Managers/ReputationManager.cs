using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ReputationManager : MonoBehaviour
{ 
	GameObject panel;
	public void Choise(int count, string question, ChoiseType[] types, UnityAction[] actions, string[] answers)
	{
		TapSpace.image.raycastTarget = false;
		panel = Instantiate(Resources.Load<GameObject>("Prefabs/Choose"));
		panel.transform.SetParent(GameObject.Find("Canvas").transform);
		panel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		panel.GetComponent<RectTransform>().localScale = Vector3.one;
		panel.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = question;
		panel.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = MainManager.scene1Text.GetReplica().NameToString(MainManager.scene1Text.GetReplica().name);
		for (int i = 0; i < count; i++)
		{
			panel.transform.GetChild(i + 1).gameObject.SetActive(true);
			Image tempImage = panel.transform.GetChild(i + 1).GetComponent<Image>();
			if (types[i] == ChoiseType.Free)
			{
				tempImage.sprite = Resources.Load<Sprite>("gui/free");
			}
			else if (types[i] == ChoiseType.Paid)
			{
				tempImage.sprite = Resources.Load<Sprite>("gui/pay");
			}
			else
			{
				Debug.Log("Time");
			}
			Button button = panel.transform.GetChild(i + 1).GetComponent<Button>();
			button.onClick.AddListener(actions[i]);
			button.onClick.AddListener(() => { TapSpace.image.raycastTarget = true; });
			button.transform.GetChild(0).GetComponentInChildren<Text>().text = answers[i];
			StartCoroutine(MakeTransparentObject(panel, 0.5f, false));
		}

		
	}

	public IEnumerator Reputation(ReputationType type, string text)
	{
		GameObject temp;
		switch (type)
		{
			case ReputationType.Good:
				{
					temp = Instantiate(Resources.Load<GameObject>("Prefabs/GoodBoy"));
					break;
				}
			case ReputationType.Bad:
				{
					temp = Instantiate(Resources.Load<GameObject>("Prefabs/BadBoy"));
					break;
				}
			case ReputationType.Personal:
				{
					temp = Instantiate(Resources.Load<GameObject>("Prefabs/Relations"));
					break;
				}
			default:
				{
					temp = Instantiate(Resources.Load<GameObject>("Prefabs/Relations"));
					break;
				}
		}
		temp.GetComponentInChildren<Text>().text = text;
		temp.transform.SetParent(GameObject.Find("Canvas").transform);
		RectTransform rect = temp.GetComponent<RectTransform>();
		rect.anchoredPosition = Vector2.zero;
		rect.offsetMin = new Vector2(0, rect.offsetMin.y);
		rect.offsetMax = new Vector2(0, rect.offsetMax.y);
		rect.localScale = Vector2.one;
		StartCoroutine(Tools.MakeTransparent(temp.GetComponentInChildren<Image>(), 0.5f, false));
		yield return StartCoroutine(Tools.MakeTransparentText(temp.GetComponentInChildren<Text>(), 0.5f, false));
		yield return StartCoroutine(MakeTransparentObject(panel, 0.5f,true));
		TapSpace.Next();
		yield return new WaitForSeconds(1.5f);
		StartCoroutine(Tools.MakeTransparent(temp.GetComponentInChildren<Image>(), 0.5f, true));
		yield return StartCoroutine(Tools.MakeTransparentText(temp.GetComponentInChildren<Text>(), 0.5f, true));
		MainManager.textManager.isTyping = false;
		Destroy(panel);
	}


	public void CreatePicker(WardrobeIDDictionary.SpriteDictionary item)
	{
		GameObject Picker = Instantiate(Resources.Load<GameObject>("Prefabs/Picker"));
		Picker.transform.SetParent(GameObject.Find("Canvas").transform);
		RectTransform rect = Picker.GetComponent<RectTransform>();
		rect.anchoredPosition = Vector2.zero;
		//rect.offsetMin = new Vector2(0, rect.offsetMin.y);
		//rect.offsetMax = new Vector2(0, rect.offsetMax.y);
		rect.localScale = Vector2.one;

		Image itemImg = Picker.transform.GetChild(0).GetChild(1).GetComponent<Image>();
		itemImg.sprite = Resources.Load<Sprite>(item.path);
		PickerButton button = Picker.GetComponentInChildren<PickerButton>();
		button.item = item;
		TapSpace.image.raycastTarget = false;
		button.Picker = Picker;
		button.itemImg = itemImg;

	}

	public IEnumerator MakeTransparentObject(GameObject gObject, float timeToAlpha, bool positive)
	{
		MainManager.textManager.isTyping = true;

		Image[] images = gObject.GetComponentsInChildren<Image>();
		Text[] texts = gObject.GetComponentsInChildren<Text>();

		int max = images.Length > texts.Length ? images.Length : texts.Length;
		//bool img = images.Length > texts.Length ? true : false;

		for (int i = 0; i < max;i++)
		{
			/*if (i == max - 1)
			{
				if(img)
					yield return StartCoroutine(Tools.MakeTransparent(images[i], 0.5f, positive));
			}*/

			try
			{
				StartCoroutine(Tools.MakeTransparent(images[i], 0.5f, positive));
			}catch
			{
				Debug.Log("Image empty");
			}

			try
			{
				StartCoroutine(Tools.MakeTransparentText(texts[i], 0.5f, positive));
			}
			catch
			{
				Debug.Log("Image empty");
			}

			yield return null;
				
		}
		//MainManager.textManager.isTyping = false;
	}
}
