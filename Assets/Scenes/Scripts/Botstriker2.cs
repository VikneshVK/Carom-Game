using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botstriker2 : MonoBehaviour
{
    
    public float maxForce = 500f;
    public float resetVelocityThreshold = 0.2f;
    public GameObject board;
    public Coincolleter scoreScript;
    private Rigidbody2D rb;
    private bool hasStriked = false;
    public countdown timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(coroutineA());
        Debug.Log("hasStriked: " + hasStriked);
    }

    IEnumerator coroutineA()
    {
        Debug.Log("coroutineA created");
        yield return new WaitForSeconds(2.0f);
        ApplyRandomForce();
        Debug.Log("coroutineA finished");
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0.2f)
        {
            hasStriked = true;
        }

        if (rb.velocity.magnitude < resetVelocityThreshold && hasStriked)
        {
            Debug.Log("Resetting Striker...");

            if (board.GetComponent<gameManager>().x == 2 && !scoreScript.hasScored)
            {
                board.GetComponent<gameManager>().x = 1;
                Debug.Log("GameManager.x set to 1");
            }

            ResetStriker();
            timer.ResetTimer();
        }
    }

    private void ApplyRandomForce()
    {
        Debug.Log("Appling force");
        float forceMagnitude = maxForce;
        Vector2 forceDirection = Random.insideUnitCircle.normalized;
        forceDirection.y = Mathf.Clamp(forceDirection.y, -1f, -0.2f);
        forceDirection.x = Mathf.Clamp(forceDirection.x, 0.2f, 1f);
        forceDirection = forceDirection.normalized;
        rb.AddForce(forceDirection * forceMagnitude);
        Debug.Log("Applied random force");
        
    }

    private void ResetStriker()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = new Vector3(Random.Range(-1.51f, 1.51f), 1.84f, 0);
        hasStriked = false;
        Debug.Log("Reset Striker. hasStriked: " + hasStriked);
        gameObject.SetActive(false);
        
    }
}

