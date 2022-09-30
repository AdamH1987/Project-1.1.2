using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class player1 : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    private Animator anim;
    bool facingRight = true;
    float inputHorizontal;
    float inputVertical;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 1;
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        anim.SetBool("walk", false);
        anim.SetBool("duck", false);

        if (inputHorizontal != 0)
        {
            rb.AddForce(new Vector2(inputHorizontal * speed, 0f));
            anim.SetBool("walk", true);
        }
        
        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetKey("down"))
        {
            anim.SetBool("duck", true);
        }

        void Flip()
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;

            facingRight = !facingRight;
        }
    }
}      
    

