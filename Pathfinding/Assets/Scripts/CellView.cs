using UnityEngine;
using UnityEngine.Serialization;

public class CellView : MonoBehaviour
{
    public Sprite weight5;
    public Sprite weight6;
    public Sprite weight7;
    public Sprite weight8;
    public Sprite weight9;
    public SpriteRenderer sprite;
    public void SetCell(Cell cell)
    {
        sprite.sprite = cell.cost switch
        {
            5 => weight5,
            6 => weight6,
            7 => weight7,
            8 => weight8,
            9 => weight9,
            _ => sprite.sprite
        };
        sprite.enabled = true;
        if (!cell.walkable || cell.visited || cell.cost == 0) sprite.enabled = false;
    }
}