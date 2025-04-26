using UnityEngine;

public class Button : MonoBehaviour
{
    public Door door; // Etkile�imde bulunacak kap�
    public bool isPressed = false; // Butonun bas�l� olup olmad���n� belirten de�i�ken

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isPressed && (other.CompareTag("Monkey") || other.CompareTag("Cat")))
        {
            isPressed = true;
            door.OpenDoor();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (isPressed && (other.CompareTag("Monkey") || other.CompareTag("Cat")))
        {
            isPressed = false;
            door.CloseDoor();
        }
    }
}
