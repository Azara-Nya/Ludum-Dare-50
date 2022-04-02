using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private string SceneToLoad;
    [SerializeField] private float TranstionTime = 0f;
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
        //animation * alot
        yield return new WaitForSeconds(TranstionTime);
    }
}
