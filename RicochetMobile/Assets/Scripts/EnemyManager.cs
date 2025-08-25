using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] public List<EnemyMovement> enemies;
    [SerializeField] SpawnEnemies spawnEnemies;
    void Start()
    {
        spawnEnemies = GetComponent<SpawnEnemies>();
    }
}
