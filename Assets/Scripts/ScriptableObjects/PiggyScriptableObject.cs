using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PiggieScriptableObject", menuName = "ScriptableObject/PiggieScriptableObject")]
public class PiggyScriptableObject : ScriptableObject
{
    public PiggyType PiggyType;
    public PiggyStats PiggyStats;
}

[System.Serializable]
public struct PiggyStats
{
    public float MaxHealth;
    public float DamageThreshold;
}

public enum PiggyType
{
    Normal,
}