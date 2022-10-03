using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    float xDirection;
    int floorLayerMask, wallLayerMask;
    SpriteRenderer sr;
    public float speed;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();


        floorLayerMask = 1 << LayerMask.NameToLayer("platform");
        wallLayerMask = 1 << LayerMask.NameToLayer("wall");


        speed = 0.5f;
        xDirection = speed;
    }

    void FixedUpdate()
    {
        MoveEnemy(); 
    }

    // Update is called once per frame
    void Update()
    {
        FaceDirection();
    }


    void FaceDirection()
    {
        if (rb.velocity.x > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }


    void MoveEnemy()
    {
        rb.velocity = new Vector2(xDirection, rb.velocity.y);

        int side;

        side = CheckFloorCollision(transform.position.x, transform.position.y, 0.25f, 0.3f);

        if(side == 0)
        {
            side = CheckWallCollision(transform.position.x, transform.position.y, 0.25f, 0.3f);
        }

        if( side == -1)
        {
            xDirection = speed;
        }

        if(side == 1)
        {
            xDirection = -speed;
        }

    }


    int CheckFloorCollision(float x, float y, float width, float height)
    {
        // returns -1 (not hitting left side)
        // or 1 (not hitting on right side)
        // or 0 (collision on both sides)

        Vector2 lineStart, lineEnd;
        RaycastHit2D hit;


        // check for no collision on left side
        lineStart.x = x - width;
        lineStart.y = y - height;

        lineEnd.x = x - width;
        lineEnd.y = y;

        hit = Physics2D.Linecast(lineStart, lineEnd, floorLayerMask);
        Debug.DrawLine(lineStart, lineEnd, hit ? Color.red : Color.green); // draw the coloured debug line
        if (hit == false)
        {
            // not touching platform on left side of sprite
            return -1;
        }




        // check for no collision on right side
        lineStart.x = x + width;
        lineEnd.x = x + width;

        hit = Physics2D.Linecast(lineStart, lineEnd, floorLayerMask);
        Debug.DrawLine(lineStart, lineEnd, hit ? Color.red : Color.green);

        if (hit == false)
        {
            // not touching platform on right side of sprite
            return 1;
        }

        // Sprite is touching platform
        return 0;

    }
    int CheckWallCollision(float x, float y, float width, float height)
    {
        // returns -1 (hit on left side)
        // or 1 (hit on right side)
        // or 0 (no collision)

        Vector2 lineStart, lineEnd;
        RaycastHit2D hit;


        lineStart.x = x - width;
        lineStart.y = y + height;
        lineEnd.x = x - width;
        lineEnd.y = y;

        // check for left side
        hit = Physics2D.Linecast(lineStart, lineEnd, wallLayerMask);
        Debug.DrawLine(lineStart, lineEnd, hit ? Color.yellow : Color.white);
        if (hit == true)
        {
            return -1;
        }

        // check right side
        lineStart.x = x + width;
        lineEnd.x = x + width;

        hit = Physics2D.Linecast(lineStart, lineEnd, wallLayerMask);
        Debug.DrawLine(lineStart, lineEnd, hit ? Color.yellow : Color.white);

        if (hit == true)
        {
            return 1;
        }
        return 0;

    }
}
