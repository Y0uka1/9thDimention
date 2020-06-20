using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PickerButton : MonoBehaviour
{
    Button button;
    AudioSource soundBuff;
    public GameObject Picker;
    public Image itemImg;

    public WardrobeIDDictionary.SpriteDictionary item;

    void Start()
    {
        button = GetComponent<Button>();
        AudioClip clip = Resources.Load<AudioClip>("Audio/pick");
        soundBuff = GetComponent<AudioSource>();
        soundBuff.clip = clip;
        button.onClick.AddListener(OnClick);
    }


    void OnClick() {
        StartCoroutine(PlaySound());
        button.interactable = false;
     }

    IEnumerator Clicked()
    {
        StartCoroutine(Tools.MakeTransparent(itemImg, 0.5f, true));
        yield return StartCoroutine(Tools.MakeTransparent(Picker.transform.GetChild(0).GetComponent<Image>(), 0.5f, true));
        TapSpace.image.raycastTarget = true;
        Destroy(Picker);
    }

    IEnumerator PlaySound()
    {
        soundBuff.Play();
        WardrobeIDDictionary.itemDictionary.Add(item);
        yield return StartCoroutine(Clicked());
        //new WaitForSeconds(soundBuff.clip.length + 0.1f);
        TapSpace.image.raycastTarget = true;
        TapSpace.Next();
        
    }
}
