using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeIDDictionary
{
    public struct SpriteDictionary{
        
        public string path;
        public string name;

        public SpriteDictionary(string path, string name)
        {
            this.name = name;
            this.path = path;
        }
    }

    public static List<SpriteDictionary> haircutDictionary = new List<SpriteDictionary>()
    {
            new WardrobeIDDictionary.SpriteDictionary("Wardrobe/Haircut/Haircut_01_Black","Тёмные короткие волосы"),
            new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_01_Red","Рыжие короткие волосы"),
            new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_01_Ash","Светлые пепельные короткие волосы"),
            new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_01_Gray","Тёмные пепельные короткие волосы"),
            new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_01_Light","Русые короткие волосы"),
              new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_02_Gray","Тёмные пепельные длинные волосы"),
               new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_02_Ash","Светлые пепельные длинные волосы"),
                new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_02_Red","Русые длинные волосы"),
                 new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_02_Black","Тёмные длинные волосы"),
                 new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_03_Light","Русые кудрявые волосы"),
                 new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_03_Red","Рыжие кудрявые волосы"),
                 new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_03_Blond","Блондинистые кудрявые волосы"),
                 new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_03_Ash","Пепельные кудрявые волосы"),

    };

    public static List<SpriteDictionary> outfitDictionary = new List<SpriteDictionary>()
    {
        new SpriteDictionary("Wardrobe/Outfit/outfit_1","Классический наряд"),
        new SpriteDictionary("Wardrobe/Outfit/outfit_2","Повседневный наряд"),
    };

    public  static string GetPathByName(string name, WardrobeItemTypeEnum type)
    {
        List<SpriteDictionary> tempList = new List<SpriteDictionary>();
        
        if (type == WardrobeItemTypeEnum.Haircut)
        {
            tempList = haircutDictionary;
            
        }else if (type==WardrobeItemTypeEnum.Outfit)
        {
            tempList = outfitDictionary;
        }

            foreach (var i in tempList)
            {
                if (i.name == name)
                    return i.path;
            }
        return null;
    }

    public static Sprite GetSpriteByName(string name, WardrobeItemTypeEnum type)
    {
        return Resources.Load<Sprite>(GetPathByName(name,type));
    }

   
}
