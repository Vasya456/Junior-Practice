using UnityEngine;

public class Create : MonoBehaviour
{

    [SerializeField] private GameObject[] _cubePrefab;
    [SerializeField] private float _spawnSpread = 1.5f;
    [SerializeField] private float _scaleMultiplier = 0.5f;

    [SerializeField] private float _explosionForce = 300f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _upwardModifier = 1f;

    public void CreateCube(Vector3 position, Quaternion rotation, float nextChance)
    {
        int cubeCounter = Random.Range(2, 6 + 1);


        for (int i = 0; i < cubeCounter; i++)
        {
            int randomIndex = Random.Range(0, _cubePrefab.Length);

            Vector3 offset = new Vector3(Random.Range(-_spawnSpread, _spawnSpread), Random.Range(0f, _spawnSpread), Random.Range(-_spawnSpread, _spawnSpread));

            GameObject newCube = Instantiate(_cubePrefab[randomIndex], position + offset, rotation);
            newCube.transform.localScale *= _scaleMultiplier;

            CubeInfo info = newCube.AddComponent<CubeInfo>();
            info.Chance = nextChance;


            ApplyRandomColor(newCube);
            ApplyGravity(newCube);
            ApplyExplisionForce(newCube.GetComponent<Rigidbody>(), position);
        }

    }

    private void ApplyRandomColor(GameObject cube)
    {
        Renderer renderer = cube.GetComponent<Renderer>();

        if (renderer == null)
            return;

        renderer.material.color = new Color(Random.value, Random.value, Random.value);

    }

    private void ApplyGravity(GameObject cube)
    {
        Rigidbody rigidbody = cube.GetComponent<Rigidbody>();

        if (rigidbody == null)
            rigidbody = cube.AddComponent<Rigidbody>();

        rigidbody.useGravity = true;
    }

    private void ApplyExplisionForce(Rigidbody rigidbody, Vector3 explosionCenter) 
    {
        if (rigidbody == null)
            return;

        rigidbody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius, _upwardModifier, ForceMode.Impulse);
    }

}
