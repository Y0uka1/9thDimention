using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardrobeIDDictionary
{
    public struct SpriteDictionary{
        public int id;
        public string path;

        public SpriteDictionary(int id, string path)
        {
            this.id = id;
            this.path = path;
        }
    }

    public static List<SpriteDictionary> dictionary = new List<SpriteDictionary>()
    {
        new SpriteDictionary(0,"Wardrobe/Haircut/Hair_01_Brown"),
        new SpriteDictionary(1,"Wardrobe/Haircut/Hair_01_Gray"),
        new SpriteDictionary(2,"Wardrobe/Haircut/Hair_02_Black"),
        new SpriteDictionary(3,"Wardrobe/Haircut/Hair_02_Brown"),
        new SpriteDictionary(4,"Wardrobe/Haircut/Hair_03_Black"),
        new SpriteDictionary(5,"Wardrobe/Haircut/Hair_03_Light"),
        new SpriteDictionary(99, "Wardrobe/Outfit"),
    };

    public  static string GetPathByID(int id)
    {
        foreach(var i in dictionary)
        {
            if (i.id == id)
                return i.path;
        }
        return null;
    }

    public static Sprite GetSpriteByID(int id)
    {
        return Resources.Load<Sprite>(GetPathByID(id));
    }
}
