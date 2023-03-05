using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    [SerializeField] State state;
    public Vector2Int startPosition;
    public Vector2Int goalPosition;
    [SerializeField] private int defaultThreshold = 34;
    [HideInInspector] public State goal;
    public static int Threshold;
    //[SerializeField] int threshold;
    public static int CurrentCost;
    public event Action<State> StateChanged;

    private NPCManager npc;

    void Start()
    {
        npc = FindObjectOfType<NPCManager>();
        RestartGame();
        goal.playerPosition = goalPosition;
        goal.SetGrid(state.Grid);
        Threshold = defaultThreshold;
    }

    public State State
    {
        get => state;
        set
        {
            state = value;
            StateChanged?.Invoke(value);
        }
    }

    void Update()
    {
        if (!NPCManager.GameIsActive) return;
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) Move(Vector2Int.left);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) Move(Vector2Int.right);
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) Move(Vector2Int.down);
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) Move(Vector2Int.up);
    }

    void Move(Vector2Int vec2direction)
    {
        State current = State;
        Vector2Int newPosition = current.playerPosition + vec2direction;
        if (!State.PositionExistsAndIsWalkableAndIsNotVisited(newPosition)) return;
        current.playerPosition += vec2direction;
        State = current;
    }

    // play path
    IEnumerator Co_PlayPath(IEnumerable<State> path)
    {
        foreach (var state in path)
        {
            yield return new WaitForSeconds(0.25f);
            State = state;
        }
    }

    public void BreadthFirstSearchPaths()
    {
        if (!NPCManager.buttonActive) return;
        NPCManager.buttonActive = false;
        var path = Pathfinder.BreadthFirstModified(state, goal);
        StartCoroutine(Co_PlayPath(path));
    }

    public void Tip()
    {
        var path = Pathfinder.BreadthFirstModified(state, goal);
        State = path.ElementAt(0);
    }

    public void TeleportToStart()
    {
        NPCManager.buttonActive = true;
        state.playerPosition = startPosition;
        foreach (var gridCell in state.Grid.cells) if (gridCell.walkable) gridCell.visited = false;
        Threshold += (int)(CurrentCost * .7f);
        NPCManager.GameIsActive = true;
        CurrentCost = 0;
        State = state;
    }

    public void RestartGame()
    {
        NPCManager.buttonActive = true;
        npc.youWinScreen.SetActive(false);
        state.playerPosition = startPosition;
        foreach (var gridCell in state.Grid.cells)
        {
            if (!gridCell.walkable) continue;
            gridCell.cost = Random.Range(5, 10);
            gridCell.visited = false;
        }
        state.Grid.GetCell(startPosition.x, startPosition.y).cost = 0;
        state.Grid.GetCell(goalPosition.x, goalPosition.y).cost = 0;
        Threshold = defaultThreshold;
        CurrentCost = 0;
        State = state;
    }
}