using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayShooter : MonoBehaviour
{

    [SerializeField] private Transform shootPos;

    [SerializeField] private float rayLength = 5.5f;

    public int damage;


    void Update()
    {
        shootRay();
    }

    [SerializeField] private GameObject shootVFX;
    [SerializeField] private GameObject hitVFX;

    void shootRay()
    {
        RaycastHit hit;
        
        Debug.DrawRay(shootPos.position, transform.forward * rayLength , Color.green);
        
        if (Physics.Raycast(shootPos.position, transform.forward,out hit , rayLength))
        {
            Debug.DrawRay(shootPos.position , transform.forward * hit.distance , Color.red);
            
            Debug.Log($" Ray hits : {hit.collider.name}");
            
            
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            var shootVfx = Instantiate(shootVFX, shootPos.position, Quaternion.identity, shootPos);
            Destroy(shootVfx, 1.5f);

            if (Physics.Raycast(shootPos.position, transform.forward, out hit, rayLength))
            {
                var hitVfx = Instantiate(hitVFX, hit.point, Quaternion.identity);
                Destroy(hitVfx, 1.5f);

                if (hit.collider.CompareTag("Enemy"))
                {
                    Enemy enemy = hit.collider.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(damage);
                    }
                }


                if (hit.collider.CompareTag("Obsutacle"))
                {
                    var rb = hit.collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddTorque(0, 500 , 0);
                    }
                }
            }
        }
    }
}
