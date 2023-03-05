In a grid of size NxM, there are K obstacles placed randomly. Each obstacle has a weight associated with it, 
which is a positive integer. The task is to find the path from the bottom-right corner to top-left corner 
that passes through the obstacles with the minimum total weight.

However, there is a catch - when the player pass through an obstacle, its weight is added to a running sum. 
If the running sum becomes greater than a threshold value T, the player is teleported back to the bottom-right corner, 
and must start over.

To make the problem more interesting, the teleportation threshold T is not constant - it changes every time you get teleported. 
Specifically, after being teleported, the new threshold value is set to be the sum of the weights of the obstacles the player passed 
through on their previous attempt, multiplied by a constant C. At the start, T is always smaller than the sum of weights of the smallest 
weight path to enforce at least one teleportation.

The goal is to find the path that minimizes the sum of the weights of the obstacles the player passes through, while taking into account 
the random placement of the obstacles and the changing teleportation threshold.
When the goal can't be reached with the smallest weight path, the optimal thing for the player to do, would be to expand T maximally by 
taking the biggest weight path. To solve the problem of finding the biggest weight path, a case which swaps the objective of the algorithm can be added.

Initially thought algorithm was Dijkstra however it didn't solve the problem of collecting the heighest weight when there was no path to the goal. 

A modified version of BFS algorithm was used to solve this problem.
BFS stores copies of all paths (when predecessor method isn't used), therefore this seemed like the best option because all paths needed to be compared to eachother to know which one reached the highest weight when the goal wasn't reachable.

Modified BFS was made to take weight into account and to look at **all** ways to get to any given tile, not just the fastest.

##Media
![1](https://user-images.githubusercontent.com/112477158/222987670-f2f446e4-f676-4f1e-9c5e-f81336392738.png)

![2](https://user-images.githubusercontent.com/112477158/222987683-fe8d9ad8-0dc2-4cea-9e55-8177c868cfdf.png)

![3](https://user-images.githubusercontent.com/112477158/222987684-71511891-7c8c-48f8-bfe2-d7bc1e623659.png)

Player Movement
![Untitled video - Made with Clipchamp](https://user-images.githubusercontent.com/112477158/222987699-637ead9c-8488-4a53-a4e8-f4c86b08af7e.gif)
____________________________________________________________________________________________________________________________________________________
Tip
![Untitled video - Made with Clipchamp (1)](https://user-images.githubusercontent.com/112477158/222987706-71b4fd25-1df3-4207-b03b-855a62ccd0ed.gif)
____________________________________________________________________________________________________________________________________________________
Solve when goal is reachable
![Untitled video - Made with Clipchamp (2)](https://user-images.githubusercontent.com/112477158/222987717-928e40ba-f5fd-4a36-b971-4b9fde4df034.gif)
____________________________________________________________________________________________________________________________________________________
Overall
![Untitled video - Made with Clipchamp (5)](https://user-images.githubusercontent.com/112477158/222987983-6f18a493-4094-49b2-8b3e-5bdb171f3c6f.gif)

It will be uploaded on unity play.
