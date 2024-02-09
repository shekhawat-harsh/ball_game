using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 20f;
    public TMP_InputField inputField;
    public string str="";
    private Rigidbody2D rb;
public string terminal="";
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
        terminal="$GDSCBallGame>>";
        inputField.onEndEdit.AddListener(OnInputEndEdit);
             inputField.Select();
        inputField.ActivateInputField();
 
        inputField.selectionAnchorPosition =terminal.Length;
        inputField.selectionFocusPosition =terminal.Length;
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
                terminal+=key.ToString().ToUpper();
  
                Debug.Log("Key pressed: " + key + ". Current str: " + str);
            }
        if (inputField != null)
                
                inputField.text=terminal;}
        }
    void OnInputEndEdit(string input)
    {

            if (str.EndsWith("JUMP"))
            {
                terminal+="\n>>";
                inputField.text=terminal;
                Jump();
                str="";

            }
            else if (str.EndsWith ("FORWARD"))
            {
                terminal+="\n>>";
                inputField.text=terminal;
                forward();
                str="";


            }
            else if (str.EndsWith( "BACKWARD"))
            {
                terminal+="\n>>";
                inputField.text=terminal;
                backward();
                str="";


            }
            else{
                inputField.text+="\nERROR";
               
                terminal+="\nERROR\n>>";
                inputField.text=terminal;
                str="";


            }
        
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
        rb.velocity = new Vector2(jumpForce, rb.velocity.y);
            
        inputField.ActivateInputField();

        inputField.selectionAnchorPosition =terminal.Length;
        inputField.selectionFocusPosition =terminal.Length;
    }

    void backward()
    {
        rb.velocity = new Vector2(-jumpForce, rb.velocity.y);

        inputField.ActivateInputField();

        inputField.selectionAnchorPosition = terminal.Length+2;
        inputField.selectionFocusPosition = terminal.Length+2;
    }
}
