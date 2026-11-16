using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTask5 : MonoBehaviour
{
    [SerializeField] private Apples _apple;

    [SerializeField] private Transform[] _spawners;


    private bool isWork = true;

    private float _counterInterval = 2;
    private int spawnerMinIndex = 0;

    

    private void Start()
    {
        StartCoroutine(Cooldown());
    }

    private void CreateApple() 
    {
        int spawnersIndex = Random.Range(spawnerMinIndex, _spawners.Length);
        Transform spawner = _spawners[spawnersIndex];

       // int appleIndex = Random.Range(0, _apples.Length);

        Apples apples = Instantiate(_apple, spawner.position, transform.rotation);

    }

    private IEnumerator Cooldown()
    {
        while (isWork)
        {
            yield return new WaitForSeconds(_counterInterval);
            CreateApple();
        }
    }
}
