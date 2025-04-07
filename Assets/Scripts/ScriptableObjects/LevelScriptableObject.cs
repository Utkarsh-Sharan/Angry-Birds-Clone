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
    public List<EnemiesToSpawn> PiggiesToSpawnList;
}

[System.Serializable]
public struct EnemiesToSpawn
{
    public PiggyType PiggyType;
    public PiggyView PiggyView;
    public int NumberOfPiggies;
    public List<Vector2> SpawnPositionList;
}