using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private int damage;
    private int range;
    private int cost;
    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDamage(int myDamage)
    {
        this.damage = myDamage;
    }

    public void SetRange(int myRange)
    {
        this.range = myRange;
    }
    public void SetCost(int myCost)
    {
        this.cost = myCost;
    }
    public void SetPosition(Vector3 myPosition)
    {
        this.position = myPosition;
        this.gameObject.transform.position = position;
    }
    public void SetVariables(int myDamage, int myRange, int myCost)
    {
        this.damage = myDamage;
        this.range = myRange;
        this.cost = myCost;
        this.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    }

    public int GetDamage()
    {
        return this.damage;
    }
    public int GetCost()
    {
        return this.cost;
    }
    public int GetRange()
    {
        return this.range;
    }
    public Vector3 GetPosition()
    {
        return this.position;
    }
}
