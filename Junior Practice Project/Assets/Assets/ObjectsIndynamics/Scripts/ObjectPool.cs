using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{  
    [SerializeField] private CubeDinamic[] _cubeDinamicPrefabs;
    [SerializeField] private Transform _cubeSpawnPosition;
   
    [SerializeField] private int _minCountSize = 2;
    [SerializeField] private int _maxCountSize = 7;
    [SerializeField] private float _minRandomIndex = 0;
    [SerializeField] private float _spawnSpread = 1.5f;

    private readonly Queue<CubeDinamic> _pool = new Queue<CubeDinamic>();

    private void Start()
    {
        SpawnCube();
    }

    public void SpawnCube()
    {
        int cubeCount = Random.Range(_minCountSize, _maxCountSize + 1);

        for (int i = 0; i < cubeCount; i++)
            SpawnSingleCube();
    }

    public void ReturnCube(CubeDinamic cube)
    {
        cube.gameObject.SetActive(false);
        _pool.Enqueue(cube);

        SpawnSingleCube();
    }

    private void SpawnSingleCube()
    {
        Vector3 offset = new Vector3(Random.Range(-_spawnSpread, _spawnSpread), Random.Range(_minRandomIndex, _spawnSpread), Random.Range(-_spawnSpread, _spawnSpread));

        CubeDinamic cube = GetCube();

        cube.transform.SetPositionAndRotation(_cubeSpawnPosition.position + offset, transform.rotation);
        cube.gameObject.SetActive(true);
        cube.ResetState();
    }

    private CubeDinamic GetCube() 
    { 
        if(_pool.Count > 0)
            return _pool.Dequeue();

        CubeDinamic prefab = _cubeDinamicPrefabs[Random.Range(0, _cubeDinamicPrefabs.Length)];
        CubeDinamic cube = Instantiate(prefab);

        cube.Init(this);

        return cube;

    }
}


