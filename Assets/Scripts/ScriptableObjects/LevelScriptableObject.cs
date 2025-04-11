using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "ScriptableObject/LevelScriptableObject")]
public class LevelScriptableObject : ScriptableObject
{
    public List<LevelData> LevelDataList;
}

[System.Serializable]
public struct LevelData
{
    public LevelNumber LevelNumber;
    public int MaxTriesForThisLevel;
    public List<PiggiesToSpawn> PiggiesToSpawnList;
}

[System.Serializable]
public struct PiggiesToSpawn
{
    public PiggyType PiggyType;
    public PiggyView PiggyView;
    public PiggyScriptableObject PiggyScriptableObject;
    public int NumberOfPiggies;
    public List<Vector2> SpawnPositionList;
}