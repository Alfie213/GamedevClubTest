using UnityEngine;

public class WorldToUi : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.position = cam.WorldToScreenPoint(target.position);
    }
}
