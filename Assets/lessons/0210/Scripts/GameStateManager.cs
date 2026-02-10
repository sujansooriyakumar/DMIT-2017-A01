using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public List<MapState> mapStates = new List<MapState>();
    public Transform mapParent;
    private EnemySpawner spawner;
    public void InitializeMap(int mapID_)
    {
        MapState targetMap = null;
        foreach (MapState mapState in mapStates)
        {
            if(mapState.mapID == mapID_)
            {
                targetMap = mapState;
                BeginEnemySpawn(targetMap);
                break;
            }
        }
    }

    public void BeginEnemySpawn(MapState map)
    {
        spawner = mapParent.GetComponentInChildren<EnemySpawner>();
        foreach(EnemyState enemy in map.enemyStates)
        {

            if(enemy.currentHP > 0) spawner.Spawn(enemy.enemySO, enemy.currentHP);
        }
    }
}

[Serializable] 
public class MapState
{
    public int mapID;
    public List<EnemyState> enemyStates;
}

[Serializable]
public class EnemyState
{
    public int enemyID;
    public int currentHP;
    public EnemySO enemySO;
}
