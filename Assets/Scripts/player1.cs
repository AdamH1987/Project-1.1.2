using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class player1 : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    private Animator anim;
    float inputHorizontal;
    float inputVertical;
    HelperScript helper;
    public GameObject slash;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 2;
        anim = GetComponent<Animator>();
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("walk", false);
        anim.SetBool("duck", false);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("walk", true);
            helper.FlipObject(false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("walk", true);
            helper.FlipObject(true);
        }

        if (Input.GetKey("down"))
        {
            anim.SetBool("duck", true);
        }

        int moveDirection = 1;
        if (Input.GetKeyDown("z"))
        {
            GameObject clone;
            clone = Instantiate(slash, transform.position, transform.rotation);

            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector3(15 * moveDirection, 0, 0);

            rb.transform.position = new Vector3(transform.position.x, transform.position.y +0, transform.position.z + 1);
        }

    }
}      
    

