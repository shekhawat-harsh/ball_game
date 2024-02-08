using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 20f;
    public TMP_InputField inputField;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        inputField.onEndEdit.AddListener(OnInputEndEdit);
    }

    void OnInputEndEdit(string input)
    {
        if (input.ToLower() == "j")
        {
            Jump();

            inputField.text = "";
        }

        else if (input.ToLower() == "f")
        {
            forward();

            inputField.text = "";
        }

        else if (input.ToLower() == "b")
        {
            backword();

            inputField.text = "";
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(jumpForce, jumpForce);
    }

    void forward()
    {
        rb.velocity = new Vector2(jumpForce, rb.velocity.y);
    }

    void backword()
    {
        rb.velocity = new Vector2(-jumpForce, rb.velocity.y);
    }
}
