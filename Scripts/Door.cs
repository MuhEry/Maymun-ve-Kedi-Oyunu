using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false; // Kapýnýn açýk olup olmadýðýný belirten deðiþken
    public Vector3 openPosition; // Kapýnýn açýk pozisyonu
    public Vector3 closedPosition; // Kapýnýn kapalý pozisyonu
    public float speed = 2f; // Kapýnýn açýlma hýzý

    void Start()
    {
        // Kapýyý baþlangýçta kapalý pozisyonuna ayarlayýn
        transform.position = closedPosition;
    }

    void Update()
    {
        if (isOpen)
        {
            // Kapý açýlma pozisyonuna doðru hareket eder
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * speed);
        }
        else
        {
            // Kapý kapanma pozisyonuna doðru hareket eder
            transform.position = Vector3.Lerp(transform.position, closedPosition, Time.deltaTime * speed);
        }
    }

    public void OpenDoor()
    {
        isOpen = true;
    }

    public void CloseDoor()
    {
        isOpen = false;
    }
}
