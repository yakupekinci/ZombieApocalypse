using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public int zombiesPerWave = 10;
    public GameObject zombieSpawnArea;
    public float startingTime = 30f;
    public float timeDecreasePerWave = 10f;

    private List<GameObject> zombies = new List<GameObject>();

    private int waveCount = 1;
    private int minDamage = 5;
    private int maxDamage = 10;
    public float time;

    void Start()
    {
        PlayerPrefs.Save();
        time = startingTime;
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                startingTime += timeDecreasePerWave;
                time = startingTime;
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            SpawnWave();
            yield return new WaitForSeconds(time);
            waveCount++;
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < zombiesPerWave * waveCount; i++)
        {
            int randomIndex = Random.Range(0, zombiePrefabs.Length);
            GameObject randomZombiePrefab = zombiePrefabs[randomIndex];
            Vector3 randomPos = zombieSpawnArea.transform.position + Random.insideUnitSphere * zombieSpawnArea.transform.localScale.x / 2f;
            randomPos.y = 4.2f;
            GameObject newZombie = Instantiate(randomZombiePrefab, randomPos, Quaternion.identity);
            zombies.Add(newZombie);

            ZombieMovement zombieMovement = newZombie.GetComponent<ZombieMovement>();
            if (zombieMovement != null)
            {
                SetZombieDamage(zombieMovement);
            }
        }
        zombiesPerWave += 1;
    }

    void SetZombieDamage(ZombieMovement zombieMovement)
    {
        zombieMovement.minDamage = minDamage;
        zombieMovement.maxDamage = maxDamage;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}