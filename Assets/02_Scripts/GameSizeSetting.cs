using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSizeSetting : MonoBehaviour
{
    public static GameSizeSetting instance;
    private int size = 3;
    
    private void Start()
    {
        if (instance == null)
            instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public int GetSize()
    {
        return size;
    }
    public void SetSize(int size)
    {
        if (size <= 1)
        {
            Debug.LogWarning("Game Size를 이상하게 변경하고 있음");
            return;
        }

        this.size = size;
    }
}
