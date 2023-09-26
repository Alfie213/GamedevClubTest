using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shootingForce;
    [SerializeField] private Transform spawnParent;
    
    private Transform fireTransform;
    private Vector2 shootingDirection;

    private void Awake()
    {
        fireTransform = GetComponentInChildren<FireTransform>().transform;
        shootingDirection = Vector2.right;
    }

    private void OnEnable()
    {
        EventBus.PlayerMovesLeft.Subscribe(Handle_PlayerMovesLeft);
        EventBus.PlayerMovesRight.Subscribe(Handle_PlayerMovesRight);
    }

    private void OnDisable()
    {
        EventBus.PlayerMovesLeft.Unsubscribe(Handle_PlayerMovesLeft);
        EventBus.PlayerMovesRight.Unsubscribe(Handle_PlayerMovesRight);
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, fireTransform.position, Quaternion.identity, spawnParent);
        projectile.GetComponent<Rigidbody2D>().AddForce(shootingDirection * shootingForce);
    }

    private void Handle_PlayerMovesLeft()
    {
        shootingDirection = Vector2.left;
    }

    private void Handle_PlayerMovesRight()
    {
        shootingDirection = Vector2.right;
    }
}