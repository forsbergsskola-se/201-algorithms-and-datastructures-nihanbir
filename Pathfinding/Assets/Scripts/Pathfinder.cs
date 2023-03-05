using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public static class Pathfinder
{
    public static IEnumerable<State> BreadthFirstModified(State start, State end)
    {
        
        // make a queue of paths
        Queue<Path> todoPaths = new();
        
        // make a dictionary for paths, using the TotalCost for that path as a key
        Dictionary<int, Path> finalizedPaths = new();
        
        // start off by making a new path out of the start state, where it considers itself visited
        var startPath = new Path(new[] { start }, new HashSet<State> { start }, Game.CurrentCost);
        
        todoPaths.Enqueue(startPath);
        
        while (todoPaths.Count > 0)
        {
            Path currentPath = todoPaths.Dequeue();
            State currNode = currentPath.States[^1];
            
            // loop over all adjacent states
            foreach (var neighbor in currNode.GetSuccessors())
            {
                // neighbor already visited in this path, continue
                if (currentPath.VisitedStates.Contains(neighbor) || neighbor.Grid.GetCell(neighbor.playerPosition).visited) continue;
                
                // found end, append the neighbor and return path

                if (neighbor.Equals(end))
                {
                    return currentPath.States.Skip(1).Concat(new[] { neighbor }).ToArray();
                }

                // get the cost of the neighbor cell
                var cellCost = neighbor.Grid.GetCell(neighbor.playerPosition).cost;
                
                // create a clone clone the path as a new path
                Path newPath = new Path(currentPath.States, new HashSet<State>(currentPath.VisitedStates), currentPath.TotalCost);
                
                // append the neighbor state to the end of the new path
                newPath.States = newPath.States.Concat(new[] { neighbor }).ToArray();

                newPath.VisitedStates.Add(neighbor);
                
                // add neighbour cell's cost to path's total cost
                newPath.TotalCost += cellCost;
                
                // go to next iteration
                if (newPath.TotalCost > Game.Threshold) finalizedPaths.TryAdd(newPath.TotalCost, newPath);
                else todoPaths.Enqueue(newPath);
            }
        }
        // no paths left to dequeue, and we didnt find the goal.
        // loop over the finalizedPaths list, and return the path with the highest cost
        
        int maxCost = 0;
        foreach (var keyValuePair in finalizedPaths) maxCost = Math.Max(keyValuePair.Key, maxCost);
        return finalizedPaths[maxCost].States.Skip(1).ToArray();
    }
}