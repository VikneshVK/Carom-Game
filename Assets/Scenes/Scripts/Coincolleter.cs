using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coincolleter : MonoBehaviour
{
    public int Point = 0;
    public Text Score;
    public bool hasScored= false;
    

    // Start is called before the first frame update
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            Point = Point + 1;
            Score.text = Point.ToString();
            hasScored= true;

        }
        if (collision.gameObject.tag == "Queen")
        {
            Destroy(collision.gameObject);
            Point = Point + 2;
            Score.text = Point.ToString();
            hasScored = true;
        }
    }
}
    // Update is called once per frame
    