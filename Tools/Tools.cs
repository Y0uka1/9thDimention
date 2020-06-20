using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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


	public static IEnumerator MakeTransparent(Image gObject, float timeToAlpha, bool positive)
	{
		MainManager.textManager.isTyping = true;
		float alpha = gObject.color.a;
		Color color = gObject.color;
		if (positive)
		{
			for(float i=0.0f; i<1.0f; i+= Time.deltaTime / timeToAlpha)
			{
				gObject.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, 0, i));
				yield return new WaitForSeconds(0.0025f);
			}
		}
		else
		{
			for (float i = 0.0f; i < 1.0f; i += Time.deltaTime / timeToAlpha)
			{
				gObject.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, 1, i));
				yield return new WaitForSeconds(0.0025f);
			}
		}
		//MainManager.textManager.isTyping = false;
	}

	public static IEnumerator MakeTransparentText(Text gObject, float timeToAlpha, bool positive)
	{
		MainManager.textManager.isTyping = true;
		float alpha = gObject.color.a;
		Color color = gObject.color;
		if (positive)
		{
			for (float i = 0.0f; i < 1.0f; i += Time.deltaTime / timeToAlpha)
			{
				gObject.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, 0, i));
				yield return new WaitForSeconds(0.0025f);
			}
		}
		else
		{
			for (float i = 0.0f; i < 1.0f; i += Time.deltaTime / timeToAlpha)
			{
				gObject.color = new Color(color.r, color.g, color.b, Mathf.Lerp(alpha, 1, i));
				yield return new WaitForSeconds(0.0025f);
			}
		}
		//MainManager.textManager.isTyping = false;
	}



	public static IEnumerator printByLetter(string text, Text ob)
	{
		//yield return MainManager.textManager.printCouroutine;
		MainManager.textManager.isTyping = true;
		ob.text = "";
		string[] textSplited = text.Split(' ');
		//ob.text = textSplited[0];
		foreach (string c in textSplited)
		{			
			ob.text += c;
			ob.text += " ";
			yield return new WaitForSeconds(0.03f);
		}
		//yield return new WaitForFixedUpdate();
		MainManager.textManager.replicaText.text = MainManager.scene1Text.GetReplica().replica;
		MainManager.textManager.isTyping = false;
		
	}


	


}
