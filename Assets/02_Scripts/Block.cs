using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public int blockNumber { get; private set; }

    public Image image; 
    public TextMeshProUGUI text;
    public Animator animator;
    public void SetNumber(int num)
    {
        blockNumber = num;
        text.text = num.ToString();
    }

    public void SetColor(Color color)
    {
        image.color = color;
    }

    public void SetScale(float size)
    {
        Vector2 sizeDelta = new Vector2(237.5f, 237.5f);
        sizeDelta.x *= size;
        sizeDelta.y *= size;
        GetComponent<RectTransform>().sizeDelta = sizeDelta;
        text.GetComponent<RectTransform>().localScale = new Vector2(size, size);
    }

    public void PlayAnimation(string trigger)
    {
        animator.SetTrigger("Create");
    }
    public void Move(Vector3 targetPositoin)
    {
        StopAllCoroutines();
        StartCoroutine(MoveCoroutine(targetPositoin));
    }
    IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
        float t = 0.0f;
        while(transform.position != targetPosition)
        {
            t += Time.deltaTime * 2.0f;
            transform.position = Vector3.Lerp(transform.position, targetPosition, t);
            yield return null;
        }
    }
}
