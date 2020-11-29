using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    private TileManager tileManager;
    private TowerManager towerManager;
    private EnemyManager enemyManager;
    private Builder builder;
    public GameObject pointer;
    public GameObject phoneCamera;
    private Vector2 size;
    
    // Start is called before the first frame update
    void Start()
    {
        size = new Vector2(11, 11);

        /*
        List<bool> testWorld = new List<bool> {
        true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true,
        true, true, true, true, true, true, true, true, true, true, true,  };
        */
        
        Random.InitState(Mathf.FloorToInt(Time.time));
        Randomizer randomizer = new Randomizer();
        List<int> pathList = new List<int>();
        pathList = randomizer.Brute(11);
        //List<Vector2> pathInOrder = randomizer.GetPath();

        //PlaceOnPlane placeOnPlane = new PlaceOnPlane();

        tileManager = gameObject.AddComponent<TileManager>();
        tileManager.SetSize(size);
        tileManager.SetPrimitiveTiles(pathList);
        tileManager.SetupRoad();
        tileManager.SetupGrass();

        towerManager = gameObject.AddComponent<TowerManager>();


        enemyManager = gameObject.AddComponent<EnemyManager>();
        enemyManager.SetPath(tileManager.getTilePath());
        //enemyManager.SetPath(pathInOrder);

        enemyManager.SetMonkey(GameObject.FindGameObjectWithTag("BigFoot"));
        enemyManager.SetBear(GameObject.FindGameObjectWithTag("Bear"));
        enemyManager.SetWolf(GameObject.FindGameObjectWithTag("wolf"));
        enemyManager.SetBunny(GameObject.FindGameObjectWithTag("bunny"));
        enemyManager.SetGrassHopper(GameObject.FindGameObjectWithTag("grassHopper"));

        builder = gameObject.AddComponent<Builder>();
        builder.SetVar(pointer, phoneCamera);
        builder.SetTowerManager(towerManager);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Tile> GetTiles()
    {
        return tileManager.GetTiles();
    }
}
