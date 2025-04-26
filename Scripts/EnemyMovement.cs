using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // D��man�n hareket h�z�
    public float moveDistance = 10f; // D��man�n hareket edece�i maksimum mesafe

    private bool movingRight = true; // D��man�n sa�a m� sola m� hareket etti�ini belirten de�i�ken
    private Vector2 startPosition; // D��man�n ba�lang�� pozisyonu

    void Start()
    {
        startPosition = transform.position; // Ba�lang�� pozisyonunu kaydet
    }

    void Update()
    {
        // D��man� sa�a veya sola hareket ettirme
        if (movingRight)
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // Sa�a hareket
        else
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); // Sola hareket

        // E�er d��man belirli bir mesafeden fazla hareket ettiyse y�n�n� de�i�tir
        if (Vector2.Distance(startPosition, transform.position) >= moveDistance)
        {
            movingRight = !movingRight; // Y�n� de�i�tir
            Flip(); // D��man�n y�n�n� de�i�tirmek i�in Flip fonksiyonunu �a��r
        }
    }

    // D��man�n y�n�n� de�i�tirmek i�in Flip fonksiyonu
    void Flip()
    {
        Vector3 scale = transform.localScale; // Mevcut �l�ek
        scale.x *= -1; // Y�n� tersine �evirme
        transform.localScale = scale; // Yeni �l�e�i uygulama
    }
}
