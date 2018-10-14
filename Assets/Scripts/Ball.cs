using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 2f;

    Rigidbody2D rigidbody;
    MainSceneManager sceneManager;

    void Start()
    {
        direction.Normalize();
        rigidbody = GetComponent<Rigidbody2D>();
        sceneManager = FindObjectOfType<MainSceneManager>();
    }

    void Update()
    {
        transform.Translate(direction * speed);
    }

    /// JOSIAH!!!!!
    /// If you think of something better, let me know. This seems to be pretty reliable, although not perfect.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("poop'0;");
        if (collision.collider.CompareTag("Block"))
        {
            ContactPoint2D contactPoint = collision.GetContact(0);
            Debug.Log(contactPoint.normal);
            /// There was some goofy stuff going on with bouncing, somehow normals weren't either (1,0), or (0,1) etc...
            /// So checking that the normal was greater than a certain value (0.5) got rid of that problem.
            if (contactPoint.normal.x > 0.5f)
            {
                Debug.Log("x 1");
                direction.x = Mathf.Abs(direction.x);
            }
            else if (contactPoint.normal.x < -0.5f)
            {
                Debug.Log("x -1");
                direction.x = Mathf.Abs(direction.x) * -1;
            }
            else if (contactPoint.normal.y > 0.5f)
            {
                direction.y = Mathf.Abs(direction.y);
                Debug.Log("y 1");
            }
            else if (contactPoint.normal.y < -0.5f)
            {
                Debug.Log("y -1");
                direction.y = Mathf.Abs(direction.y) * -1;
            }
        }
        else if (collision.collider.CompareTag("Player")) // If it hits the player, and the player is mostly below the ball, then just go up for now. 
        {
            if (collision.transform.position.y < transform.position.y)
            {
                direction.y = Mathf.Abs(direction.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball Destroy"))
        {
            sceneManager.OnBallDestroyed();
            Destroy(gameObject);
        }
    }
}
