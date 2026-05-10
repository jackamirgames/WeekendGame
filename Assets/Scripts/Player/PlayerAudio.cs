using UnityEngine;
using FMODUnity;

public class PlayerAudio : MonoBehaviour
{
    //Sounds
    [SerializeField] private EventReference sfxOnClicked;

    public void PlayBlastSFX()
    {
        AudioManager.instance.PlayOneShot(sfxOnClicked, transform.position);
    }
}
