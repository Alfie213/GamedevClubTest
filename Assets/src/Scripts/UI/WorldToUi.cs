using UnityEngine;

public class WorldToUi : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float offsetY;

    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.position = cam.WorldToScreenPoint(target.position);
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y + offsetY,
            transform.position.z
            );
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetOffsetY(float offset)
    {
        offsetY = offset;
    }
}
