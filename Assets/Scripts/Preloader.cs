using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// The class is responsible for loading all the necessary game 
/// objects and then launching the main scene.
/// </summary>
public class Preloader : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(WaitObjectsLoader());
    }

    // Start waiting before initializing the required objects
    private IEnumerator WaitObjectsLoader()
    {
        yield return new WaitWhile(predicate: () => AudioManager.instance == null);

        SceneManager.LoadScene("Menu");
    }
}