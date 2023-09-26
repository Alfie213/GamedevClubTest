using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int Damage => damage;
    
    [SerializeField] private int damage;
}
