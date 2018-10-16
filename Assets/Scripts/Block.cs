using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public ParticleSystem explosion;
    public int health = 1;

    SpriteRenderer spriteRenderer;
    BoxCollider2D col;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    /// <summary>
    /// This function destroys the block with a slight delay to allow for playing a sound.
    /// </summary>
    /// <returns>Wait for a short delay</returns>
    IEnumerator DestroyThis()
    {
        // Particle stuff
        explosion = Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        var main = explosion.main;
        main.startColor = spriteRenderer.color;

        spriteRenderer.color = new Color(1, 1, 1, 0);
        col.enabled = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            health--;
            if (health <= 0)
            {
                Constants.S.score += 10;
                StartCoroutine(DestroyThis());
            }
        }
    }
}
