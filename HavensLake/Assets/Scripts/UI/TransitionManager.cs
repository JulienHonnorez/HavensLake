using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private string NextSceneName;
    [SerializeField] private GameObject Title;

    private void OnEnable()
    {
        Animator.gameObject.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(StartCoroutine());
    }

    private IEnumerator StartCoroutine()
    {
        Animator.SetTrigger("FadeOut");
        if (SceneManager.GetActiveScene().name == "MainMenu")
            yield return new WaitForSeconds(2f);
        else
            yield return new WaitForSeconds(2.9f);
        Animator.gameObject.SetActive(false);
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadNextSceneCoroutine(NextSceneName));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadNextSceneCoroutine("MainMenu"));
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator LoadNextSceneCoroutine(string scene)
    {
        if (Title != null)
            Title.SetActive(true);
        Animator.gameObject.SetActive(true);
        Animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(2.9f);
        SceneManager.LoadScene(scene);
    }
}
