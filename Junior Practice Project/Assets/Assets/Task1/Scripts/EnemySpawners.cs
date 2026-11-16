using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    [SerializeField] private Transform[] _spawners;

    private bool isWork = true;

    private float _counterInterval = 2;
    private int spawnerMinIndex = 0;

    private readonly Queue<Enemy> _enemyPool = new Queue<Enemy>();

    private void Start()
    {
        StartCoroutine(Cooldown());
    }
  
    private void CreateEnemy() 
    {
        int spawnersIndex = Random.Range(spawnerMinIndex, _spawners.Length);
        Transform spawner = _spawners[spawnersIndex];

        Vector3 spawnPosition = spawner.position;
        Vector3 direction = spawner.forward;       

        if (_enemyPool.Count > 0)
        {
            _enemy = _enemyPool.Dequeue();
            _enemy.transform.position = spawnPosition;
            _enemy.gameObject.SetActive(true);         
        }
        else
        {
            _enemy = Instantiate(_enemy, spawnPosition, transform.rotation);
        }

        _enemy.SetDirection(direction);
    }

    private IEnumerator Cooldown()
    {
        while (isWork)
        {
            yield return new WaitForSeconds(_counterInterval);
            CreateEnemy();
        }
    }
}



