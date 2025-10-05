using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private TransitionManager TransitionManager;
    [SerializeField] private List<CheckList> Goals = new List<CheckList>();

    public void CheckIfGoalReached(Item item)
    {
        var goal = Goals.FirstOrDefault(x => x.ItemNameFR == item.NameFR);

        if (goal == null || goal.reached) return;

        goal.NumberOfItem++;
        goal.CheckIfReached();

        CheckIfAllGoalReached();
    }

    private void CheckIfAllGoalReached()
    {
        if (Goals.All(x => x.reached))
            TransitionManager.LoadNextScene();
    }
}