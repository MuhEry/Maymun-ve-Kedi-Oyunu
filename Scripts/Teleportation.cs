using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform teleportDestination; // Işınlanma noktası

    void OnTriggerEnter2D(Collider2D other)
    {
        // Sadece Monkey ve Cat tag'lerine sahip nesneler ışınlanabilir
        if (other.CompareTag("Monkey") || other.CompareTag("Cat"))
        {
            other.transform.position = teleportDestination.position;
        }
    }
}
