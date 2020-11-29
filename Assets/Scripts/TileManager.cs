using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    private Vector2 size;
    private GameObject roadObject;
    private GameObject grassObject;
    private List<Tile> tiles;
    private List<Tile> tilePath;
    private List<int> primitiveTiles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupRoad()
    {
        tilePath = new List<Tile>();
        for (int index = 0; index < size.x * size.y; index++)
        {
            if (primitiveTiles[index] == 1)
            {

                GameObject copyRoad = GameObject.Instantiate(GameObject.FindGameObjectWithTag("tile"));
                copyRoad.SetActive(true);
                Tile newTile = copyRoad.AddComponent<Tile>();
                newTile.SetVars(Mathf.FloorToInt(index % size.x), 0, Mathf.FloorToInt(index / size.x), false, primitiveTiles[index] == 1);
                tiles[index] = newTile;
                tilePath.Add(newTile);

                //tilePath.Add(null);

            }
        }
            /*tilePath[0]=tiles[0];
            tilePath[1] = (tiles[1]);
            tilePath[2] = (tiles[2]);
            tilePath[3] = (tiles[3]);
            tilePath[4] = (tiles[4]);
            tilePath[5] = tiles[5];
        tilePath[6] = (tiles[6]);

        tilePath[7] = tiles[7];



        tilePath[8] = tiles[14];
        tilePath[9] = tiles[13];
        tilePath[10] = tiles[12];
        tilePath[11] = tiles[11];
        tilePath[12] = tiles[10];
        tilePath[13] = tiles[9];
        tilePath[14] = tiles[8];
        tilePath[15] = tiles[16];
        tilePath[16] = tiles[18];
        tilePath[17] = tiles[19];
        tilePath[18] = tiles[20];
        tilePath[19] = tiles[21];
        tilePath[20] = tiles[22];
        tilePath[21] = tiles[23];
        tilePath[22] = tiles[24];
        tilePath[23] = tiles[25];
        tilePath[24] = tiles[26];
        tilePath[25] = tiles[27];
        tilePath[26] = tiles[28];
        tilePath[27] = tiles[17];
        tilePath[28] = tiles[15];*/



            /*
            tilePath[8] = tiles[14];
            tilePath[9] = tiles[13];
            tilePath[10] = tiles[12];
            tilePath[11] = tiles[11];
            tilePath[12] = tiles[10];
            tilePath[13] = tiles[9];
            tilePath[14] = tiles[8];
            */
        
    }
    public void SetupGrass()
    {
        for (int index = 0; index < size.x * size.y; index++)
        {
        
            if (primitiveTiles[index] == 0)
            {
                //GameObject copyGrass = new GameObject();
                GameObject copyGrass = GameObject.Instantiate(GameObject.FindGameObjectWithTag("grassTile"));
                Tile newTile = copyGrass.AddComponent<Tile>();
                newTile.SetVars(Mathf.FloorToInt(index % size.x),  0, Mathf.FloorToInt(index / size.x), false, primitiveTiles[index] == 1);
                tiles[index] = newTile;
            }
        }
    }

    public Vector2 GetSize()
    {
        return size;
    }
    public Tile GetTile(int x, int y)
    {
        return tiles[Mathf.FloorToInt(y*size.x + x)];
    }
    public List<Tile> GetTiles()
    {
        return tiles;
    }

    public void SetSize(Vector2 mySize)
    {
        size = mySize;
        tiles = new List<Tile>();
        for (int i = 0; i < size.x * size.y; i++) tiles.Add(null);
    }   
    public void SetRoadObject(GameObject myRoadObject)
    {
       roadObject = myRoadObject;
    }
    public void SetGrassObject(GameObject myGrassObject)
    {
        grassObject = myGrassObject;
    }
    public void SetPrimitiveTiles(List<int> myPrimitiveTiles)
    {
        primitiveTiles = myPrimitiveTiles;
    }
    public List<Tile> getTilePath()
    {
        return tilePath;
    }
    
}
