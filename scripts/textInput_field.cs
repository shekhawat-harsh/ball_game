using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class textInput_field : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    string function = "";

    private Rigidbody2D rb;
    public void InputOpration(string op)
    {

        function = op;
        Debug.Log(function);

    }
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {

        if (function == "jump")

        {

            if (rb.velocity.y > 0.1f || rb.velocity.y < -0.1f)
            {

            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            }

        }

    }
}
