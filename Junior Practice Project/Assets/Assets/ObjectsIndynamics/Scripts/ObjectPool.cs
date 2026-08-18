using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private CubeDinamic[] _cubeDinamicPrefabs;
    [SerializeField] private ChangeColor _changeColor;

    [SerializeField] private Transform _cubeSpawnPosition;
    [SerializeField] private float _poolSize;
    [SerializeField] private float _minCountSize = 2;
    [SerializeField] private float _maxCountSize = 7;
    [SerializeField] private float _minRandomIndex = 0;
    [SerializeField] private float _spawnSpread = 1.5f;

    private readonly Queue<CubeDinamic> pool = new Queue<CubeDinamic>();

    private void Start()
    {
        CreateCubeDinamic();
    }

    private void CreateCubeDinamic()
    {
        float cubeCount = Random.Range(_minCountSize, _maxCountSize);

        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-_spawnSpread, _spawnSpread), Random.Range(_minRandomIndex, _spawnSpread), Random.Range(-_spawnSpread, _spawnSpread));

            CubeDinamic prefab = _cubeDinamicPrefabs[Random.Range(0, _cubeDinamicPrefabs.Length)];

            CubeDinamic obj = Instantiate(prefab, _cubeSpawnPosition.position + offset, transform.rotation);

            pool.Enqueue(obj);

        }
    }
}
