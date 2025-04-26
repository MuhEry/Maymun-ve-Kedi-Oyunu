using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform teleportDestination; // I��nlanma noktas�

    void OnTriggerEnter2D(Collider2D other)
    {
        // Sadece Monkey ve Cat tag'lerine sahip nesneler ���nlanabilir
        if (other.CompareTag("Monkey") || other.CompareTag("Cat"))
        {
            other.transform.position = teleportDestination.position;
        }
    }
}
