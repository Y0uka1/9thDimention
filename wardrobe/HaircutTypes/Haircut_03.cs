using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Haircut_03 : ACHaircut
{
    void Start()
    {
        typeImage = this.transform.GetChild(0).GetComponent<Image>();
        typeImage.sprite = Resources.Load<Sprite>("Wardrobe/Haircut/Hair_03_Black");
      /*  colors = new List<Sprite>
        {
            Resources.Load<Sprite>("Wardrobe/Haircut/Hair_03_Black"),
            Resources.Load<Sprite>("Wardrobe/Haircut/Hair_03_Light")
        };*/


        colors = new List<WardrobeIDDictionary.SpriteDictionary>()
        {
            new WardrobeIDDictionary.SpriteDictionary(4,"Wardrobe/Haircut/Hair_03_Black"),
            new WardrobeIDDictionary.SpriteDictionary(5, "Wardrobe/Haircut/Hair_03_Light"),
        };
    }

}

