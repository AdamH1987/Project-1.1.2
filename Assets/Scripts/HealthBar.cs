using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image imgHealthBar;
    private int damage = 5;
    public bool touchingBarrier;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barrier")
        {
            //touchingBarrier = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (touchingBarrier == true)
        {
            //imgHealthBar.fillAmount = imgHealthBar.fillAmount - (damage * 0.07f);
        }
    }
}
