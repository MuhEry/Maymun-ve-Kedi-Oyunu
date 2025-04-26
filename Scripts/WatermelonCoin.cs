using UnityEngine;

public class WatermelonCoin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            GameManager.instance.AddWatermelonScore();
            Destroy(gameObject);
        }
    }
}
