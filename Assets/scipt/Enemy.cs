using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 50;
    [SerializeField] private GameObject DeathVFX;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"took {damage} damage!");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (DeathVFX != null)
        {
            GameObject vfx = Instantiate(
                DeathVFX,
                transform.position,
                Quaternion.identity
            );

            Destroy(vfx, 2f);
        }

        Destroy(gameObject);
    }
}
