using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        }



    }
}
