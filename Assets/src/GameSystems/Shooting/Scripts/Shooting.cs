using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootingForce;
    [SerializeField] private Transform spawnParent;
    
    private Transform fireTransform;

    private void Awake()
    {
        fireTransform = GetComponentInChildren<FireTransform>().transform;
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, fireTransform.position, Quaternion.identity, spawnParent);
        projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f * shootingForce, 10f * shootingForce));
    }
}
