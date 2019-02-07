using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraSizeAdjuster : MonoBehaviour
{
  [SerializeField] private Camera camera;
  [SerializeField] private float target_width;
  [SerializeField] private float target_height;

  private void Awake()
  {
    AdjustCameraSize();
  }

  private void AdjustCameraSize()
  {
    var target_ratio = target_width / target_height;
    var current_ratio = Screen.width * 1f / Screen.height;
    if (current_ratio > target_ratio)
      return;

    camera.orthographicSize *= target_ratio / current_ratio;
  }

  private void OnValidate()
  {
    if (camera == null)
      camera = GetComponent<Camera>();
  }
}
