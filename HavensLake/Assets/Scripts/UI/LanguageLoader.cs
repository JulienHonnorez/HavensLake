using System.IO;
using TMPro;
using UnityEngine;

public class LanguageLoader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LabelMesh;
    [SerializeField] private TextMeshProUGUI TextMesh;

    [SerializeField] private string LabelFR;
    [SerializeField] private string LabelEN;

    [SerializeField][TextArea] private string TextFR;
    [SerializeField][TextArea] private string TextEN;

    private void Start()
    {
        CheckObjectSetup();
        SettingsManager.Instance.onLanguageSwitch += OnLanguageSwitch;
    }

    private void OnEnable()
    {
        OnLanguageSwitch();
    }

    private void CheckObjectSetup()
    {
        if (LabelMesh is not null)
            if (string.IsNullOrEmpty(LabelFR) || string.IsNullOrEmpty(LabelEN))
                ExceptionManager.ThrowException(name, nameof(LanguageLoader), "Les labels ne sont pas correctement configur�s.");
        if (TextMesh is not null)
            if (string.IsNullOrEmpty(TextFR) || string.IsNullOrEmpty(TextEN))
                ExceptionManager.ThrowException(name, nameof(LanguageLoader), "Les textes ne sont pas correctement configur�s.");
    }

    private void OnLanguageSwitch()
    {
        if (LabelMesh is not null)
            LabelMesh.text = SettingsManager.Instance.IsGameInFrench() ? LabelFR : LabelEN;
        if (TextMesh is not null)
            TextMesh.text = SettingsManager.Instance.IsGameInFrench() ? TextFR : TextEN;
    }
}