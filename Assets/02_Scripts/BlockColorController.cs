using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColorController : MonoBehaviour
{
    [SerializeField] private Color color2;
    [SerializeField] private Color color4;
    [SerializeField] private Color color8;
    [SerializeField] private Color color16;
    [SerializeField] private Color color32;
    [SerializeField] private Color color64;
    [SerializeField] private Color color128;
    [SerializeField] private Color color256;
    [SerializeField] private Color color512;
    [SerializeField] private Color color1024;
    [SerializeField] private Color color2048;

    public Color GetColor(int number)
    {
        switch(number)
        {
            case 2:
                return color2;
            case 4:
                return color4;
            case 8:
                return color8;
            case 16:
                return color16;
            case 32:
                return color32;
            case 64:
                return color64;
            case 128:
                return color128;
            case 256:
                return color256;
            case 512:
                return color512;
            case 1024:
                return color1024;
            case 2048:
                return color2048;
        }
        return Color.black;
    }
}
