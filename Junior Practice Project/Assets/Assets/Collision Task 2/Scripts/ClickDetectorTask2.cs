using UnityEngine;

public class ClickDetectorTask2 : MonoBehaviour
{

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Detector();
    }

    private void Detector() 
    {
        if (!Input.GetMouseButton(0))
            return;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Вы не попали по обьекту");
            return;
        }
    }

}
