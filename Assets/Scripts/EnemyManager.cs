using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{

    private List<string> types = new List<string>() { "Grasshopper", "Bunny", "Wolf", "Bear", "Monkey" };
    private GameObject grasshopper;
    private GameObject bunny;
    private GameObject wolf;
    private GameObject bear;
    private GameObject monkey;
    private int timer = 0;
    private int startValue = 1000;
    private int timeInterval;
    private List<Tile> path;
    private int range = 1;
    int i = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        timeInterval = startValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (grasshopper && bunny && wolf && bear && monkey)
        {
            if (timer >= timeInterval)
            {
                if (timeInterval > 1)
                {
                    timeInterval -= 10;
                    if (timeInterval < 800 && range <= 4)
                    {
                        timeInterval = startValue;
                        range++;
                    }
                }
                timer = 0;
                SpawnEnemy(Random.Range(0,range+1));
            }
            timer++;
            /*
            if (i == 1)
            {
                GameObject copyEnemy = GameObject.Instantiate(grasshopper);
                copyEnemy.transform.position = new Vector3(0, 0, 0);
                copyEnemy.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                Enemy enemy = copyEnemy.AddComponent<Enemy>();
                enemy.setVariables(200, 20, 20, path);
                i++;
            }
            */
        }
    }

    private void SpawnEnemy(int type)
    {
        if (type == 0)
        {
            GameObject copyEnemy = GameObject.Instantiate(grasshopper);
            //GameObject copyEnemy = GameObject.Instantiate(GameObject.FindGameObjectWithTag("grassHopper"));
            Enemy enemy = copyEnemy.AddComponent<Enemy>();
            copyEnemy.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            enemy.setVariables(200,20,20,path);
        }
        else if (type == 1)
        {
            GameObject copyEnemy = GameObject.Instantiate(bunny);
            //GameObject copyEnemy = GameObject.Instantiate(GameObject.FindGameObjectWithTag("bunny"));
            Enemy enemy = copyEnemy.AddComponent<Enemy>();
            copyEnemy.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            enemy.setVariables(600, 60, 60, path);
        }
        else if (type == 2)
        {
            GameObject copyEnemy = GameObject.Instantiate(wolf);
            //GameObject copyEnemy = GameObject.Instantiate(GameObject.FindGameObjectWithTag("wolf"));
            Enemy enemy = copyEnemy.AddComponent<Enemy>();
            copyEnemy.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            enemy.setVariables(1600, 160, 160, path);
        }
        else if (type == 3)
        {
            GameObject copyEnemy = GameObject.Instantiate(bear);
            //GameObject copyEnemy = GameObject.Instantiate(GameObject.FindGameObjectWithTag("bear"));
            Enemy enemy = copyEnemy.AddComponent<Enemy>();
            copyEnemy.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            enemy.setVariables(2000, 200, 200, path);
        }
        else if (type == 4)
        {
            GameObject copyEnemy = GameObject.Instantiate(monkey);
            //GameObject copyEnemy = GameObject.Instantiate(GameObject.FindGameObjectWithTag("BigFoot"));
            Enemy enemy = copyEnemy.AddComponent<Enemy>();
            copyEnemy.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            enemy.setVariables(5000, 500, 500, path);
        }
    }

    public void SetPath(List<Tile> myPath)
    {
        path = myPath;
    }
    public void SetGrassHopper(GameObject myGrassHopper)
    {
        grasshopper = myGrassHopper;
    }
    public void SetBunny(GameObject myBunny)
    {
        bunny = myBunny;
    }
    public void SetWolf(GameObject myWolf)
    {
        wolf = myWolf;
    }
    public void SetBear(GameObject myBear)
    {
        bear = myBear;
    }
    public void SetMonkey(GameObject myMonkey)
    {
        monkey = myMonkey;
    }
}
