using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Düþmanýn hareket hýzý
    public float moveDistance = 10f; // Düþmanýn hareket edeceði maksimum mesafe

    private bool movingRight = true; // Düþmanýn saða mý sola mý hareket ettiðini belirten deðiþken
    private Vector2 startPosition; // Düþmanýn baþlangýç pozisyonu

    void Start()
    {
        startPosition = transform.position; // Baþlangýç pozisyonunu kaydet
    }

    void Update()
    {
        // Düþmaný saða veya sola hareket ettirme
        if (movingRight)
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); // Saða hareket
        else
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime); // Sola hareket

        // Eðer düþman belirli bir mesafeden fazla hareket ettiyse yönünü deðiþtir
        if (Vector2.Distance(startPosition, transform.position) >= moveDistance)
        {
            movingRight = !movingRight; // Yönü deðiþtir
            Flip(); // Düþmanýn yönünü deðiþtirmek için Flip fonksiyonunu çaðýr
        }
    }

    // Düþmanýn yönünü deðiþtirmek için Flip fonksiyonu
    void Flip()
    {
        Vector3 scale = transform.localScale; // Mevcut ölçek
        scale.x *= -1; // Yönü tersine çevirme
        transform.localScale = scale; // Yeni ölçeði uygulama
    }
}
