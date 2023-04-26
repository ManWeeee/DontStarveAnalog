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

    public int Id
    {
        get { return id; }
    }

    public string Name
    {
        get { return name; }
    }

    public Sprite Sp
    {
        get { return _sp; }
    }
}
