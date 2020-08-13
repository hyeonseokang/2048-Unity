using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundBlock : MonoBehaviour
{
    public GameObject backgroundBlock;
    public GridLayoutGroup BackGroundBlocks;

    public GameObject[,] backGroundBlocks;

    public Vector2 GetPosition(int x, int y)
    {
        return backGroundBlocks[y, x].transform.position;
    }

    public float Init(int size)
    {
        backGroundBlocks = new GameObject[size, size];

        float sizeRatio = 4.0f / size;
        float spacingSize = 20.0f * sizeRatio;
        float cellSize = 237.5f * sizeRatio;

        int spacfingSize_int = (int)spacingSize;
        BackGroundBlocks.padding = new RectOffset(spacfingSize_int, spacfingSize_int, spacfingSize_int, spacfingSize_int);
        BackGroundBlocks.spacing = new Vector2(spacingSize, spacingSize);
        BackGroundBlocks.cellSize = new Vector2(cellSize, cellSize);

        for (int i=0;i<size;i++)
        {
            for (int j=0;j<size;j++)
            {
                backGroundBlocks[i,j] = Instantiate(backgroundBlock, BackGroundBlocks.transform);
            }    
        }

        return sizeRatio;
    }
}
