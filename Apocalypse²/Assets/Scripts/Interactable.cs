using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Name of the Wwise event to trigger
    public string wwiseEventName;

    // Variable to check if the player is inside the collider
    private bool isPlayerInside = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the player presses the 'E' key and is inside the collider
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            // Trigger the Wwise event for this NPC or object
            AkSoundEngine.PostEvent(wwiseEventName, gameObject);
        }
    }

    // This method is called when another collider enters the trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the collider
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
        }
    }

    // This method is called when another collider exits the trigger collider
    void OnTriggerExit(Collider other)
    {
        // Check if the player exited the collider
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
        }
    }
}
