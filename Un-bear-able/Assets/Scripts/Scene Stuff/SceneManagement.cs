using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void goToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void goToSingle()
    {
        SceneManager.LoadScene("SinglePlayer");
    }

    public void goToMulti()
    {
        SceneManager.LoadScene("HomeScene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("InsideHome");
    }
}
