using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    public float speed = 5f;
    public float jumpForce = 10f;
    private int groundContactCount = 0; // Temas sayýsýný tutar

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Yürüyüþ ve zýplama kodlarý
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContactCount++;
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Spike"))
        {
            GameManager.instance.EndGame("enemy");
        }
        else if (collision.gameObject.CompareTag("CatDoor") || collision.gameObject.CompareTag("MonkeyDoor"))
        {
            GameManager.instance.CharacterReachedDoor(collision.gameObject.tag);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundContactCount--;
            if (groundContactCount == 0)
            {
                isGrounded = false;
            }
        }
    }
}
