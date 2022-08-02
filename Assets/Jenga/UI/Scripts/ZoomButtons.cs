using System;
using UnityEngine;
using UnityEngine.UI;

namespace Jenga.UI
{
  public class ZoomButtons : MonoBehaviour
  {
    [SerializeField] private Button _zoomInButton;
    [SerializeField] private Button _zoomOutButton;

    public event Action OnZoomIn;
    public event Action OnZoomOut;

    private void Start()
    {
      _zoomInButton.onClick.AddListener(ZoomIn);
      _zoomOutButton.onClick.AddListener(ZoomOut);
    }

    public void ZoomIn()
    {
      OnZoomIn?.Invoke();
    }

    public void ZoomOut()
    {
      OnZoomOut?.Invoke();
    }
  }
}
