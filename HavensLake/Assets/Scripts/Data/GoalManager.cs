using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameObject ComputerCanvas;
    [SerializeField] private TransitionManager TransitionManager;
    [SerializeField] private List<CheckList> Goals = new List<CheckList>();

    public void CheckIfGoalReached(Item item)
    {
        var goal = Goals.FirstOrDefault(x => x.ItemNameFR.Trim() == item.NameFR.Trim());

        if (goal == null || goal.reached) return;

        goal.NumberOfItem++;
        goal.CheckIfReached();

        CheckIfAllGoalReached();
    }

    private void CheckIfAllGoalReached()
    {
        if(SceneManager.GetActiveScene().name == "Chapter 4")
            ComputerCanvas.SetActive(false);

        if (Goals.All(x => x.reached))
            TransitionManager.LoadNextScene();
    }
}