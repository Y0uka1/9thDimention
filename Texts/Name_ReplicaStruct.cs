using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Name_ReplicaStruct
{
    public CharactersName name;
    public string replica;
    public TextState state;

    public Name_ReplicaStruct(CharactersName name = CharactersName.StorryTeller, string replica = "", TextState state = TextState.Center)
    {
        this.name = name;
        this.replica = replica;
        this.state = state;
    }

    public string NameToString(CharactersName name)
    {
        switch (name)
        {
            case CharactersName.Noa:
                return "Ноа";

            case CharactersName.Rungerd:
                return "Рунгерд";
            case CharactersName.StorryTeller:
                return "";
            default:
                return "Error";
        }
    }
}
