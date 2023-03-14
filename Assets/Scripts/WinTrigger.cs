using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] private int _nextLevelIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene($"Level{_nextLevelIndex}");
    }
}
