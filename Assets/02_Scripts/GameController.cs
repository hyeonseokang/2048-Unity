using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private int size = 4;
    public BlockManager blockManager;
    public ScoreManager scoreManager;
    void Start()
    {
        size = GameSizeSetting.instance.GetSize();
        Destroy(GameSizeSetting.instance.gameObject);
        blockManager.Init(size);
        StartCoroutine(UpdateBlockInput());
    }
    WaitForSeconds waitForSeconds = new WaitForSeconds(2.0f);
    IEnumerator UpdateBlockInput()
    {
        float time = 0.2f;
        while(true)
        {
            int addScore = 0;
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                addScore = blockManager.MoveRight();
                SoundManager.instance.PlaySlide();
                yield return new WaitForSeconds(time);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                addScore = blockManager.MoveLeft();
                SoundManager.instance.PlaySlide();
                yield return new WaitForSeconds(time);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                addScore = blockManager.MoveUp();
                SoundManager.instance.PlaySlide();
                yield return new WaitForSeconds(time);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                addScore = blockManager.MoveDown();
                SoundManager.instance.PlaySlide();
                yield return new WaitForSeconds(time);
            }
            scoreManager.AddScore(addScore);
            yield return null;
        }
    }

    public void RePlay()
    {
        SoundManager.instance.PlayClick();
        blockManager.Clear();
        scoreManager.Clear();
    }
}
