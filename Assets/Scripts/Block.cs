using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public ParticleSystem explosion;
    public int health = 1;
    public Color baseColor;
    public Color secondColor;

    SpriteRenderer spriteRenderer;
    BoxCollider2D col;
    MainSceneManager mainSceneManager;
    AudioSource[] blockAudio;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        mainSceneManager = FindObjectOfType<MainSceneManager>();
        blockAudio = GetComponents<AudioSource>();
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
                Data.Instance.score += 10;
                Data.Instance.scoreCounter += 10;
                mainSceneManager.OnBlockDestroyed();
                StartCoroutine(DestroyThis());
                blockAudio[0].Play();
            }
            else if (health == 1)
            {
                blockAudio[1].Play();
                spriteRenderer.color = baseColor;
            }
            else if (health == 2)
            {
                blockAudio[1].Play();
                spriteRenderer.color = secondColor;
            }
        }
    }
}