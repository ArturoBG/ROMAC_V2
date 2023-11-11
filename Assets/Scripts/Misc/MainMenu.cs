using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMesh startGameText;
    public Color white;
    public Color black;


    public void ChangeTextColorWhite(TMP_Text textMesh)
    {
        textMesh.color = white;
    }

    public void ChangeTextColorBlack(TMP_Text textMesh)
    {
        textMesh.color = black;
    }
}
