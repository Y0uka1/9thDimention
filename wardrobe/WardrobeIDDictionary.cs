using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeIDDictionary
{
    public struct SpriteDictionary{
        
        public string path;
        public string name;
        public int id;

        public SpriteDictionary(string path, string name , int id)
        {
            this.name = name;
            this.path = path;
            this.id = id;
        }
    }

    public static List<SpriteDictionary> haircutDictionary = new List<SpriteDictionary>()
    {
            new WardrobeIDDictionary.SpriteDictionary("Wardrobe/Haircut/Haircut_01_Black","Тёмные короткие волосы",101),
            new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_01_Red","Рыжие короткие волосы",102),
            new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_01_Ash","Светлые пепельные короткие волосы",103),
            new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_01_Gray","Тёмные пепельные короткие волосы",104),
            new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_01_Light","Русые короткие волосы",105),
              new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_02_Gray","Тёмные пепельные длинные волосы",106),
               new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_02_Ash","Светлые пепельные длинные волосы",107),
                new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_02_Red","Русые длинные волосы",108),
                 new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_02_Black","Тёмные длинные волосы",109),
                 new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_03_Light","Русые кудрявые волосы",110),
                 new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_03_Red","Рыжие кудрявые волосы",111),
                // new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_03_Blond","Блондинистые кудрявые волосы"),
                 new WardrobeIDDictionary.SpriteDictionary( "Wardrobe/Haircut/Haircut_03_Ash","Пепельные кудрявые волосы",112),

    };

    public static List<SpriteDictionary> outfitDictionary = new List<SpriteDictionary>()
    {
        new SpriteDictionary("Wardrobe/Outfit/outfit_1","Классический наряд",201),
        new SpriteDictionary("Wardrobe/Outfit/outfit_2","Повседневный наряд",202),
        new SpriteDictionary("Wardrobe/Outfit/outfit_3","Небрежный наряд",203),
    };

    public  static string GetPathByName(int id, WardrobeItemTypeEnum type)
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
                if (i.id == id)
                    return i.path;
            }
        return null;
    }

    public static Sprite GetSpriteByName(int id, WardrobeItemTypeEnum type)
    {
        return Resources.Load<Sprite>(GetPathByName(id,type));
    }

   
}
