using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [SerializeField] private GameObject HouseInCanvas;              // 1
    [SerializeField] private GameObject ComputerCanvas;             // 2
    [SerializeField] private GameObject HouseOutCanvas;             // 3
    [SerializeField] private GameObject LakeSideCanvas;             // 4
    [SerializeField] private GameObject PontoonCanvas;              // 5
    [SerializeField] private GameObject LakeInCanvas;               // 6
    [SerializeField] private GameObject LakeCenterCanvas;           // 7
    [SerializeField] private GameObject BackpackCanvas;             // 8
    [SerializeField] private GameObject LakeSideCollectCanvas;      // 9

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HouseInCanvas.SetActive(false);
        ComputerCanvas.SetActive(false);
        HouseOutCanvas.SetActive(true);
        LakeSideCanvas.SetActive(false);
        PontoonCanvas.SetActive(false);
        LakeInCanvas.SetActive(false);
        LakeCenterCanvas.SetActive(false);
        BackpackCanvas.SetActive(false);
        LakeSideCollectCanvas.SetActive(false);
    }

    public void Navigate(int index)
    {
        if (index == 1)
        {
            HouseInCanvas.SetActive(true);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
        }
        if (index == 2)
        {
            HouseInCanvas.SetActive(false);
            ComputerCanvas.SetActive(true);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
        }
        if (index == 3)
        {
            HouseInCanvas.SetActive(false);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(true);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
        }
        if (index == 4)
        {
            HouseInCanvas.SetActive(false);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(true);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
        }
        if (index == 5)
        {
            HouseInCanvas.SetActive(false);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(true);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
        }
        if (index == 6)
        {
            HouseInCanvas.SetActive(false);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(true);
            LakeCenterCanvas.SetActive(false);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
        }
        if (index == 7)
        {
            HouseInCanvas.SetActive(false);
            ComputerCanvas.SetActive(false);
            HouseOutCanvas.SetActive(false);
            LakeSideCanvas.SetActive(false);
            PontoonCanvas.SetActive(false);
            LakeInCanvas.SetActive(false);
            LakeCenterCanvas.SetActive(true);
            BackpackCanvas.SetActive(false);
            LakeSideCollectCanvas.SetActive(false);
        }
        if (index == 8)
            BackpackCanvas.SetActive(!BackpackCanvas.activeSelf);
        if (index == 9)
            LakeSideCollectCanvas.SetActive(!LakeSideCollectCanvas.activeSelf);
    }
}
