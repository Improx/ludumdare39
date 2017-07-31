using UnityEngine;

public class ClickSoundEffect : MonoBehaviour
{

    [SerializeField] private AudioClip _clickSound;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
        }
    }
}
