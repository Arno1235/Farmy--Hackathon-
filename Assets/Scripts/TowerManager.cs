using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    private List<string> types = new List<string>() { "Hunter Cabin", "ScareCrow", "Sprinkler", "Angry Farmer", "Grain Tower" };
    private GameObject hunterCabin;
    private GameObject scareCrow;
    private GameObject sprinkler;
    private GameObject angryFarmer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeTower(string type, Vector3 position)
    {
        Tower tower = new Tower();
        
        if (type == types[0])
        {
            //GameObject copyTower = GameObject.Instantiate(hunterCabin);
            GameObject copyTower = GameObject.Instantiate(GameObject.FindGameObjectWithTag("treeHouse"));
            tower = copyTower.AddComponent<Tower>();
            tower.SetVariables(10, 400, 4);

        }
        else if (type == types[1])
        {
            //GameObject copyTower = GameObject.Instantiate(scareCrow);
            GameObject copyTower = GameObject.Instantiate(GameObject.FindGameObjectWithTag("scareCrow"));
            tower = copyTower.AddComponent<Tower>();
            tower.SetVariables(50, 1000, 2);
        }
        else if (type == types[2])
        {
            //GameObject copyTower = GameObject.Instantiate(sprinkler);
            GameObject copyTower = GameObject.Instantiate(GameObject.FindGameObjectWithTag("hose"));
            tower = copyTower.AddComponent<Tower>();
            tower.SetVariables(40, 2000, 3);
        }
        else if (type == types[3])
        {
            //GameObject copyTower = GameObject.Instantiate(angryFarmer);
            GameObject copyTower = GameObject.Instantiate(GameObject.FindGameObjectWithTag("pitchFork"));
            tower = copyTower.AddComponent<Tower>();
            tower.SetVariables(300, 5000, 2);
        }

        tower.SetPosition(position*0.05f);
        SetTilesInRange(tower);

    }

    public void SetHunterCabin(GameObject myHunterCabin)
    {
        hunterCabin = myHunterCabin;
    }
    public void SetScareCrow(GameObject myScareCrow)
    {
        scareCrow = myScareCrow;
    }
    public void SetSprinkler(GameObject mySprinkler)
    {
        sprinkler = mySprinkler;
    }
    public void SetAngryFarmer(GameObject myAngryFarmer)
    {
        angryFarmer = myAngryFarmer;
    }

    public void SetTilesInRange(Tower tower)
    {
        int range = tower.GetRange();
        Vector3 vectorPosition = tower.GetPosition();
        List<int> position = new List<int>{ (int)vectorPosition.x, (int)vectorPosition.y, (int)vectorPosition.z };
        TileManager tileManager = FindObjectOfType<TileManager>();
        for (int y = 0; y < 11; y++)
        {
            for (int x = 0; x < 11; x++)
            {
                List<int> current_pos = new List<int>() { x, y };
                if (Distance(position, current_pos) <= range)
                {
                    tileManager.GetTile(x, y).AddTowerInRange(tower);
                }

            }
        }
    }
    public double Distance(List<int> pos1, List<int> pos2)
    {
        return Mathf.Sqrt(Mathf.Pow(pos1[0] - pos2[0], 2) + Mathf.Pow(pos1[1] - pos2[1], 2));
    }

}
