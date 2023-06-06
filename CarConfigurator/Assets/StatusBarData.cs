using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StatusBarData
{
    [SerializeField]
    private string statusLabel = "Stat";
    public string StatusLabel { get => statusLabel; }
    [SerializeField]
    private string statusElementName;
    public string StatusElementName { get => statusElementName; }
}
