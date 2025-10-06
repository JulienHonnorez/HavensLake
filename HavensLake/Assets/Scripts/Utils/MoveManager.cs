using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseCanvas;                // 0
    [SerializeField] private GameObject HouseInCanvas;              // 1
    [SerializeField] private GameObject ComputerCanvas;             // 2
    [SerializeField] private GameObject HouseOutCanvas;             // 3
    [SerializeField] private GameObject LakeSideCanvas;             // 4
    [SerializeField] private GameObject PontoonCanvas;              // 5
    [SerializeField] private GameObject LakeInCanvas;               // 6
    [SerializeField] private GameObject LakeCenterCanvas;           // 7
    [SerializeField] private GameObject BackpackCanvas;             // 8
    [SerializeField] private GameObject LakeSideCollectCanvas;      // 9
    [SerializeField] private GameObject NetCollectCanvas;           // 10
    [SerializeField] private GameObject PontoonCollectCanvas;       // 11
    [SerializeField] private GameObject CenterCollectCanvas;       // 12

    [SerializeField] private AudioSource LakeAudio;
    [SerializeField] private AudioSource NatureAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseCanvas.SetActive(false);
        HouseInCanvas.SetActive(false);
        ComputerCanvas.SetActive(false);
        HouseOutCanvas.SetActive(true);
        LakeSideCanvas.SetActive(false);
        PontoonCanvas.SetActive(false);
        LakeInCanvas.SetActive(false);
        LakeCenterCanvas.SetActive(false);
        BackpackCanvas.SetActive(false);
        LakeSideCollectCanvas.SetActive(false);
        NetCollectCanvas.SetActive(false);
        PontoonCollectCanvas.SetActive(false);
        CenterCollectCanvas.SetActive(false);

        LakeAudio.gameObject.SetActive(true);
        NatureAudio.gameObject.SetActive(true);
    }

    public void Navigate(int index)
    {
        if (index == 0)
            PauseCanvas.SetActive(!PauseCanvas.activeSelf);
        if (index == 1)
        {
            PauseCanvas.SetActive(false);
            HouseInCanvas.SetActive(true);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
            NetCollectCanvas.SetActive(false);
            PontoonCollectCanvas.SetActive(false);
            CenterCollectCanvas.SetActive(false);

            LakeAudio.gameObject.SetActive(false);
            NatureAudio.gameObject.SetActive(true);
            NatureAudio.volume = 0.3f;
        }
        if (index == 2)
        {
            PauseCanvas.SetActive(false);
            HouseInCanvas.SetActive(true);
            ComputerCanvas.SetActive(true);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
            NetCollectCanvas.SetActive(false);
            PontoonCollectCanvas.SetActive(false);
            CenterCollectCanvas.SetActive(false);
        }
        if (index == 3)
        {
            PauseCanvas.SetActive(false);
            HouseInCanvas.SetActive(false);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(true);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
            NetCollectCanvas.SetActive(false);
            PontoonCollectCanvas.SetActive(false);
            CenterCollectCanvas.SetActive(false);

            LakeAudio.gameObject.SetActive(true);
            NatureAudio.gameObject.SetActive(true);
            NatureAudio.volume = 1f;
        }
        if (index == 4)
        {
            PauseCanvas.SetActive(false);
            HouseInCanvas.SetActive(false);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(true);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
            NetCollectCanvas.SetActive(false);
            PontoonCollectCanvas.SetActive(false);
            CenterCollectCanvas.SetActive(false);
        }
        if (index == 5)
        {
            PauseCanvas.SetActive(false);
            HouseInCanvas.SetActive(false);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(true);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
            NetCollectCanvas.SetActive(false);
            PontoonCollectCanvas.SetActive(false);
            CenterCollectCanvas.SetActive(false);
        }
        if (index == 6)
        {
            PauseCanvas.SetActive(false);
            HouseInCanvas.SetActive(false);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(true);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
            NetCollectCanvas.SetActive(false);
            PontoonCollectCanvas.SetActive(false);
            CenterCollectCanvas.SetActive(false);
        }
        if (index == 7)
        {
            PauseCanvas.SetActive(false);
            HouseInCanvas.SetActive(false);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(true);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
            NetCollectCanvas.SetActive(false);
            PontoonCollectCanvas.SetActive(false);
            CenterCollectCanvas.SetActive(false);
        }
        if (index == 8)
            BackpackCanvas.SetActive(!BackpackCanvas.activeSelf);
        if (index == 9)
            LakeSideCollectCanvas.SetActive(!LakeSideCollectCanvas.activeSelf);
        if (index == 10)
            NetCollectCanvas.SetActive(!NetCollectCanvas.activeSelf);
        if (index == 11)
            PontoonCollectCanvas.SetActive(!PontoonCollectCanvas.activeSelf);
        if (index == 12)
            CenterCollectCanvas.SetActive(!CenterCollectCanvas.activeSelf);
    }
}
