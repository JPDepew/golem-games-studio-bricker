using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    BoxCollider2D col;
    float verticalHalfSize = 0;
    float horizontalHalfSize = 0;
    float widthOfPaddle;

    public bool movingRight = false;
    public bool movingLeft = false;

    // Use this for initialization
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        widthOfPaddle = col.bounds.max.x - col.bounds.min.x;
    }

    // Update is called once per frame
    void Update()
    {
        verticalHalfSize = Camera.main.orthographicSize;
        horizontalHalfSize = verticalHalfSize * Screen.width / Screen.height;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (col.bounds.min.x > -horizontalHalfSize)
            {
                movingLeft = true;
                transform.Translate(Vector2.left * Constants.S.playerSpeed);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            movingLeft = false;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (col.bounds.max.x < horizontalHalfSize)
            {
                movingRight = true;
                transform.Translate(Vector2.right * Constants.S.playerSpeed);
            }
            else
            {
                movingRight = false;
            }
        }
        else
        {
            movingRight = false;
        }
    }
}
