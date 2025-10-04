using System;
using TMPro;
using UnityEngine;

public class Hour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HourUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dateTime = DateTime.Now;

        HourUI.text = dateTime.ToString("HH:mm");
    }
}
