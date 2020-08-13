using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public BackGroundBlock blockScaler;
    public BlockCreator blockCreator;
    public BlockColorController blockColorController;

    public Block[,] blocks;
    private int width;
    private int height;
    private float sizeRatio;
    public void Init(int size)
    { 
        width = size;
        height = size;
        blocks = new Block[height, width];
        sizeRatio = blockScaler.Init(size);
        blockCreator.Init(sizeRatio);
        Invoke("CreateRandomBlock", 0.1f);
    }

    private void CreateRandomBlock()
    {
        int createX, createY;
        while (true)
        {
            createX = Random.Range(0, width);
            createY = Random.Range(0, height);

            if (blocks[createY, createX] == null)
                break;
        }
        Vector2 createPosition = blockScaler.GetPosition(createX, createY);
        blocks[createY, createX] = blockCreator.CreateBlock(createPosition);
        blocks[createY, createX].PlayAnimation("Create");
        blocks[createY, createX].SetNumber(2);
    }

    private int CombineBlock(int x1, int y1, int x2, int y2)
    {
        Destroy(blocks[y2, x2].gameObject,0.1f);
        MoveBlock(x1, y1, x2, y2);
        int blockNumber = blocks[y2, x2].blockNumber;
        blocks[y2, x2].SetNumber(blockNumber * 2);

        Color blockColor = blockColorController.GetColor(blockNumber);
        Debug.Log(blockColor);
        blocks[y2, x2].SetColor(blockColor);

        return blocks[y2, x2].blockNumber;
    }

    private void MoveBlock(int x1, int y1, int x2, int y2)
    {
        if (x1 == x2 && y1 == y2)
            return;

        blocks[y2, x2] = blocks[y1, x1];
        blocks[y1, x1] = null;
        blocks[y2, x2].Move(blockScaler.GetPosition(x2, y2));
    }

    public int MoveRight()
    {
        int score = 0;

        for (int i = 0; i < height; i++)
        {
            for (int j = width - 2; j >= 0; j--)
            {
                if (blocks[i, j] == null)
                    continue;

                int k;
                for (k = j + 1; k < width; k++)
                {
                    if (blocks[i, k] != null)
                        break;
                }

                if (k == width)
                    MoveBlock(j, i, k - 1, i);
                else if (blocks[i, k].blockNumber == blocks[i, j].blockNumber)
                    score += CombineBlock(j, i, k, i);
                else
                    MoveBlock(j, i, k - 1, i);
            }
        }
        CreateRandomBlock();
        return score;
    }
    public int MoveLeft()
    {
        int score = 0;

        for (int i = 0; i < height; i++)
        {
            for (int j = 1; j < width; j++)
            {
                if (blocks[i, j] == null)
                    continue;

                int k;
                for (k = j - 1; k >= 0; k--)
                {
                    if (blocks[i, k] != null)
                        break;
                }

                if (k == -1)
                    MoveBlock(j, i, k + 1, i);
                else if (blocks[i, k].blockNumber == blocks[i, j].blockNumber)
                    score += CombineBlock(j, i, k, i);
                else
                    MoveBlock(j, i, k + 1, i);
            }
        }
        CreateRandomBlock();

        return score;
    }
    public int MoveDown()
    {
        int score = 0;

        for (int i = 0; i < width; i++)
        {
            for (int j = height - 2; j >= 0; j--)
            {
                if (blocks[j, i] == null)
                    continue;

                int k;
                for (k = j + 1; k < height; k++)
                {
                    if (blocks[k, i] != null)
                        break;
                }

                if (k == height)
                    MoveBlock(i, j, i, k - 1);
                else if (blocks[k, i].blockNumber == blocks[j, i].blockNumber)
                    score += CombineBlock(i, j, i, k);
                else
                    MoveBlock(i, j, i, k - 1);
            }
        }
        CreateRandomBlock();
        return score;
    }
    public int MoveUp()
    {
        int score = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 1; j < height; j++)
            {
                if (blocks[j, i] == null)
                    continue;

                int k;
                for (k = j - 1; k >= 0; k--)
                {
                    if (blocks[k, i] != null)
                        break;
                }

                if (k == -1)
                    MoveBlock(i, j, i, k + 1);
                else if (blocks[k, i].blockNumber == blocks[j, i].blockNumber)
                    score += CombineBlock(i, j, i, k);
                else
                    MoveBlock(i, j, i, k + 1);
            }
        }
        CreateRandomBlock();

        return score;
    }

    public void Clear()
    {
        for (int i=0;i<width;i++)
        {
            for (int j=0;j<height;j++)
            {
                if (blocks[j, i] != null)
                {
                    Destroy(blocks[j, i].gameObject);
                }
            }
        }

        Invoke("CreateRandomBlock", 0.1f);
    }
}
