using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    [Header("Components")]
    public NavMeshAgent zombieNavMash;
    public Animator anim;

    [Header("Zombie Stats")]
    public float zombieHp = 100;
    public float distanceFollow;
    public float distanceAttack;

    [Header("Damage Range")]
    public int minDamage = 0;
    public int maxDamage = 0;

    [Header("Animation Parameters")]
    private int numBite;
    private int numAttack;
    private bool hasAnimationPlayed;

    private bool isDead;
    private bool a = false;
    private int i;
    private Transform Head;
    private GameObject player;
    public float radius = 10f; // Dairenin yarıçapı
    private Vector3 targetPosition; // Hedef nokta

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        zombieNavMash = GetComponent<NavMeshAgent>();
        Head = transform.Find("Head");
        i = 0;
        numAttack = Random.Range(1, 3);
        numBite = Random.Range(1, 3);
        StartCoroutine(RandomizeTargetPosition());

    }

    void Update()
    {
        Head.transform.position = transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.Find("mixamorig:Neck").transform.GetChild(0).transform.position;
        if (zombieHp <= 0)
        {
            isDead = true;
        }
        if (isDead)
        {
            anim.SetBool("isAttack2", false);
            anim.SetBool("isAttack", false);
            anim.SetBool("isRun", false);
            anim.SetBool("isWalk", false);
            StartCoroutine(DestroyDiedZombies());
            GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
            if (scoreManager != null)
            {
                ScoreMan scoreManagerScript = scoreManager.GetComponent<ScoreMan>();
                if (scoreManagerScript != null)
                {
                    if (!a)
                    {
                        scoreManagerScript.IncreaseScore(5);
                        a = true;
                    }
                } 
            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < distanceFollow)
            {
                zombieNavMash.isStopped = false;
                zombieNavMash.SetDestination(player.transform.position);
                float temp = distance;
                anim.SetBool("isAttack", false);
                anim.SetBool("isAttack2", false);
                if (gameObject.name.StartsWith("Boss"))
                {
                    temp = 1000;
                }
                if (gameObject.name.StartsWith("WalkZombie"))
                {
                    temp = distance;
                }

                if (temp < 5)
                {
                    zombieNavMash.speed = 0.5f;
                    anim.SetBool("isWalk", true);
                    anim.SetBool("isRun", false);
                    anim.SetBool("isAttack", false);
                    anim.SetBool("isAttack2", false);
                }
                else
                {
                    zombieNavMash.speed = 2f;
                    anim.SetBool("isRun", true);
                    anim.SetBool("isWalk", false);
                    anim.SetBool("isAttack", false);
                    anim.SetBool("isAttack2", false);
                    anim.SetBool("isScream", false);

                }
            }
            else
            {
                /*  zombieNavMash.isStopped = true;
                 anim.SetBool("isAttack", false);
                 anim.SetBool("isAttack2", false);
                 anim.SetBool("isWalk", false);
                 anim.SetBool("isRun", false); */
                // Zombiyi hedefe doğru yönlendirin
                zombieNavMash.SetDestination(targetPosition);
                anim.SetBool("isIdle", false);
                anim.SetBool("isWalk", true);


            }

            if (distance < distanceAttack && player.GetComponent<PlayerMovementScript>().HP > 0)
            {
                zombieNavMash.isStopped = true;
                if (numAttack == 1)
                {
                    anim.SetBool("isAttack", true);
                    anim.SetBool("isAttack2", false);
                }
                else if (numAttack == 2)
                {
                    anim.SetBool("isAttack", false);
                    anim.SetBool("isAttack2", true);
                }
                anim.SetBool("isWalk", false);
                anim.SetBool("isRun", false);

                if (player.GetComponent<PlayerMovementScript>().HP <= 0)
                {
                    anim.SetBool("isAttack", false);
                    anim.SetBool("isAttack2", false);
                    anim.SetBool("isWalk", false);
                    anim.SetBool("isRun", false);
                    if (numBite == 1) { anim.SetBool("isBite", true); }
                    if (numBite == 2) { anim.SetBool("isBite2", true); }
                }
            }
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                StartCoroutine(RandomizeTargetPosition());
            }
        }
    }
    IEnumerator RandomizeTargetPosition()
    {
        // Belirli bir süre bekleyin
        yield return new WaitForSeconds(Random.Range(9f, 10f));

        // Rastgele bir nokta seçin
        Vector2 randomPoint = Random.insideUnitCircle * radius;
        targetPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) + transform.position;

        // İşlemi tekrarlayın
        StartCoroutine(RandomizeTargetPosition());
    }
    public void DamageOn(int a, int b)
    {
        zombieHp -= Random.Range(a, b + 1);
    }

    public void ZombieDamage()
    {
        if (gameObject.name.StartsWith("Boss"))
        {
            int damage = Random.Range(minDamage, maxDamage + 10);
            player.GetComponent<PlayerMovementScript>().TakeDamage(damage);
            player.GetComponent<Animator>().SetBool("IsDamage",true);
        }
        else if (gameObject.name.StartsWith("WalkZombie"))
        {
            int damage = Random.Range(minDamage, maxDamage);
            player.GetComponent<PlayerMovementScript>().TakeDamage(damage);
            player.GetComponent<Animator>().SetBool("IsDamage",true);
        }
    }

    IEnumerator DestroyDiedZombies()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        CapsuleCollider cl = GetComponent<CapsuleCollider>();

        yield return new WaitForSecondsRealtime(0.3f);
        rb.isKinematic = false;

        yield return new WaitForSecondsRealtime(0.3f);
        rb.isKinematic = true;

        zombieNavMash.enabled = false;

        cl.center = new Vector3(0, 1.2f, 0);
        cl.height = 0f;

        Destroy(gameObject, 10f);
    }
}

