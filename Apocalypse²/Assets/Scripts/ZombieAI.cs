using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 10f;
    public float attackDistance = 2f;
    public float wanderRadius = 5f;
    public float wanderTimer = 5f;

    private NavMeshAgent agent;
    private float timer;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip Attack;
    public AudioClip Hit;
    public float Health;
    public Slider HealthBar;

    public GameObject Blood;
    private bool oneTime;

    private bool isDead;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        HealthBar.maxValue = 100;
        HealthBar.minValue = 0;
    }

    void Update()
    {
        if (isDead) return;

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        HealthBar.value = Health;

        if (Health <= 0)
        {
            Die();
        }
        else if (distanceToPlayer <= attackDistance)
        {
            agent.isStopped = true;
            AttackPlayer();
        }
        else if (distanceToPlayer <= chaseDistance)
        {
            agent.isStopped = false;
            ChasePlayer();
        }
        else
        {
            agent.isStopped = false;
            Wander();
        }
    }

    void ChasePlayer()
    {
        if (isDead || agent == null || !agent.isOnNavMesh) return;
        agent.SetDestination(player.position);
        animator.SetBool("Attack", false);
        animator.SetBool("Walk", true);
    }

    void AttackPlayer()
    {
        // Implement your attack logic here
        Debug.Log("Attacking player");
        animator.SetBool("Walk", false);
        animator.SetBool("Attack", true);
    }

    void Wander()
    {
        if (isDead || agent == null || !agent.isOnNavMesh) return;

        timer += Time.deltaTime;

        if (agent.velocity.magnitude > 0.5f)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false);
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", false);
        }

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0f;
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetBool("Attack", false);
        animator.SetBool("Walk", false);
        animator.SetBool("Dead", true);
        agent.enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

        if (!oneTime)
        {
            Player.instance.WinZombieAmount++;
            oneTime = true;
        }

        // Additional logic for handling the zombie's death, e.g., playing an animation, spawning blood effects
        // ...
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * dist;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, dist, layermask);
        return navHit.position;
    }
}
