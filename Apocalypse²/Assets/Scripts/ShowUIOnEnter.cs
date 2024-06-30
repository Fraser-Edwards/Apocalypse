using UnityEngine;
using UnityEngine.UI;

public class ShowUIOnEnter : MonoBehaviour
{
    public GameObject uiElement; // Reference to the UI element to show

    private void Start()
    {
        if (uiElement == null)
        {
            Debug.LogError("UI Element is not assigned!");
        }
        else
        {
            uiElement.SetActive(false); // Ensure the UI is initially inactive
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with " + other.name);

        // Check if the object entering the trigger is the player or another specific object
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            // Enable the UI element
            uiElement.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit called with " + other.name);

        // Check if the object exiting the trigger is the player or another specific object
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger");
            // Disable the UI element
            uiElement.SetActive(false);
        }
    }
}
