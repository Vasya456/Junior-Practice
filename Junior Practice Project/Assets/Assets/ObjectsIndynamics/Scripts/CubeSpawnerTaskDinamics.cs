using UnityEngine;

public class CubeSpawnerTaskDinamics : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private Transform _cubeSpawnPosition;

    [SerializeField] private int _minCountSize = 2;
    [SerializeField] private int _maxCountSize = 7;
    [SerializeField] private float _minHeightOffset = 0;
    [SerializeField] private float _spawnSpread = 1.5f;

    private void Start()
    {
        SpawnCubes();
    }

    private void OnEnable()
    {
        _pool.CubeReturned += OnCubeReturned;
    }

    private void OnDisable()
    {
        _pool.CubeReturned -= OnCubeReturned;
    }

    public void SpawnCubes()
    {
        int cubeCount = Random.Range(_minCountSize, _maxCountSize + 1);

        for (int i = 0; i < cubeCount; i++)
        {
            SpawnSingleCube();
        }
    }

    private void OnCubeReturned(CubeDinamic cube)
    {
        SpawnSingleCube();
    }

    private void SpawnSingleCube()
    {
        Vector3 offset = new Vector3(Random.Range(-_spawnSpread, _spawnSpread), Random.Range(_minHeightOffset, _spawnSpread),Random.Range(-_spawnSpread, _spawnSpread));

        CubeDinamic cube = _pool.GetCube();

        cube.transform.SetPositionAndRotation(_cubeSpawnPosition.position + offset, transform.rotation);
        cube.gameObject.SetActive(true);
        cube.ResetState();
    }
}

