using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField]
    private SwarmManager m_SwarmManager;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_SwarmManager.OnPlayerEnterTrigger();
            Destroy(gameObject);
        }
    }
}
