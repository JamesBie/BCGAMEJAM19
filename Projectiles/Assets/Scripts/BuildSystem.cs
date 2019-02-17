using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{

    //reference to the BlockSystem script
    private BlockSystem blockSys;

    //variables to hold data regarding current block type
    private int currentBlockID = 0;
    private Block currentBlock;

    //variable for however many objects we can build
    private int selectableBlocksTotal;

    //Variables fro the block template
    public GameObject blockTemplate;
    private SpriteRenderer currentRend;

    //bools to control building system
    private bool buildModeOn = false;
    private bool buildBlocked = false;

    //float to adjust the size of blocks when placing in world
    [SerializeField]
    private float blockSizeMod;

    //layer masks to control raycasting
    [SerializeField]
    private LayerMask solidNoBuildLayer;

    [SerializeField]
    private LayerMask allBlocksLayer;

    //reference to the player object
    public GameObject playerObject;
	public GameObject ObjecttoPlace;
    [SerializeField]
    private float maxBuildDistance;

    private void Awake()
    {
        //store reference to block system script
        blockSys = GetComponent<BlockSystem>();

        //find player and store reference
        playerObject = GameObject.Find("Player");
    }

    private void Update()
    {
        //if E key pressed, toggle build mode
        if(Input.GetKeyDown("e"))
        {
            //flip bool
            buildModeOn = !buildModeOn;

            //if we have a current template, destroy it
            if (blockTemplate != null)
            {
                Destroy(blockTemplate);
            }

            //if we don't have a current block type set
            if (currentBlock == null)
            {
                //ensure allBlocks array is ready
                if (blockSys.allBlocks[currentBlockID] != null)
                {
                    //get a new currentBlock using the ID variable
                    currentBlock = blockSys.allBlocks[currentBlockID];
                }
            }

            if (buildModeOn)
            {
                //create new object for blockTemplate
                blockTemplate = new GameObject("Solar Panel");
                //add and store reference to a SpriteRenderer on the template object
                currentRend = blockTemplate.AddComponent<SpriteRenderer>();
                //sorting order of template is 10
                currentRend.sortingOrder = 10;
                //set the sprite of the template object to match current block type
                currentRend.sprite = currentBlock.blockSprite;
            }
        }



        if (buildModeOn && blockTemplate != null)
        {
            float newPosX = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x / blockSizeMod) * blockSizeMod;
            float newPosY = Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).y / blockSizeMod) * blockSizeMod;
            blockTemplate.transform.position = new Vector2(newPosX, newPosY);

            RaycastHit2D rayHit = Physics2D.Raycast(blockTemplate.transform.position, Vector2.zero, Mathf.Infinity, solidNoBuildLayer);

            if (rayHit.collider != null)
            {
                buildBlocked = true;
            }
            else
            {
                buildBlocked = false;
            }

            if (Vector2.Distance(playerObject.transform.position, blockTemplate.transform.position) > maxBuildDistance)
            {
                buildBlocked = true;
            }

            if (buildBlocked)
            {
                currentRend.color = new Color(1f, 0f, 0f, 1f);
            }
            else
            {
                currentRend.color = new Color(1f, 1f, 1f, 1f);
            }

            float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

            if (mouseWheel != 0)
            {
                selectableBlocksTotal = blockSys.allBlocks.Length - 1;

                if (mouseWheel > 0)
                {
                    currentBlockID--;

                    if (currentBlockID < 0)
                    {
                        currentBlockID = selectableBlocksTotal;
                    }
                }
                else if (mouseWheel < 0)
                {
                    currentBlockID++;

                    if (currentBlockID > selectableBlocksTotal)
                    {
                        currentBlockID = 0;
                    }
                }

                currentBlock = blockSys.allBlocks[currentBlockID];
                currentRend.sprite = currentBlock.blockSprite;
            }

            if (Input.GetMouseButtonDown(0) && buildBlocked == false)
            {
                GameObject newBlock = new GameObject(currentBlock.blockName);
                newBlock.transform.position = blockTemplate.transform.position;
                SpriteRenderer newRend = newBlock.AddComponent<SpriteRenderer>();
				newBlock.AddComponent<WallHp>();
                newRend.sprite = currentBlock.blockSprite;
				newBlock.tag="Panel";

                if (currentBlock.isSolid == true)
                {
                    newBlock.AddComponent<BoxCollider2D>();
                    newBlock.layer = 10;
                }
            }

            if (Input.GetMouseButtonDown(1) && blockTemplate != null)
            {
                RaycastHit2D destroyHit = Physics2D.Raycast(blockTemplate.transform.position, Vector2.zero, Mathf.Infinity, allBlocksLayer);

                if (destroyHit.collider != null)
                {
//Destroy(destroyHit.collider.gameObject);
                }
            }
        }
    }
}
