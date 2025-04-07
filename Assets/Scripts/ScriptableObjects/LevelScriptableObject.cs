using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "ScriptableObject/LevelScriptableObject")]
public class LevelScriptableObject : ScriptableObject
{
    public int MaxTries;
    public List<LevelData> LevelDataList;
}

[System.Serializable]
public struct LevelData
{
    public Level Level;
    public List<EnemiesToSpawn> EnemiesToSpawn;
}

[System.Serializable]
public struct EnemiesToSpawn
{
    public PiggyType PiggyType;
    public int NumberOfPiggies;
    public List<Vector2> SpawnPosition;
}