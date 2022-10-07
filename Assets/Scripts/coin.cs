using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public int layerMask;

    int CheckCollision(float x, float y, float width, float height)
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
        hit = Physics2D.Linecast(lineStart, lineEnd, layerMask);
        Debug.DrawLine(lineStart, lineEnd, hit ? Color.red : Color.white);
        if (hit)
        {
            return -1;
        }

        // check right side
        lineStart.x = x + width;
        lineEnd.x = x + width;

        hit = Physics2D.Linecast(lineStart, lineEnd, layerMask);
        Debug.DrawLine(lineStart, lineEnd, hit ? Color.red : Color.white);

        if (hit == true)
        {
            return 1;
        }
        return 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            // Pick up coin
            Destroy(this.gameObject);
        }
    }
}