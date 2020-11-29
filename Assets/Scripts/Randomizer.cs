using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{

    //public static List<Vector2> pathInOrder;

    // Start is called before the first frame update
    void Start()
    {
        //Random.InitState(Mathf.FloorToInt(Time.time));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static List<int> CreateGrid(int n)
    {
        List<int> grid = new List<int>(n * n);
        while (grid.Count < n * n)
        {
            grid.Add(0);
        }
        return grid;
    }
    /*
    public static void ShowGrid(List<int> grid)
    {
        var n = Convert.ToInt16(Math.Sqrt(grid.Count));
        Console.WriteLine();
        foreach (int i in Enumerable.Range(0, grid.Count))
        {
            if (i % n != 0)
            {
                Console.Write(grid[i]);
            }
            else
            {
                Console.Write("\n" + grid[i]);
            }
        }
    }
    */
    public static List<int> CreateStart(List<int> grid)
    {
        var n = Mathf.FloorToInt(Mathf.Sqrt(grid.Count));
        int value = Random.Range(0, n);
        grid[n * value] = 1;
        var pos = new List<int> { 0, value };
        return pos;
    }
    public static List<int> CreateEnd(List<int> grid)
    {
        var n = Mathf.FloorToInt(Mathf.Sqrt(grid.Count));
        int val = Random.Range(0, n);
        int val2 = Random.Range(0, n);
        var endpos = new List<int> { n - 1, val2 };
        return endpos;
    }
    public static List<int> MoveUp(List<int> grid, List<int> pos, List<int> endpos)
    {
        var n = Mathf.FloorToInt(Mathf.Sqrt(grid.Count));
        for (int i = 0; i < 2; i++)
        {
            List<int> newpos = new List<int> { pos[0], pos[1] - 1 };
            if (PosInRange(grid, newpos) || ReachedEnd(pos, endpos))
            {
                grid[pos[0] + pos[1] * n] = 1;
                //pathInOrder.Add(new Vector2(newpos[0], newpos[1]));
                pos = newpos;
            }
            else
            {
                return pos;
            }
            return newpos;
        }
        return pos;
    }
    public static List<int> MoveDown(List<int> grid, List<int> pos, List<int> endpos)
    {
        var n = Mathf.FloorToInt(Mathf.Sqrt(grid.Count));
        for (int i = 0; i < 2; i++)
        {
            List<int> newpos = new List<int> { pos[0], pos[1] + 1 };
            if (PosInRange(grid, newpos) || ReachedEnd(pos, endpos))
            {
                grid[pos[0] + pos[1] * n] = 1;
                //pathInOrder.Add(new Vector2(newpos[0], newpos[1]));
                pos = newpos;
            }
            else
            {
                return pos;
            }
            return newpos;
        }
        return pos;
    }
    public static List<int> MoveLeft(List<int> grid, List<int> pos, List<int> endpos)
    {
        var n = Mathf.FloorToInt(Mathf.Sqrt(grid.Count));
        for (int i = 0; i < 2; i++)
        {
            List<int> newpos = new List<int> { pos[0] - 1, pos[1] };
            if (PosInRange(grid, newpos) || ReachedEnd(pos, endpos))
            {
                grid[pos[0] + pos[1] * n] = 1;
                //pathInOrder.Add(new Vector2(newpos[0], newpos[1]));
                pos = newpos;
            }
            else
            {
                return pos;
            }
            return newpos;
        }
        return pos;
    }
    public static List<int> MoveRight(List<int> grid, List<int> pos, List<int> endpos)
    {
        var n = Mathf.FloorToInt(Mathf.Sqrt(grid.Count));
        for (int i = 0; i < 2; i++)
        {
            List<int> newpos = new List<int> { pos[0] + 1, pos[1] };
            if (PosInRange(grid, newpos) || ReachedEnd(pos, endpos))
            {
                grid[pos[0] + pos[1] * n] = 1;
                //pathInOrder.Add(new Vector2(newpos[0], newpos[1]));
                pos = newpos;
            }
            else
            {
                return pos;
            }
            return newpos;
        }
        return pos;
    }
    public static bool PosInRange(List<int> grid, List<int> pos)
    {
        var n = Mathf.FloorToInt(Mathf.Sqrt(grid.Count));
        return 0 <= pos[0] && pos[0] < n && 0 <= pos[1] && pos[1] < n;
    }
    public static bool ReachedEnd(List<int> pos, List<int> endpos)
    {
        return endpos[0] == pos[0] && endpos[1] == pos[1];
    }
    public static List<int> Move(List<int> grid, List<int> pos, List<int> endpos)
    {
        int n = Mathf.FloorToInt(Mathf.Sqrt(grid.Count));
        List<int> movelist = IsOccupied(grid, pos);
        if (movelist == null)
        {
            return null;
        }
        else
        {
            int random_nb = Random.Range(0, movelist.Count);
            int random_move = movelist[random_nb];
            if (random_move == 1)
            {
                pos = MoveUp(grid, pos, endpos);
                pos = MoveUp(grid, pos, endpos);
            }
            else if (random_move == 2)
            {
                pos = MoveDown(grid, pos, endpos);
                pos = MoveDown(grid, pos, endpos);
            }
            else if (random_move == 3)
            {
                pos = MoveLeft(grid, pos, endpos);
                pos = MoveLeft(grid, pos, endpos);
            }
            else if (random_move == 4)
            {
                pos = MoveRight(grid, pos, endpos);
                pos = MoveRight(grid, pos, endpos);
            }
            return pos;
        }
    }
    public static List<int> IsOccupied(List<int> grid, List<int> pos)
    {
        var n = Mathf.FloorToInt(Mathf.Sqrt(grid.Count));
        List<int> templist = new List<int>();
        if (PosInRange(grid, new List<int> { pos[0], pos[1] - 1 }) && PosInRange(grid, new List<int> { pos[0], pos[1] - 2 }))
        {
            if (grid[pos[0] + (pos[1] - 1) * (n)] == 0 && grid[pos[0] + (pos[1] - 2) * (n)] == 0)
            {
                templist.Add(1);
            }
        }
        if (PosInRange(grid, new List<int> { pos[0], pos[1] + 1 }) && PosInRange(grid, new List<int> { pos[0], pos[1] + 2 }))
        {
            if (grid[pos[0] + (pos[1] + 1) * (n)] == 0 && grid[pos[0] + (pos[1] + 2) * (n)] == 0)
            {
                templist.Add(2);
            }
        }
        if (PosInRange(grid, new List<int> { pos[0] - 1, pos[1] }) && PosInRange(grid, new List<int> { pos[0] - 2, pos[1] }))
        {
            if (grid[pos[0] - 1 + pos[1] * (n)] == 0 && grid[pos[0] - 2 + pos[1] * (n)] == 0)
            {
                templist.Add(3);
            }
        }
        if (PosInRange(grid, new List<int> { pos[0] + 1, pos[1] }) && PosInRange(grid, new List<int> { pos[0] + 2, pos[1] }))
        {
            if (grid[pos[0] + 1 + pos[1] * (n)] == 0 && grid[pos[0] + 2 + pos[1] * (n)] == 0)
            {
                templist.Add(4);
            }
        }
        if (templist.Count == 0)
        {
            return null;
        }
        else
        {
            return templist;
        }
    }
    public static List<List<int>> MakePath(int n)
    {
        List<int> grid = CreateGrid(n);
        List<int> pos = CreateStart(grid);
        List<int> endpos = CreateEnd(grid);
        while (grid[endpos[0] + endpos[1] * n] == 0 && pos != null)
        {
            pos = Move(grid, pos, endpos);
            //ShowGrid(grid);
        }
        int sum = 0;
        foreach (int i in grid) sum += i;
        if (sum < n * 1.5)
        {
            pos = null;
        }
        if (pos == null)
        {
            List<int> test = new List<int>();
            List<List<int>> return_list = new List<List<int>> { test, pos, endpos };
            return return_list;
        }
        else
        {
            List<List<int>> return_list = new List<List<int>> { grid, pos, endpos };
            return return_list;
        }
    }
    public List<int> Brute(int n)
    {
        List<int> grid = new List<int>();
        List<List<int>> templist = new List<List<int>>();
        while (grid.Count == 0)
        {
            List<List<int>> path = MakePath(n);
            templist.Clear();
            templist.Add(path[0]);
            templist.Add(path[1]);
            templist.Add(path[2]);
            grid = templist[0];
        }
        List<int> listn = new List<int> { n };
        templist.Add(listn);
        return TestGrid(templist);
    }
    public static List<int> TestGrid(List<List<int>> templist)
    {
        List<int> grid = templist[0];
        List<int> pos = templist[1];
        List<int> endpos = templist[2];
        List<int> listn = templist[3];
        int n = listn[0];
        if (pos[0] < endpos[0])
        {
            grid[n - 2 + pos[1] * n] = 0;
        }
        else if (pos[1] < endpos[1])
        {
            if (endpos[1] - pos[1] == 2)
            {
                grid[n - 1 + (pos[1] + 1) * n] = 0;
            }
        }
        else if (pos[1] > endpos[1])
        {
            if (pos[1] - endpos[1] == 2)
            {
                grid[n - 1 + (pos[1] - 1) * n] = 0;
            }
        }
        return grid;
    }
}
