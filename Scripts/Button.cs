using UnityEngine;

public class Button : MonoBehaviour
{
    public Door door; // Etkileþimde bulunacak kapý
    public bool isPressed = false; // Butonun basýlý olup olmadýðýný belirten deðiþken

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
