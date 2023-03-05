using UnityEngine;

public class CellView : MonoBehaviour
{
    public SpriteRenderer sprite;
    public void SetCell(Cell cell)
    {
        sprite.enabled = true;
        if (!cell.walkable || cell.visited) sprite.enabled = false;
    }
}