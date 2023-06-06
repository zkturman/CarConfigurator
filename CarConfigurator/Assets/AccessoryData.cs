using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

[Serializable]
public class AccessoryData
{
    [SerializeField]
    private string accessoryName;
    public string AccessoryName { get => accessoryName; }
    [SerializeField]
    public string elementName;
    public string ElementName { get => elementName; }
    [SerializeField]
    private Sprite icon;
    public Sprite Icon { get => icon; }
    [SerializeField]
    private int cost;
    public int Cost { get => cost; }
    [SerializeField]
    private StatusModifier modifiers;
    public StatusModifier Modifier { get => modifiers; }
}
