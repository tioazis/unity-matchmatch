using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Splash : MonoBehaviour
{
    public string leveltolaod = "Menu Scene";
    void Start()
    {
        CanvasGroup canvas = GetComponent<CanvasGroup>();
        canvas.alpha = 0;
        FadeMe();
    }
    public void FadeMe()
    {
        StartCoroutine(DoFade());
    }

    IEnumerator DoFade()
    {
        CanvasGroup canvas = GetComponent<CanvasGroup>();
        while (canvas.alpha < 1)
        {
            canvas.alpha += Time.deltaTime / 3;
            yield return null;
        }
        canvas.interactable = false;

        yield return new WaitForSeconds(5);

        while (canvas.alpha > 0)
        {
            canvas.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        canvas.interactable = false;

        yield return new WaitForSeconds(1);

        // SceneManager.LoadScene("main");
        UnityEngine.SceneManagement.SceneManager.LoadScene(leveltolaod);
    }
}