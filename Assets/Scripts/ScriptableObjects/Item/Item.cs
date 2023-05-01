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
    int maxStack = 1;
    [SerializeField]
    float harvestRadius;
    [SerializeField]
    private int strength;

    public int GetId => id;

    public string GetName => name; 

    public Sprite GetSprite => _sp;

    public int GetMaxStack => maxStack;

    public float GetHarvestRadius => harvestRadius;

    public int GetStrength => strength;
}
