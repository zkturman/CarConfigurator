using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ModelData
{
    [SerializeField]
    private string name;
    public string Name { get => name; }
    [SerializeField]
    private int cost;
    public int Cost { get => cost; }
    [SerializeField]
    private StatusModifier baseStats;
    public StatusModifier BaseStats { get => baseStats; }
    [SerializeField]
    private GameObject prefab;
    public GameObject Prefab { get => prefab; }
}
