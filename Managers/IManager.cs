using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManager 
{
    ManagerStatus status { get; set; }
    void Initialize();
}
