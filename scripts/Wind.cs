using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public Vector2 windDirection = new Vector2(1, 0); // Adjust the direction of the wind as needed
    public float windForce = 5f; // Adjust the strength of the wind as needed

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.AddForce(windDirection.normalized * windForce * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }
}

