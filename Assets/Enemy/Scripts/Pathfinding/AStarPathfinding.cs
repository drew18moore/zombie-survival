using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPathfinding : MonoBehaviour
{
    public Transform seeker;
    Transform target;

    public int adjacentCost = 10;
    public int diagonalCost = 14;
    AStarGrid grid;

    [SerializeField] float maxSpeed = 8f;
    [SerializeField] Rigidbody2D rb;

    Quaternion targetRotation;
    Vector2 towards;
    Vector2 vel;

    private void Awake()
    {

        grid = GameObject.Find("AStar").GetComponent<AStarGrid>();
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        Node curr;
        FindPath(seeker.position, target.position);
        if (grid.path.TryPop(out curr))
        {
            towards = (Vector2)curr.worldPosition - (Vector2)seeker.position;
            seeker.position = Vector2.MoveTowards(seeker.position, curr.worldPosition, maxSpeed * Time.deltaTime);
        }
    }

    void FindPath(Vector2 startPos, Vector2 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        Heap<Node> openList = new Heap<Node>(grid.MaxSize);
        HashSet<Node> closedList = new HashSet<Node>();

        openList.Add(startNode);

        while (openList.Count > 0)
        {
            Node currentNode = openList.RemoveFirst();
            closedList.Add(currentNode);

            if (currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (Node neighbor in grid.GetNeighbours(currentNode))
            {
                if (!neighbor.walkable || closedList.Contains(neighbor))
                {
                    continue;
                }

                int newMovementCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);
                if (newMovementCostToNeighbor < neighbor.gCost || !openList.Contains(neighbor))
                {
                    neighbor.gCost = newMovementCostToNeighbor;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    if (!openList.Contains(neighbor))
                    {
                        openList.Add(neighbor);
                    }
                }

            }
        }
    }

    void RetracePath(Node start, Node target)
    {
        Stack<Node> path = new Stack<Node>();
        Node currentNode = target;

        while (currentNode != start)
        {
            path.Push(currentNode);
            currentNode = currentNode.parent;
        }
        grid.path = path;
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int disX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int disY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (disX > disY)
            return diagonalCost * disY + adjacentCost * (disX - disY);
        return diagonalCost * disX + adjacentCost * (disY - disX);
    }
}
