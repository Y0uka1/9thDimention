using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scene1Text : MonoBehaviour
{
    public  List<Name_ReplicaStruct> ReplicaList;
    public   int index;


    public void Initialize()
    {
        index = 0;
        ReplicaList = new List<Name_ReplicaStruct>() {
            new Name_ReplicaStruct(CharactersName.StorryTeller, "Мы расскажем вам легенду об одном юноше по имени Хальфсен. Ему предстоит очень важная миссия - спасти народы девяти миров." +
            " Не мало препятствий будет на его пути, но мы надеемся, что он справится.", TextState.Center),
            new Name_ReplicaStruct(CharactersName.StorryTeller,"А пока он спокойно живёт в Мидгарде, мире людей, и не подозревает, что вот-вот начнется его история.", TextState.Center),
            new Name_ReplicaStruct(CharactersName.Rungerd,"Если то, что ты говоришь – правда..." , TextState.Right),                                              //Unknow
            new Name_ReplicaStruct(CharactersName.Noa,"Я видел это своими глазами!", TextState.Left),                                                        //Unknow
            new Name_ReplicaStruct(CharactersName.Rungerd,"Ты отправляешься в Мидгард, чтобы украсть священный свет, соединяющий все миры.", TextState.Right), //Unknow
            new Name_ReplicaStruct(CharactersName.Noa, "Бифрёст?", TextState.Left),                                                                            //Unknow
            new Name_ReplicaStruct(CharactersName.Rungerd,  "Да, и будешь хранить его столько, сколько понадобится. Ты понял меня, Ноа?.", TextState.Right), //Unknow
            new Name_ReplicaStruct(CharactersName.Noa, "Я...", TextState.Left)
        };
    }

    public  Name_ReplicaStruct GetReplica()
    {
        Name_ReplicaStruct result;
        try
        {
            
            result = ReplicaList[index];
           
        }catch (ArgumentOutOfRangeException)
        {
            return new Name_ReplicaStruct(CharactersName.StorryTeller, "В коде произошло некоторое дерьмо. Скорее всего закончились реплики\n Error: ArgumentOutOfRangeException", TextState.Center);
        }
       
        return result;
    }
}
