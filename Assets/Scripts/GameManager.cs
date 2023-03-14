using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private Text _lifeText;
    [SerializeField] private Transform _spawnTransform;
    [SerializeField] private GameObject _ballPrefab;
    private GameObject _currentBall;
    private int _lifes = 3;
    private bool _isPaused;
    public bool isPaused => _isPaused;

    private void Awake()
    {
        instance = this;
        Respawn();
    }

    public void Dead()
    {
        Respawn();
        AudioManager.instance.PlayAudio(AudioManager.instance.looseClip);
        if (AudioManager.instance.isVibration)
            Vibration.Vibrate();
        _lifes -= 1;
        _lifeText.text = _lifes.ToString();
        if (_lifes == 0)
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void Respawn()
    {
        if(_currentBall != null)
            Destroy(_currentBall);
        _currentBall = Instantiate(_ballPrefab);
        _currentBall.transform.position = _spawnTransform.position;
    }

    public void SetPause(bool isPaused) => _isPaused = isPaused;

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
