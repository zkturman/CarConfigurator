using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatusModifier
{
    [SerializeField]
    private int speed;
    public int Speed { get => speed; }
    [SerializeField]
    private int handling;
    public int Handling { get => handling; }
    [SerializeField]
    private int weight;
    public int Weight { get => weight; }
    [SerializeField]
    private int attack;
    public int Attack { get => attack; }
}
