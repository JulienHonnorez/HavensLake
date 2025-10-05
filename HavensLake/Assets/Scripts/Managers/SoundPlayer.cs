using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource FootStepAudio;
    [SerializeField] private AudioSource DoorAudio;
    [SerializeField] private AudioSource BeepOpenAudio;
    [SerializeField] private AudioSource BeepCloseAudio;
    [SerializeField] private AudioSource CoinAudio;
    [SerializeField] private AudioSource ClickAudio;
    [SerializeField] private AudioSource HandWaterAudio;
    [SerializeField] private AudioSource LakeMoveAudio;

    public void PlayFootStep()
        => FootStepAudio.Play();
    public void PlayDoor()
        => DoorAudio.Play();
    public void PlayBeepOpen()
        => BeepOpenAudio.Play();
    public void PlayBeepClose()
        => BeepCloseAudio.Play();
    public void PlayCoin()
        => CoinAudio.Play();
    public void PlayClick()
        => ClickAudio.Play();
    public void PlayHandWater()
        => HandWaterAudio.Play();
    public void PlayLakeMove()
        => LakeMoveAudio.Play();
}
