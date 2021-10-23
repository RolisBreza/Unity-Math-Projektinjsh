using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log("It started");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy(other.gameObject);
        Debug.Log("Please work!");
        SceneManager.LoadScene("DeathScreen");
    }
}
