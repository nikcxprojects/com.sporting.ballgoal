using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int _levelIndex;

    private void Awake()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => LevelLoad());
    }

    private void LevelLoad() => SceneManager.LoadScene($"Level{_levelIndex}");
}
