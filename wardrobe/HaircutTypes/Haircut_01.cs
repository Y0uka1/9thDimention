using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Haircut_01 : ACHaircut
{
    void Start()
    {
        typeImage = this.transform.GetChild(0).GetComponent<Image>();
        typeImage.sprite = Resources.Load<Sprite>("Wardrobe/Haircut/Hair_01_Brown");
        /*colors = new List<Sprite>
        {
            Resources.Load<Sprite>("Wardrobe/Haircut/Hair_01_Brown"),
            Resources.Load<Sprite>("Wardrobe/Haircut/Hair_01_Gray")
        };*/

        colors = new List<WardrobeIDDictionary.SpriteDictionary>()
        {
            new WardrobeIDDictionary.SpriteDictionary(0,"Wardrobe/Haircut/Hair_01_Brown"),
            new WardrobeIDDictionary.SpriteDictionary(1, "Wardrobe/Haircut/Hair_01_Gray"),
            new WardrobeIDDictionary.SpriteDictionary(1, "Wardrobe/Haircut/Hair_01_Gray"),
            new WardrobeIDDictionary.SpriteDictionary(1, "Wardrobe/Haircut/Hair_01_Gray"),
            new WardrobeIDDictionary.SpriteDictionary(1, "Wardrobe/Haircut/Hair_01_Gray"),
            new WardrobeIDDictionary.SpriteDictionary(1, "Wardrobe/Haircut/Hair_01_Gray"),
        };
    }

}
