using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public int health = 1;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

    }

    IEnumerator DestroyThis()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Constants.S.score += 10;
            health--;
            if (health <= 0)
            {
                StartCoroutine(DestroyThis());
            }
        }
    }
}
