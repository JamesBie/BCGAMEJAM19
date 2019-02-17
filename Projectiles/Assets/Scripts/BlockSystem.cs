using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSystem : MonoBehaviour
{
    //arrays for solid blocks
    //the two arrays need to match up

    [SerializeField]
    //contains sprites
    private Sprite[] solidBlocks;

    [SerializeField]
    //contains names
    private string[] solidNames;

    //array to store all blocks created in Awake()
    public Block[] allBlocks;

    private void Awake()
    {
        //initialize allBlocks array
        allBlocks = new Block[solidBlocks.Length];

        //temp int to store block ID as we go
        int newBlockID = 0;

        //for loops to populate main allBlocks array
        for (int i = 0; i < solidBlocks.Length; i++)
        {
            allBlocks[newBlockID] = new Block(newBlockID, solidNames[i], solidBlocks[i], true);
            Debug.Log("Solid Block: allBlocks[" + newBlockID + "] = " + solidBlocks[i]);
            newBlockID++;
        }

    }
}

//custom object
public class Block
{
    //number to identify block (may not be needed)
    public int blockID;

    //identifiers
    public string blockName;
    public Sprite blockSprite;
    public bool isSolid;

    public Block(int id, string myName, Sprite mySprite, bool amISolid)
    {
        blockID = id;
        blockName = myName;
        blockSprite = mySprite;
        isSolid = amISolid;
    }
}
