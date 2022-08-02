using Jenga.UI;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private ZoomButtons _zoomButtons;
    [SerializeField] private float zoom;
    private Camera _camera;

    private const float MaxSize = 30;
    private const float MinSize = 15;

    private void Start()
    {
        _zoomButtons.OnZoomIn += ZoomIn;
        _zoomButtons.OnZoomOut += ZoomOut;
        _camera = Camera.main;
    }

    private void OnDestroy()
    {
        _zoomButtons.OnZoomIn -= ZoomIn;
        _zoomButtons.OnZoomOut -= ZoomOut;
    }

    public void ZoomIn()
    {
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize - zoom, MinSize, MaxSize);
    }
    
    public void ZoomOut()
    {
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize + zoom, MinSize, MaxSize);
    }
}
