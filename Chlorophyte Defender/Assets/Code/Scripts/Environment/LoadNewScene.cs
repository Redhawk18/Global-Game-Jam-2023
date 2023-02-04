using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoadName;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("COLLISION");
        SceneManager.LoadScene(sceneToLoadName);
    }
}
