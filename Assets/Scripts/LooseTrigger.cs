using UnityEngine;

public class LooseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.Dead();
    }
}
