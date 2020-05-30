using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Scene1Text : ScriptableObject, IManager
{
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    public  List<Name_ReplicaStruct> ReplicaList;
  [SerializeField]  public   int index;
    Chapter1Events events;

    public void Initialize()
    {
        events = GameObject.FindObjectOfType(typeof(Chapter1Events)) as Chapter1Events;
        events.Initialize();
        index = 0;
        ReplicaList = new List<Name_ReplicaStruct>() {
            new Name_ReplicaStruct(CharactersName.StorryTeller, "Мы расскажем вам легенду об одном юноше по имени Хальфсен. Ему предстоит очень важная миссия - спасти народы девяти миров.", TextState.Center,null),
             new Name_ReplicaStruct(CharactersName.StorryTeller," Не мало препятствий будет на его пути, но мы надеемся, что он справится.", TextState.Center,null),
            new Name_ReplicaStruct(CharactersName.StorryTeller,"А пока он спокойно живёт в Мидгарде, мире людей, и не подозревает, что вот-вот начнется его история.", TextState.Center,null),

            new Name_ReplicaStruct(CharactersName.StorryTeller,"", TextState.Special, events.Tutorial1),

            new Name_ReplicaStruct(CharactersName.StorryTeller,"",TextState.Special, events.LidlWardrobe),

            new Name_ReplicaStruct(CharactersName.StorryTeller,"", TextState.Special, events.Tutorial2),

             new Name_ReplicaStruct(CharactersName.StorryTeller,"Здесь мы и начнём наш рассказ.", TextState.Center),

              new Name_ReplicaStruct(CharactersName.StorryTeller,"", TextState.Special, events.LoadDream),

               new Name_ReplicaStruct(CharactersName.StorryTeller,"", TextState.Special, events.FlyingCamera),

            new Name_ReplicaStruct(CharactersName.Rungerd,"Если то, что ты говоришь – правда..." , TextState.Right,null),                                              //Unknow
            new Name_ReplicaStruct(CharactersName.Noa,"Я видел это своими глазами!", TextState.Left,null),                                                        //Unknow
            new Name_ReplicaStruct(CharactersName.Rungerd,"Ты отправляешься в Мидгард, чтобы украсть священный свет, соединяющий все миры.", TextState.Right,null), //Unknow
            new Name_ReplicaStruct(CharactersName.Noa, "Бифрёст?", TextState.Left,null),                                                                            //Unknow
            new Name_ReplicaStruct(CharactersName.Rungerd,  "Да, и будешь хранить его столько, сколько понадобится. Ты понял меня, Ноа?.", TextState.Right,null), //Unknow
            new Name_ReplicaStruct(CharactersName.Noa, "Я...", TextState.Left,null)
        };

        status = ManagerStatus.Online;
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
