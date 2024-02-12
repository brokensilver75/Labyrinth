using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class DungeonGenerator : MonoBehaviour
{
    //Navmesh
    public NavMeshSurface navMeshPlane;
    //Player
    //public GameObject player;
    //Reference to Cell Prefab
    public GameObject[] roomPrefab;
    //Class for Each Cell
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4]; // 0 - Up 1 -Down 2 - Right 3- Left
    }

    //THE DUNGEON or GRID or FLOOR
    //Size of Grid
    public Vector2 size;

    //New Room
    RoomBehaviour newRoom;

    //Distance between rooms
    public Vector2 offset;

    public int startPos = 0;

    //Cell currently visited or Cell we are currently in
    int currentRoom = 0;

    Stack<int> path = new Stack<int>();
    
    //Grid Iterator
    int k = 0;

    //Visited Cells Iterator
    int visitedCount = 0;

    //Loop iterator
    int gridCount = 0;

    //List of neighbors
    List<int> neighbors;
    //New Cell
    int newCell;

    //Current Cell to instantiate room
    Cell currentCell;

    //Total Grid containing all the rooms
    List<Cell> grid;

    List<Cell> visitedCells;

    // Start is called before the first frame update
    void Start()
    {
        //roomPrefab = new GameObject[2];
        Mazegenerator();
        navMeshPlane.BuildNavMesh();
        Debug.Log(visitedCount);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateDungeon()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                currentCell = grid[Mathf.FloorToInt(i + j * size.x)];
                
                if (currentCell.visited)
                {
                    if (gridCount == visitedCount)
                    {
                        newRoom = Instantiate(roomPrefab[1], new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehaviour>();

                        newRoom.UpdateRoom(currentCell.status);

                        newRoom.name += " " + i + "-" + j;

                        break;
                    }
                    newRoom = Instantiate(roomPrefab[0], new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehaviour>();
                    
                    newRoom.UpdateRoom(currentCell.status);

                    newRoom.name += " " + i + "-" + j;
                    gridCount++;
                    Debug.Log(gridCount);
                }
                
            }
        }
    }

    void Mazegenerator()
    {
        //Initialize the grid
        grid = new List<Cell>();
        visitedCells = new List<Cell>();

        //One Cell, one cell in the grid
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                grid.Add(new Cell());
            }
        }

        k = 0;

        while (k < 1000)
        {
            //Moving Through the grid
            k++;

            grid[currentRoom].visited = true;
            //visitedCells[visitedCount] = grid[currentRoom];
            
            


            if (currentRoom == grid.Count - 1)
            {
                break;
            }

            //Check the Cell's neighbors
            neighbors = CheckNeighbors(currentRoom);

            if (neighbors.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }

                else
                {
                    currentRoom = path.Pop();
                }
            }

            else
            {
                path.Push(currentRoom);
                visitedCount++;
                newCell = neighbors[Random.Range(0, neighbors.Count)];

                //down or right
                if (newCell > currentRoom)  //if newCell is 1 or 3
                {
                    //NewRoom to the RIGHT
                    if (newCell - 1 == currentRoom)
                    {
                        grid[currentRoom].status[2] = true;
                        currentRoom = newCell;
                        grid[currentRoom].status[3] = true;
                    }
                    else //NewRoom BELOW (or DOWN)
                    {
                        grid[currentRoom].status[1] = true;
                        currentRoom = newCell;
                        grid[currentRoom].status[0] = true;
                    }
                }
                //up or left (newCell is 0 or 2)
                else
                {
                    //NewRoom to the LEFT
                    if (newCell + 1 == currentRoom)
                    {
                        grid[currentRoom].status[3] = true;
                        currentRoom = newCell;
                        grid[currentRoom].status[2] = true;
                    }
                    else //NewRoom ABOVE (or UP)
                    {
                        grid[currentRoom].status[0] = true;
                        currentRoom = newCell;
                        grid[currentRoom].status[1] = true;
                    }
                }
            }
        }

        GenerateDungeon();
    }

    //Return List of neighbors (0 - up, 1 - down, 2 - right, 3 - left)
    List<int> CheckNeighbors(int Cell)
    {
        neighbors = new List<int>();

        //check up neighbor
        if (Cell - size.x >= 0 && !grid[Mathf.FloorToInt(Cell - size.x)].visited)   //Check if at top row or not
        {
            neighbors.Add(Mathf.FloorToInt(Cell - size.x));
        }

        //check down neighbor
        if (Cell + size.x < grid.Count && !grid[Mathf.FloorToInt(Cell + size.x)].visited)   //Check if at bottom row or not
        {
            neighbors.Add(Mathf.FloorToInt(Cell + size.x));
        }

        //check right neighbor
        //Check if at rightmost column or not {as (Cell + 1) % size.x will be 0 at rightmost column as it will be size.x - 1}
        if ((Cell + 1) % size.x != 0 && !grid[Mathf.FloorToInt(Cell + 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(Cell + 1));
        }

        //check left neighbor
        //Check if at rightmost column or not {as (Cell % size.x will be 0 at leftmost column as it will be 0}
        if (Cell % size.x != 0 && !grid[Mathf.FloorToInt(Cell - 1)].visited) //Check if at leftmost column or not
        {
            neighbors.Add(Mathf.FloorToInt(Cell - 1));
        }

        return neighbors;
    }
}

