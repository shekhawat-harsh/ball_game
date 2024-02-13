`using UnityEngine;

public class AngleCalculator : MonoBehaviour
{
    public Transform player; // Assign the player object in the inspector
    public Transform baseTile; // Assign the base tile object in the inspector

    void Update()
    {
        // Get the position of the mouse pointer in screen space
        Vector3 mousePositionScreen = Input.mousePosition;

        // Convert the mouse position from screen space to world space
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, mousePositionScreen.y, Camera.main.nearClipPlane));
        // Calculate the direction vectors
        Vector3 playerToMouse = (mousePositionWorld - player.position).normalized;
        Vector3 playerToBaseTile = (baseTile.position - player.position).normalized;
        playerToBaseTile = new Vector3(playerToBaseTile.y * -1, 0, 0);

        // Calculate the angle between the two vectors
        float angle = Vector3.Angle(playerToMouse, playerToBaseTile);

        // Print the angle to the console (for testing)
        Debug.Log("Angle: " + angle);
    }
}
