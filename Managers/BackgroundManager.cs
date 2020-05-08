using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour, IManager
{
    public ManagerStatus status { get; set; } = ManagerStatus.Offline;
    GameObject backgroundAnimated;

    public void Initialize()
    {
        backgroundAnimated = GameObject.FindGameObjectWithTag("Background");
    }

    public void OnStartAnimation()
    {
       // MoveTool.MoveToPosition(backgroundAnimated, new Vector3(5.11f, -0.003f, 1f), 0f);
    }
}
