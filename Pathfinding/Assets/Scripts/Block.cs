using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int weight;
    public bool walkable;

    public List<Block> neighbors;
    public Block previous;

    private bool _defaultState;
    
    
    private GameObject _player;
    void Start()
    {
        //on game reset walkable = defaultState;
        _defaultState = walkable;
    }

    public void Reset()
    {
        previous = null;
    }
    // private void OnMouseDown()
    // {
    //     _player.transform.position = transform.position;
    // }
}
