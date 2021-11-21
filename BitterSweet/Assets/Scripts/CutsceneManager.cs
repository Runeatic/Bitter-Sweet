using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public float sceneLength;
    void Start()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(sceneLength);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
