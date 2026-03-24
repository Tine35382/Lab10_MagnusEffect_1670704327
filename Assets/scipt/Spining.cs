using UnityEngine;

public class Spining : MonoBehaviour
{
    [SerializeField] private float tourque = 1;
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(0, tourque , 0 ); // tourque
    }
}

