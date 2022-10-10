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
    private float damage = 0.01f;
    public bool touchingBarrier;
    private Animator anim;
    HelperScript helper;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        helper = gameObject.AddComponent<HelperScript>();
    }
    void Update()
    {
        anim.SetBool("jump", false);
        if (!PauseControl.gameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Space) && touchingPlatform)
            {
                    rb.velocity = new Vector2(rb.velocity.x, playerJumpVelocity);
                    anim.SetBool("jump", true);
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
            imgHealthBar.fillAmount = imgHealthBar.fillAmount - damage;

            if( imgHealthBar.fillAmount < 0)
            {
                //Time.timeScale = 0f;
                // player dead
            }

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
