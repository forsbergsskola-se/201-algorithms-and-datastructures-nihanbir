using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Block[] blocks;
    public Block currentBlock;
    
    private void Start()
    {
        // blocks = GameObject.FindGameObjectWithTag("BlocksParent").GetComponentsInChildren<Block>();
        // for (var i = 0; i < blocks.Length; i++)
        // {
        //     blocks[i].index = i;
        // }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
            if(hit.collider != null)
            {
                Block clickedBlock = hit.transform.GetComponent<Block>();
                if(clickedBlock == null || !clickedBlock.walkable) return;
                
                transform.position = hit.transform.position;
                clickedBlock.previous = currentBlock;
                currentBlock = clickedBlock;

                clickedBlock.walkable = false;
            }
        }
    }
    
    //call from the block later on when cleaning
    public void PlayerTeleport(Block clickedBlock) 
    {
        transform.position = clickedBlock.transform.position;
    }
}
