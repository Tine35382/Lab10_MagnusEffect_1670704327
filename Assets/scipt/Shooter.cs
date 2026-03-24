using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform shootPos;
    public float shootForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    // Update is called once per frame
    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, shootPos.position , shootPos.rotation);
        var rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(shootPos.forward * shootForce, ForceMode.Impulse);
    }
}
