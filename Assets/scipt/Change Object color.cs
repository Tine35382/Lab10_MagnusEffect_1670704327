using UnityEngine;

public class ChangeOjectcolor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GetComponent<Renderer>().material.color = Color.violet;

        other.gameObject.GetComponent<Renderer>().material.color = Color.white;


    }


    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.purple;

        other.gameObject.GetComponent<Renderer>().material.color = Color.blueViolet;
    }



}
