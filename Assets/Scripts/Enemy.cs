using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private int health;
    private int damage;
    private int loot;
    private int index = 0;
    private List<Tile> path;
    public Vector3 endPos = new Vector3(0,0,0);
    private Vector3 movement = new Vector3(0,0,0);
    private Vector3 rotation;
    private bool run = false;
    private float size = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            if ((this.gameObject.transform.position - endPos).magnitude > size/16)
            {
                this.gameObject.transform.position += movement * Time.deltaTime;
            }
            else
            {
                if (index == path.Count)
                {
                    GameObject.FindObjectOfType<Player>().SubstractHealth(damage);
                    Destroy(this.gameObject);
                }
                health -= path[index].GetDamage();
                if (health <= 0)
                {
                    GameObject.FindObjectOfType<Player>().AddLoot(loot);
                    Destroy(this.gameObject);
                }
                index++;
                endPos = path[index].GetPosition()*size;
                movement = (endPos - this.gameObject.transform.position);
                Debug.Log(movement);
                /*
                if (movement.x < 0)
                {
                    this.gameObject.transform.Rotate(new Vector3(0, 90, 0));

                }
                else if (movement.x > 0)
                {

                    this.gameObject.transform.Rotate(new Vector3(0, 270, 0));

                }
                else if (movement.z > 0)
                {
                    this.gameObject.transform.Rotate(new Vector3(0, 0, 0));
                }
                else
                {
                    this.gameObject.transform.Rotate(new Vector3(0, 180, 0));
                }
                */

            }
        }

    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetLoot()
    {
        return loot;
    }

    public void setVariables(int myHealth, int myDamage, int myLoot, List<Tile> myPath)
    {
        health = myHealth;
        damage = myDamage;
        loot = myLoot;
        path = myPath;
        index = 0;
        this.gameObject.transform.position = path[index].GetPosition() * size;
        endPos = path[index + 1].GetPosition()*size;
        index++;
        movement = (endPos - this.gameObject.transform.position);
        run = true;
    }
    private void SetHealth(int myHealth)
    {
        health = myHealth;
    }

    private void SetDamage(int myDamage)
    {
        damage = myDamage;
    }

    private void SetLoot(int myLoot)
    {
        loot = myLoot;
    }
    public void SetPath(List<Tile> myPath)
    {
        path = myPath;
    }

}
