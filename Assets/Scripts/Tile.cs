using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private int positionX;
    private int positionY;
    private int positionZ;
    private bool occupied;
    private bool road;
    private float size;
    private List<Tower> towersInRange;

    // Start is called before the first frame update
    void Start()
    {
        towersInRange = new List<Tower>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVars(int myPositionX, int myPositionY, int myPositionZ, bool myOccupation, bool myRoad)
    {
        
        size = 0.05f;
        positionX = myPositionX;
        positionY = myPositionY;
        positionZ = myPositionZ;
        occupied = myOccupation;
        road = myRoad;
        this.gameObject.transform.position = new Vector3(positionX*size, 0, positionZ*size);        
        this.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        this.gameObject.isStatic = true;
        this.gameObject.layer = 20;
    }
    public void SetOccupation(bool myOccupation)
    {
        occupied = myOccupation;
    }
    public void AddTowerInRange(Tower newTower)
    {
        towersInRange.Add(newTower);
    }

    public Vector3 GetPosition()
    {
        return new Vector3(positionX, positionY, positionZ);
    }
    public bool GetPlacability()
    {
        return occupied || road;
    }
    public bool GetRoad()
    {
        return road;
    }
    public int GetDamage()
    {
        int damage = 0;
        foreach (Tower tower in towersInRange) damage += tower.GetDamage();
        return damage;
    }
}

