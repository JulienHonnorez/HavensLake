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
    [SerializeField] private AudioSource LakeCanneAudio;
    [SerializeField] private AudioSource LakeNetAudio;
    [SerializeField] private AudioSource BubbleAudio;
    [SerializeField] private AudioSource CanCallBackAudio;
    [SerializeField] private AudioSource ChainAudio;
    [SerializeField] private AudioSource ChainGotItAudio;
    [SerializeField] private AudioSource TreuilAudio;

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
    public void PlayLakeCanne()
        => LakeCanneAudio.Play();
    public void PlayLakeNet()
        => LakeNetAudio.Play();
    public void PlayBubble()
        => BubbleAudio.Play();
    public void PlayCanCallBack()
        => CanCallBackAudio.Play();
    public void PlayChain()
        => ChainAudio.Play();
    public void PlayChainGotIt()
        => ChainGotItAudio.Play();
    public void PlayTreuil()
        => TreuilAudio.Play();
    public void StopTreuil()
        => TreuilAudio.Stop();
}
