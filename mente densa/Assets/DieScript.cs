using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieScript : MonoBehaviour
{
    public string sceneToLoad = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("col");
        SceneManager.LoadScene(sceneToLoad);
    }
}
