using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    [SerializeField] private Transform[] _spawners;
    

    private readonly Queue<Enemy> _enemyPool = new Queue<Enemy>();

    private void Update()
    {
        CreateEnemy();
    }


    private void CreateEnemy() 
    {
        int spawnersIndex = 5;

        Enemy prefab = Instantiate(_enemy, _spawners[spawnersIndex].position, transform.rotation);
        _enemyPool.Enqueue(prefab);
    }
}
