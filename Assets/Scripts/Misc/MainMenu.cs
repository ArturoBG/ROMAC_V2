using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public Color white;
    public Color black;
    public Animator UIAnimator;

    public void ChangeTextColorWhite(TMP_Text textMesh)
    {
        textMesh.color = white;
    }

    public void ChangeTextColorBlack(TMP_Text textMesh)
    {
        textMesh.color = black;
    }

    public void NewGame()
    {
        UIAnimator.SetTrigger("newgame");
    }

    public void GotoSettings()
    {
        UIAnimator.SetBool("settings", true);
    }

    public void ExitGame()
    {
        UIAnimator.SetBool("exit", true);
    }

    public void BackSettings()
    {
        UIAnimator.SetBool("settings", false);
    }

    public void BackExit()
    {
        UIAnimator.SetBool("exit", false);
    }

    public void QuitGame()
    {
        Application.Quit();    
    }

    public void LoadGame()
    {
        StartCoroutine(LoadGameRoutine());
    }

    IEnumerator LoadGameRoutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("PlayerSandbox");
    }
}
