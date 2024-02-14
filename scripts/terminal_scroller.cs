using UnityEngine;
using TMPro;

public class TextMeshProController : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public int maxLines = 2; // Maximum number of lines allowed

    // Function to set text content
    public void SetTextContent(string content)
    {
        // Set the text content
        textMeshPro.text = content;

        // Check if the number of lines exceeds the maximum allowed
        if (textMeshPro.textInfo.lineCount > maxLines)
        {
            textMeshPro.text = "";
        }
    }

    // Function to remove extra lines
    private void RemoveExtraLines()
    {
        // Calculate the index of the first character of the line exceeding the maximum allowed
        int firstCharIndex = textMeshPro.textInfo.lineInfo[maxLines].firstCharacterIndex;

        // Remove the extra lines by removing characters from the text
        textMeshPro.text = textMeshPro.text.Substring(0, firstCharIndex);
    }
}
