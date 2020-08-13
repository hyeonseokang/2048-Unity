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

    IEnumerator UpdateBlockInput()
    {
        float time = 0.2f;
        while(true)
        {
            int addScore = 0;
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                addScore = blockManager.MoveRight();
                yield return new WaitForSeconds(time);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                addScore = blockManager.MoveLeft();
                yield return new WaitForSeconds(time);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                addScore = blockManager.MoveUp();
                yield return new WaitForSeconds(time);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                addScore = blockManager.MoveDown();
                yield return new WaitForSeconds(time);
            }
            scoreManager.AddScore(addScore);
            yield return null;
        }
    }

    public void RePlay()
    {
        blockManager.Clear();
        scoreManager.Clear();
    }
}
