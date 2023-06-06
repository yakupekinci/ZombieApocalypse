using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public static bool hp;
    public GameObject playerAnim;
    GameObject door;
    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door"); 
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "OpenDoor")
        {
            StartCoroutine(WaitDoor());

        }
        if (other.gameObject.name == "PlayerAnim")
        {

            playerAnim.GetComponent<Animator>().SetBool("isPlayer", true);
        }
        if (other.gameObject.name == "StartGame")
        {
            hp = true;
            OpenGame();
        }
    }
    IEnumerator WaitDoor()
    {
        door.GetComponent<Animator>().SetBool("isOpen", true);
        yield return new WaitForSecondsRealtime(1f);
        // this.GetComponent<PlayerMovementScript>().enabled = false;

    }
    public void OpenGame()
    {
        if (gameManager.easy)
        {
            SceneManager.LoadScene(1);
        }
        if (gameManager.normal)
        {
            SceneManager.LoadScene(2);
        }

        if (gameManager.hard)
        {
            SceneManager.LoadScene(3);
        }

    }
}
