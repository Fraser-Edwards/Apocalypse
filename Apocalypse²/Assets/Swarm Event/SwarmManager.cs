using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    private Transform m_PlayerTransform;
    
    [Header("Spawn Settings")]
    [SerializeField]
    private GameObject[] m_SpawnLocations;
    [SerializeField]
    private GameObject m_ZombiePrefab;
    [SerializeField]
    private float m_SpawnInterval = 5.0f;

    [Header("Zombie Kill Settings")]
    [SerializeField]
    private int m_TargetKillCount;
    private int m_CurrentKillCount;
    private bool m_SeventyPercentCalled = false;

    [Header("Event Settings")]
    [SerializeField]
    private float m_StartEventOffet;

    private bool m_EventTriggered = false;

    private void Start()
    {
        m_CurrentKillCount = 0;
    }

    public void OnPlayerEnterTrigger()
    {
        if (!m_EventTriggered)
        {
            m_EventTriggered = true;
            StartCoroutine(SpawnZombies());
        }
    }
    
    private IEnumerator SpawnZombies()
    {
        StartEventMusic();
        yield return new WaitForSeconds(m_StartEventOffet);
        
        int totalZombiesToSpawn = m_TargetKillCount;
        int zombiesSpawned = 0;

        while (zombiesSpawned < totalZombiesToSpawn)
        {
            for (int i = 0; i < m_SpawnLocations.Length; i++)
            {
                if (zombiesSpawned >= totalZombiesToSpawn)
                    break;

                ZombieAI zombieAI = Instantiate(m_ZombiePrefab, m_SpawnLocations[i].transform.position, Quaternion.identity).GetComponent<ZombieAI>();
                zombieAI.player = m_PlayerTransform;
                zombieAI.IsEventZombie = true;
                zombieAI.SwarmManager = this;
                zombiesSpawned++;
            }
            
            yield return new WaitForSeconds(m_SpawnInterval);
        }
    }

    public void IncreaseKillCount()
    {
        m_CurrentKillCount++;
        
        if (!m_SeventyPercentCalled && m_CurrentKillCount >= m_TargetKillCount * 0.7f)
        {
            m_SeventyPercentCalled = true;
            SeventyPercentKilledMusic();
        }

        if (m_CurrentKillCount == m_TargetKillCount)
        {
            OnAllZombieDead();
        }
    }

    // Function to call audio for the start of the event
    private void StartEventMusic()
    {
        Debug.LogError($"Start event music");
        // HERE
    }

    // Function to call audio for when 70% of the zombies are cleared out
    private void SeventyPercentKilledMusic()
    {
        Debug.LogError($"Start 70% music");
        // HERE
        
        
    }

    // All zombies dead function
    private void OnAllZombieDead()
    {
        
    }

    private void OnPlayerDeath()
    {
        
    }
    
    // Function when all zombies in the event are dead
    
    // On death call function
}
