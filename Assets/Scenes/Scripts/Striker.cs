
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Striker : MonoBehaviour
{
    
    public Slider _strikerSlider;    
    private Rigidbody2D rb;
    public GameObject board;
    public Coincolleter scoreScript2;
    public GameObject helperArrow;  
    private float maxForce = 300f;
    private Vector2 startPos;
    private Vector2 endPos;
    private float force;
    private float speed;
    private Vector2 shAngle;
    private bool positionSet = false;
    private bool hasStriked = false;
    public countdown timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ResetStriker();
        _strikerSlider.onValueChanged.AddListener(StrikerXpos);
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                positionSet = true;
                helperArrow.SetActive(true);
                hasStriked = false;
            }
        }

        if (Input.GetMouseButton(0) && positionSet)
        {
            endPos = Input.mousePosition;
            shAngle = (startPos - endPos).normalized;
            helperArrow.transform.rotation = Quaternion.LookRotation(Vector3.forward, shAngle);
        }

        if (Input.GetMouseButtonUp(0) && positionSet)
        {
            helperArrow.SetActive(false);
            ShootStriker();
        }

        if (rb.velocity.magnitude < 0.2f && hasStriked)
        {
            if (board.GetComponent<gameManager>().x == 1 && scoreScript2.hasScored == true)
            {
                board.GetComponent<gameManager>().x = 1;
                ResetStriker();
            }
            else if (board.GetComponent<gameManager>().x == 1 && scoreScript2.hasScored == false)
            {
                board.GetComponent<gameManager>().x = 2;
                ResetStriker();
            }
            


        }
    }

    public void ShootStriker()
    {
        force = Mathf.Min((startPos - endPos).magnitude, maxForce);
        speed = force / maxForce * 10f;
        rb.velocity = shAngle * speed;        
        hasStriked = true;
    }

    public void StrikerXpos(float value)
    {
        transform.position = new Vector3(value, -1.84f, 0);
    }

    public void ResetStriker()
    {
        rb.velocity = Vector2.zero;
        positionSet = false;
        transform.position = new Vector3(Random.Range(-1.51f, 1.51f), -1.84f, 0);
        hasStriked = false;
        helperArrow.SetActive(false);
        timer.ResetTimer();


    }
}

