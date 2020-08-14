using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        SoundManager.instance.PlayClick();
        if (sizeIndex < sizeList.Count - 1)
            sizeIndex++;
        UpdateSize();
    }

    public void Prev()
    {
        SoundManager.instance.PlayClick();
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
        SoundManager.instance.PlayClick();
        SceneManager.LoadScene("InGameScene");
    }

    public void SetBgmActive(Toggle toggle)
    {
        SoundManager.instance.PlayClick();
        SoundManager.instance.SetBgmActive(toggle.isOn);
    }
}
