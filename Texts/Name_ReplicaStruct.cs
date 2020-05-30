using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public struct Name_ReplicaStruct
{
    public CharactersName name;
    public string replica;
    public TextState state;
    public Action ScriptEvent;
    public CharacterEmotions emotion;
    public Name_ReplicaStruct(CharactersName name = CharactersName.StorryTeller, string replica = "", TextState state = TextState.Center, Action sEvent=null, CharacterEmotions emotion = CharacterEmotions.LightBlue)
    {
        this.name = name;
        this.replica = replica;
        this.state = state;
        this.ScriptEvent = sEvent;
        this.emotion = emotion;
    }

    public string NameToString(CharactersName name)
    {
        switch (name)
        {
            case CharactersName.Noa:
                return "Ноа";
            case CharactersName.Volva:
                return "Вёльва";
            case CharactersName.StorryTeller:
                return "";
            default:
                return "Незнакомец";
            
        }
    }
}
