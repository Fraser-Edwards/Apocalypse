using Opsive.Shared.Camera;
using UnityEngine;
using static UnityEngine.UI.Image;

public class FireWeapon : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public float range = 100f; // Range of the raycast
    public int damage = 10; // Damage dealt to the zombie
    public GameObject bloodEffectPrefab; // Reference to the blood effect prefab
    public GameObject _Camera;
    public LayerMask layerMask; // LayerMask for raycast

    private void Start()
    {
        range = 3000;
        _Camera = GameObject.Find("Camera12w");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.LeftControl)) // Left mouse button clicked
        {
            Fire();
        }
    }

    void Fire()
    {
        Vector3 origin = _Camera.transform.position;
        Vector3 direction = _Camera.transform.forward;

        RaycastHit hit;
        if (Physics.Raycast(_Camera.transform.position, _Camera.transform.forward, out hit, range, layerMask))
        {
            Debug.DrawRay(origin, direction * hit.distance, Color.green, 2f); // Draw the ray in green if it hits something

            Debug.Log(hit.collider.gameObject);
            if (hit.collider.CompareTag("Zombie"))
            {
                ZombieAI zombieAI = hit.collider.GetComponent<ZombieAI>();
                if (zombieAI != null)
                {
                    // Call the TakeDamage method and pass the hit point
                    zombieAI.Health -= 20;

                    // Instantiate the blood effect at the hit point
                    Instantiate(bloodEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }
    }
}
