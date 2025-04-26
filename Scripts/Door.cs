using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false; // Kap�n�n a��k olup olmad���n� belirten de�i�ken
    public Vector3 openPosition; // Kap�n�n a��k pozisyonu
    public Vector3 closedPosition; // Kap�n�n kapal� pozisyonu
    public float speed = 2f; // Kap�n�n a��lma h�z�

    void Start()
    {
        // Kap�y� ba�lang��ta kapal� pozisyonuna ayarlay�n
        transform.position = closedPosition;
    }

    void Update()
    {
        if (isOpen)
        {
            // Kap� a��lma pozisyonuna do�ru hareket eder
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * speed);
        }
        else
        {
            // Kap� kapanma pozisyonuna do�ru hareket eder
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
