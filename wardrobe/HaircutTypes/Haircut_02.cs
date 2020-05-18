using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Haircut_02 : ACHaircut
{
    void Start()
    {
        typeImage = this.transform.GetChild(0).GetComponent<Image>();
        typeImage.sprite = Resources.Load<Sprite>("Wardrobe/Haircut/Hair_02_Brown");
        /*colors = new List<Sprite>
        {
            Resources.Load<Sprite>("Wardrobe/Haircut/Hair_02_Brown"),
            Resources.Load<Sprite>("Wardrobe/Haircut/Hair_02_Black")
        };
        */
        colors = new List<WardrobeIDDictionary.SpriteDictionary>()
        {
            new WardrobeIDDictionary.SpriteDictionary(2,"Wardrobe/Haircut/Hair_02_Brown"),
            new WardrobeIDDictionary.SpriteDictionary(3, "Wardrobe/Haircut/Hair_02_Black"),
        };
    }

}
