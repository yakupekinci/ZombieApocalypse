using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Tooltip("Furthest distance bullet will look for target")]
    public float maxDistance = 1000000f;
    public GameObject decalHitWall;
    public float floatInFrontOfWall = 0.1f;
    public GameObject bloodEffect;
    public LayerMask ignoreLayer;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, ~ignoreLayer))
        {
            if (hit.transform.CompareTag("LevelPart"))
            {
                if (decalHitWall)
                {
                    Instantiate(decalHitWall, hit.point + hit.normal * floatInFrontOfWall, Quaternion.LookRotation(hit.normal));
                }
            }
            else if (hit.transform.CompareTag("Dummie"))
            {
                Collider headCollider = hit.transform.Find("Head")?.GetComponent<Collider>();
                if (headCollider != null && headCollider.bounds.Contains(hit.point))
                {
                    if (bloodEffect)
                    {
                        Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    }

                    ZombieMovement zombieMovement = hit.transform.GetComponent<ZombieMovement>();
                    if (zombieMovement != null)
                    {
                        zombieMovement.DamageOn(99, 100);
                        if (zombieMovement.zombieHp <= 0)
                        {
                            zombieMovement.anim.SetBool("HeadShot", true);
                        }
                        else
                        {
                            zombieMovement.DamageOn(99,100);
                            if (zombieMovement.zombieHp <= 0)
                            {
                                int num = Random.Range(1, 3);
                                if (num == 1)
                                {
                                    zombieMovement.anim.SetBool("isDying", true);
                                }
                                else if (num == 2)
                                {
                                    zombieMovement.anim.SetBool("isDying2", true);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (bloodEffect)
                    {
                        Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    }

                    ZombieMovement zombieMovement = hit.transform.GetComponent<ZombieMovement>();
                    if (zombieMovement != null)
                    {
                        zombieMovement.DamageOn(30, 40);
                        if (zombieMovement.zombieHp <= 0)
                        {
                            int num = Random.Range(1, 3);
                            if (num == 1)
                            {
                                zombieMovement.anim.SetBool("isDying", true);
                            }
                            else if (num == 2)
                            {
                                zombieMovement.anim.SetBool("isDying2", true);
                            }
                        }
                    }
                }
            }

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 2f); // Destroy the bullet after 2 seconds if it doesn't hit anything
        }
    }
}
