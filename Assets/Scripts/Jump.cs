using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerJumpVelocity = 5;
    public bool touchingPlatform;
    public Image imgHealthBar;
    private int damage = 5;
    public bool touchingBarrier;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!PauseControl.gameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Space)   )
            {
                if (touchingPlatform == true)
                {
                    rb.velocity = new Vector2(rb.velocity.x, playerJumpVelocity);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
              //Player can't jump! (The game is paused)
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            touchingPlatform = true;
        }
        if (collision.gameObject.tag == "Barrier")
        {
            imgHealthBar.fillAmount = imgHealthBar.fillAmount - (damage * 0.07f);
            Time.timeScale = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = false;
        }
    }


}
