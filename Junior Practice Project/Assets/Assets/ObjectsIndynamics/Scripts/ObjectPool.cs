using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{  
    [SerializeField] private CubeDinamic[] _cubeDinamicPrefabs;

    public event Action<CubeDinamic> CubeReturned;
    private readonly Queue<CubeDinamic> _pool = new Queue<CubeDinamic>();

    public CubeDinamic GetCube() 
    {
        if (_pool.Count > 0) 
            return _pool.Dequeue();

        CubeDinamic prefab = _cubeDinamicPrefabs[UnityEngine.Random.Range(0, _cubeDinamicPrefabs.Length)];
        CubeDinamic cube = Instantiate(prefab);

        cube.Released += ReturnCube;
        cube.gameObject.SetActive(false);

        return cube;

    }

    private void ReturnCube(CubeDinamic cube) 
    {
        cube.gameObject.SetActive(false);
        _pool.Enqueue(cube);

        CubeReturned?.Invoke(cube);
    }


}


