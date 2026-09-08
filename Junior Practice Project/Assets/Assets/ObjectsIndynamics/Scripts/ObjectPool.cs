using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{  
    [SerializeField] private CubeDinamic[] _cubeDinamicPrefabs;
    [SerializeField] private Transform _cubeSpawnPosition;
   
    [SerializeField] private float _minCountSize = 2;
    [SerializeField] private float _maxCountSize = 7;
    [SerializeField] private float _minRandomIndex = 0;
    [SerializeField] private float _spawnSpread = 1.5f;

    private readonly Queue<CubeDinamic> _pool = new Queue<CubeDinamic>();

    private void Start()
    {
        SpawnCube();
    }

    public void SpawnCube()
    {
        float cubeCount = Random.Range(_minCountSize, _maxCountSize + 1);

        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-_spawnSpread, _spawnSpread), Random.Range(_minRandomIndex, _spawnSpread), Random.Range(-_spawnSpread, _spawnSpread));

            CubeDinamic cube = GetCube();

            cube.transform.SetPositionAndRotation(_cubeSpawnPosition.position + offset, transform.rotation);
            cube.gameObject.SetActive(true);
            cube.ResetState();    
        }
    }

    public void ReturnCube(CubeDinamic cube)
    {
        cube.gameObject.SetActive(false);
        _pool.Enqueue(cube);
    }

    private CubeDinamic GetCube() 
    { 
        if(_pool.Count > 0)
            return _pool.Dequeue();

        CubeDinamic prefab = _cubeDinamicPrefabs[Random.Range(0, _cubeDinamicPrefabs.Length)];
        return Instantiate(prefab);

    }
}


