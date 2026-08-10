using UnityEngine;
using System;

public class ClickDetector : MonoBehaviour
{
    public event Action<Cube> CubeClicked;

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

        if (!clickedObject.TryGetComponent<Cube>(out Cube info))
        {
            Debug.Log("Вы не попали по обьекту " + clickedObject.name);
            return;
        }

        CubeClicked?.Invoke(info);
    }
}