using UnityEngine;
using TMPro;
using System.Linq;
using UnityEditor;
using System;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float pushForce = 10f;
    public TMP_InputField inputField;
    public string str = "";
    private Rigidbody2D rb;
    public string terminal = "";
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (inputField != null)
        {
            if (inputField.placeholder != null)
            {
                inputField.placeholder.GetComponent<TextMeshProUGUI>().color = Color.gray;
            }
            if (inputField.textComponent != null)
            {
                inputField.textComponent.color = Color.white;
            }

            inputField.text = "$GDSCBallGame>>";
            terminal = "$GDSCBallGame>>";
            inputField.onEndEdit.AddListener(OnInputEndEdit);
            inputField.Select();
            inputField.ActivateInputField();

            inputField.selectionAnchorPosition = terminal.Length;
            inputField.selectionFocusPosition = terminal.Length;
        }
    }
    void Update()
    {



        for (char key = 'A'; key <= 'Z'; key++)
        {
            KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), key.ToString());
            if (Input.GetKeyDown(keyCode))
            {
                str += key.ToString().ToUpper();
                terminal += key.ToString().ToUpper();

                Debug.Log("Key pressed: " + key + ". Current str: " + str);
            }
            if (inputField != null)

                inputField.text = terminal;
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {

            str += "-";
            terminal += "-";

        }

        for (char key = '0'; key <= '9'; key++)
        {
            KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + key);
            if (Input.GetKeyDown(keyCode))
            {
                str += key;
                terminal += key;

                Debug.Log("Key pressed: " + key + ". Current str: " + str);

            }
        }
    }
    void OnInputEndEdit(string input)
    {

        string prefix = "$GDSCBallGame>>";

        if (str.StartsWith(prefix))
        {
            str = str[prefix.Length..];
        }

        // if (str == "JUMP")
        // {
        //     terminal += "\n>>";
        //     inputField.text = terminal;
        //     Jump();
        //     str = "";

        // }
        // else if (str == "FORWARD")
        // {
        //     terminal += "\n>>";
        //     inputField.text = terminal;
        //     forward();
        //     str = "";


        // }
        // else if (str == "BACKWARD")
        // {
        //     terminal += "\n>>";
        //     inputField.text = terminal;
        //     backward();
        //     str = "";


        // }
        // else
        // {
        //     inputField.text += "\nERROR";

        //     terminal += "\nERROR\n>>";
        //     inputField.text = terminal;
        //     str = "";


        // }

        string[] cammands = str.Split("-");

        if (str.StartsWith("FRC"))
        {


            try
            {
                if (float.TryParse(cammands[1], out float forceValue))
                {

                    if (float.TryParse(cammands[2], out float angleValue))
                    {


                        terminal += "\n>>";
                        inputField.text = terminal;
                        ApplyForceAtAngle(forceValue, angleValue);
                        str = "";

                    }
                    else
                    {
                        inputField.text += "\nERROR";

                        terminal += "\nERROR\n>>";
                        inputField.text = terminal;
                        str = "";

                    }
                }
                else
                {
                    inputField.text += "\nERROR";

                    terminal += "\nERROR\n>>";
                    inputField.text = terminal;
                    str = "";
                }
            }
            catch (Exception)
            {

                inputField.text += "\nERROR";

                terminal += "\nERROR\n>>";
                inputField.text = terminal;
                str = "";

            }


        }

        else if (str == "FWD")
        {
            terminal += "\n>>";
            inputField.text = terminal;
            forward();
            str = "";

        }

        else if (str == "BKW")
        {
            terminal += "\n>>";
            inputField.text = terminal;
            backward();
            str = "";

        }

        else if (str == "JMP")
        {
            terminal += "\n>>";
            inputField.text = terminal;
            Jump();
            str = "";

        }

        else
        {

            inputField.text += "\nERROR";

            terminal += "\nERROR\n>>";
            inputField.text = terminal;
            str = "";
        }

    }

    void ApplyForceAtAngle(float forceMagnitude, float angleDegrees)
    {
        // Convert the angle from degrees to radians
        float angleRadians = angleDegrees * Mathf.Deg2Rad;

        // Calculate the force components using trigonometry
        float forceX = forceMagnitude * Mathf.Cos(angleRadians);
        float forceY = forceMagnitude * Mathf.Sin(angleRadians);

        // Apply the force to the Rigidbody
        rb.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
    }

    void Jump()
    {
        rb.velocity = new Vector2(jumpForce, jumpForce);
        inputField.ActivateInputField();

        inputField.selectionAnchorPosition = terminal.Length;
        inputField.selectionFocusPosition = terminal.Length;
    }

    void forward()
    {
        rb.velocity = new Vector2(pushForce, rb.velocity.y);

        inputField.ActivateInputField();

        inputField.selectionAnchorPosition = terminal.Length;
        inputField.selectionFocusPosition = terminal.Length;
    }

    void backward()
    {
        rb.velocity = new Vector2(-pushForce, rb.velocity.y);

        inputField.ActivateInputField();

        inputField.selectionAnchorPosition = terminal.Length + 2;
        inputField.selectionFocusPosition = terminal.Length + 2;
    }
}
