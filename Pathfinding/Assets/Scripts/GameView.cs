using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
    public Game Game;
    public GameObject PlayerView;
    [SerializeField] CellView TilePrefab;
    public TextMeshProUGUI thresholdText;
    public TextMeshProUGUI currentCostText;

    private NPCManager _npc;
    List<CellView> _tiles = new();

    void Start()
    {
        _npc = FindObjectOfType<NPCManager>();
        Game.StateChanged += OnGameStateChanged; // subscribe for future changes
        OnGameStateChanged(Game.State); // update for current state
    }

    void OnGameStateChanged(State state)
    {
        PlayerView.transform.position = new Vector3(state.playerPosition.x, state.playerPosition.y, 0);
        var newCell = state.Grid.GetCell(state.playerPosition.x, state.playerPosition.y); 
        newCell.visited = true;
        
        // attempt to increase currentCost
        Game.CurrentCost += newCell.cost;
        currentCostText.text = $"{Game.CurrentCost}";

        thresholdText.text = $"{Game.Threshold}";

        // destroy all tiles
        foreach (var tile in _tiles) Destroy(tile.gameObject);
        _tiles.Clear();
        
        // create all tiles
        for (int y = 0; y < state.Grid.Height; y++)
        {
            for (int x = 0; x < state.Grid.width; x++)
            {
                var tile = Instantiate(TilePrefab, new Vector3(x, y), Quaternion.identity);
                tile.SetCell(state.Grid.GetCell(x, y));
                _tiles.Add(tile);
            }
        }
        
        if (Game.CurrentCost > Game.Threshold)
        {
            NPCManager.GameIsActive = false;
            StartCoroutine(Game.TeleportToStart());
        }

        if (Game.State.playerPosition != Game.goalPosition) return;
        StartCoroutine(Game.TeleportToStart());
        StartCoroutine(_npc.YouWin());
    }
}