using UnityEngine;

public class BananaCoin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monkey"))
        {
            GameManager.instance.AddBananaScore();
            Destroy(gameObject);
        }
    }
}
