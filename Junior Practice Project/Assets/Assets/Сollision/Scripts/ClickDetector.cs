using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    [SerializeField] private Create _create;

    private void Update()
    {
        Detector();
    }

    private void Detector()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                Vector3 spawnPosition = clickedObject.transform.position;
                Quaternion spawnRotation = clickedObject.transform.rotation;

                CubeInfo info = clickedObject.GetComponent<CubeInfo>();
                float currentChance = 100f;
                
                if (info != null)
                    currentChance = info.Chance;

                float roll = Random.Range(0f, 100f);

                Debug.Log("Вы кликнули по обьекту " + clickedObject.name);

                Destroy(clickedObject);

                if (roll < currentChance)
                {
                    _create.CreateCube(spawnPosition, spawnRotation, currentChance / 2f);
                }
            }
            else
            {
                Debug.Log("Вы не попали по обьекту");
            }
        }
    }
}