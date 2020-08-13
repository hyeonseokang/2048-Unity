using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private List<int> sizeList = new List<int>(new int[] {
        3,
        4,
        5,
        6,
        7,
        8,
    });
    private int sizeIndex = 0;
    public TextMeshProUGUI sizeText;
    public void Next()
    {
        if (sizeIndex < sizeList.Count - 1)
            sizeIndex++;
        UpdateSize();
    }

    public void Prev()
    {
        if (sizeIndex != 0)
            sizeIndex--;
        UpdateSize();
    }

    private void UpdateSize()
    {
        GameSizeSetting.instance.SetSize(sizeList[sizeIndex]);
        sizeText.text = sizeList[sizeIndex] + "x" + sizeList[sizeIndex];
    }

    public void GameStart()
    {
        SceneManager.LoadScene("InGameScene");
    }
}
