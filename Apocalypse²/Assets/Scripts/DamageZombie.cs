using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZombie : MonoBehaviour
{
    public float HealthdecreasAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            other.GetComponent<ZombieAI>().Health -= HealthdecreasAmount;
            Vector3 hitPoint = other.ClosestPoint(transform.position);
            Instantiate(other.GetComponent<ZombieAI>().Blood, hitPoint, Quaternion.identity);
        }
    }
}
