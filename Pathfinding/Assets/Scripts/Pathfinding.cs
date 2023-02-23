using System;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Block[] blocks;
    private static Block _currentBlock;
    
    void Start()
    {
        blocks = GetComponents<Block>();
    }
    
    
}
