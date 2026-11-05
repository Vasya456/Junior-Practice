using UnityEngine;

public class CubeSpawnerDinamics : MonoBehaviour
{

    [SerializeField] private Explosion _explosion;

    [SerializeField] private Cube[] _cubePrefab;
    [SerializeField] private float _spawnSpread = 1.5f;
    [SerializeField] private float _scaleMultiplier = 0.5f;
    [SerializeField] private int minCubeCount = 2;
    [SerializeField] private int maxCubeCount = 7;
    [SerializeField] private int minRandomIndex = 0;

    public void CreateCube(Vector3 position, Quaternion rotation, float nextChance, Vector3 parentScale)
    {
        int cubeCount = Random.Range(minCubeCount, maxCubeCount);

        for (int i = 0; i < cubeCount; i++)
        {
            int randomIndex = Random.Range(minRandomIndex, _cubePrefab.Length);

            Vector3 offset = new Vector3(Random.Range(-_spawnSpread, _spawnSpread), Random.Range(minRandomIndex, _spawnSpread), Random.Range(-_spawnSpread, _spawnSpread));

            Cube newCube = Instantiate(_cubePrefab[randomIndex], position + offset, rotation);
            newCube.transform.localScale = parentScale * _scaleMultiplier;

            if (!newCube.TryGetComponent<Cube>(out Cube cube))
            {
                cube  = newCube.gameObject.AddComponent<Cube>();
            }

            cube.SetChance(nextChance);

            ApplyRandomColor(newCube.gameObject);
            ApplyGravity(newCube.gameObject);
            _explosion.ApplyExplisionForce(newCube.GetComponent<Rigidbody>(), position);      
        }
    }

    private void ApplyRandomColor(GameObject cube)
    {
        if (!cube.TryGetComponent<Renderer>(out Renderer renderer))
            return;

        renderer.material.color = new Color(Random.value, Random.value, Random.value);

    }

    private void ApplyGravity(GameObject cube)
    {
        if (!cube.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            rigidbody = cube.AddComponent<Rigidbody>();

        rigidbody.useGravity = true;
    }
}
