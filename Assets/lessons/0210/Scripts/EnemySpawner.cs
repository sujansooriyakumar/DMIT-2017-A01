using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public void Spawn(EnemySO enemyData, int hp)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject tmp = Instantiate(enemyData.prefab, spawnPoint.position, Quaternion.identity);

        Enemy e = tmp.GetComponent<Enemy>();
        e.HP = hp;
        e.ATK = enemyData.ATK;
        e.DEF = enemyData.DEF;
    }
}

