using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField]
    int id;
    [SerializeField]
    string name = "";
    [SerializeField]
    Sprite _sp;
    [SerializeField]
    int maxStack;
    [SerializeField]
    float harvestRadius;

    public int GetId
    {
        get { return id; }
    }

    public string GetName
    {
        get { return name; }
    }

    public Sprite GetSp
    {
        get { return _sp; }
    }
    public int GetMaxStack { 
        get {return maxStack;}
    }

    public float GetHarvestRadius
    {
        get { return harvestRadius;}
    }
}
