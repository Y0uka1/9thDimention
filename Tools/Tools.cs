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


	public static IEnumerator MakeTransparent(UnityEngine.UI.Image gObject, float timeToAlpha, bool positive)
	{
		float alpha = gObject.color.a;
		Color color = gObject.color;
		if (positive)
		{
			for(float i=0.0f; i<1.0f; i+= Time.deltaTime / timeToAlpha)
			{
				gObject.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, 0, i));
				yield return null;
			}
		}
		else
		{
			for (float i = 0.0f; i < 1.0f; i += Time.deltaTime / timeToAlpha)
			{
				gObject.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, 1, i));
				yield return null;
			}
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
