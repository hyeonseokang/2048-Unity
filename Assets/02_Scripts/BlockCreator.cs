using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreator : MonoBehaviour
{
    public Block blockObject;
    public GameObject blockParent;

    public void Init(float size)
    {
        blockObject.SetScale(size);
    }

    public Block CreateBlock(Vector2 position)
    {
        Block block = Instantiate(blockObject, position, Quaternion.identity, blockParent.transform);
        return block;
    }
}
