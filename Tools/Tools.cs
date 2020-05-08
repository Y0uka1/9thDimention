using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
   public static void MoveToPosition(GameObject otm, Vector3 position, float timeToMove)
	{
		var currentPos = otm.transform.position;
		var time = 0f;
		while (time < 1)
		{
			time += Time.deltaTime / timeToMove;
			otm.transform.position = Vector3.Lerp(currentPos, position, time);
			
		}
	}


	public static void MakeTransparent(GameObject gObject, float timeTo)
	{
		var time = 0f;
		while (time < 1)
		{
			time += Time.deltaTime / timeTo;
			Material mat = gObject.GetComponent<Renderer>().material;
			Color color = mat.color;
			color.a = time;
			mat.color = color;
		}
	}

	public static IEnumerator printByLetter(string text, UnityEngine.UI.Text ob)
	{
		MainManager.textManager.isTyping = true;
		ob.text = "";
		foreach (char c in text)
		{
			ob.text += c;
			yield return new WaitForFixedUpdate();
		}
		MainManager.textManager.isTyping = false;
	}
}
