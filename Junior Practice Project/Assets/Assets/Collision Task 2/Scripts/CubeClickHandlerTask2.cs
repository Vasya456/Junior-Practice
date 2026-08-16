using UnityEngine;

public class CubeClickHandlerTask2 : MonoBehaviour
{
    [SerializeField] private ClickDetectorTask2 _clickDetectorTask2;
    [SerializeField] private CubeSpawnerTask2 _cubeSpawnerTask2;
    [SerializeField] private ExplosionTask2 _explosionTask2;

    [SerializeField] private float _nextChanceMultiplier = 0.5f;
    [SerializeField] private float _minScaleToSplit = 0.2f;

    private void OnEnable()
    {
        _clickDetectorTask2.CubeClickedTask2 += HandlerCubeCliked2;
    }

    private void OnDisable()
    {
        _clickDetectorTask2.CubeClickedTask2 -= HandlerCubeCliked2;
    }

    private void HandlerCubeCliked2(CubeTask2 cube) 
    {
        Vector3 spawnPosition = cube.transform.position;
        Quaternion spawnRotation = cube.transform.rotation;
        Vector3 cubeScale = cube.transform.localScale;
        float chance = cube.Chance;
        GameObject cubeObject = cube.gameObject;
        
        bool canSpawnNewCubes = cubeScale.x > _minScaleToSplit && Random.value <= chance;

        if (cubeObject.TryGetComponent<Collider>(out Collider collider))
            collider.enabled = false;

        if (canSpawnNewCubes)
        {
            float nextChance = chance * _nextChanceMultiplier;
            _cubeSpawnerTask2.CreateCube(spawnPosition, spawnRotation, nextChance, cubeScale);
        }
        else
        {
            _explosionTask2.Explode(spawnPosition, cubeScale.x, cubeObject);
        }

        Destroy(cubeObject);
    }
}
