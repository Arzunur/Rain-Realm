using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Ease Anim;

    [SerializeField] private Image fadeImage;

    private void Start()
    {
        FadeIn();
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }
    public void Quit() => Application.Quit();

    private void FadeIn()
    {
        fadeImage.color = new Color(0, 0, 0, 1);
        fadeImage.DOFade(0, 1f);
    }

    private void FadeOut(string sceneName)
    {
        fadeImage.DOFade(1, 1f).OnComplete(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneName);
        });
    }
}
