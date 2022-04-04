using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string SceneToLoad;
    [SerializeField] private float TranstionTime;
    [SerializeField] private float FadeTime;
    [SerializeField] private Animator Cam;
    [SerializeField] private Animator GameOverFade;
    [SerializeField] private Animator GameOver;
    [SerializeField] private Animator MainMenu;
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject MainM;
    private bool startG;
    public Sleeper Sz;
    public bool CanPlay = false;

    void Update()
    {
        if (Sz.IsAsleep)
        {
            StartCoroutine(AnimmEnd());
            CanPlay = false;
        }
        else
        {
            startG = false;
        }
    }
    public void LoadScene()
    {
        StartCoroutine(Loader());
    }
    public void QuitGame()
    {
        StartCoroutine(Quiter());
    }
    public void StartingAnimation()
    {
        StartCoroutine(Animm());
    }
    public void PlayerOI()
    {
        CanPlay = !CanPlay;
    }
    public void MainMenuApear()
    {
        if (MainMenu.GetBool("MainApear") == false)
        {
            MainMenu.SetBool("MainApear", true);
        }
        else
        {
            MainMenu.SetBool("MainApear", false);
        }

    }
    public void MainApearer()
    {
        StartCoroutine(ReapearMain());
    }
    IEnumerator Quiter()
    {
        //animation
        yield return new WaitForSeconds(TranstionTime);
        Application.Quit();
    }
    IEnumerator Loader()
    {
        //animation
        yield return new WaitForSeconds(TranstionTime);
        SceneManager.LoadScene(SceneToLoad);
    }
    IEnumerator Animm()
    {
        Cam.SetBool("StartWork", true);
        Cam.SetBool("EndWork", false);
        yield return new WaitForSeconds(TranstionTime);
        Cam.SetBool("StartWork", false);
        CanPlay = !CanPlay;
    }
    IEnumerator AnimmEnd()
    {
        if (!startG)
        {
            MainM.SetActive(false);
            GameOverFade.SetBool("StartFade", true);
            Player.position = new Vector3(0, -0.2f, 0);
            yield return new WaitForSeconds(FadeTime);
            Cam.SetBool("EndWork", true);
            yield return new WaitForSeconds(0.1f);
            Cam.SetBool("EndWork", true);
            Cam.SetBool("StartWork", false);
            yield return new WaitForSeconds(FadeTime * 2);
            GameOver.SetBool("ApearGO", true);
            GameOverFade.SetBool("StartFade", false);
            Cam.SetBool("EndWork", false);
            startG = true;
        }
    }

    IEnumerator ReapearMain()
    {
        MainMenu.SetBool("MainApear", false);
        yield return new WaitForSeconds(1f);
        MainMenu.SetBool("MainApear", true);
    }

}
