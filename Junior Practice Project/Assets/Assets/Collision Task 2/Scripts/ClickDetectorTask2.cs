using System;
using UnityEngine;

public class ClickDetectorTask2 : MonoBehaviour
{
    public event Action<CubeTask2> CubeClickedTask2;

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
        if (!Input.GetMouseButtonDown(0))
            return;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("Вы не попали по обьекту");
            return;
        }

        GameObject clickedObject = hit.collider.gameObject;


        if (clickedObject == null)
            return;

        if (!clickedObject.TryGetComponent<CubeTask2>(out CubeTask2 cube) || cube == null)
        {
            Debug.Log("Вы не попали по обьекту " + clickedObject.name);
            return;
        }

        CubeClickedTask2?.Invoke(cube);
    }

}
