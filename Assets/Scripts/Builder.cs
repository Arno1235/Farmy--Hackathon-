using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{

    private GameObject pointer;
    private GameObject phoneCamera;
    private bool pointerVisibility;
    private TowerManager towerManager;
    private List<string> types = new List<string>() { "Hunter Cabin", "ScareCrow", "Sprinkler", "Angry Farmer", "Grain Tower" };

    // Start is called before the first frame update
    void Start()
    {
        pointer.transform.localScale = new Vector3(3, 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(phoneCamera.transform.position, phoneCamera.transform.TransformDirection(Vector3.forward), out hit))
        {
            
                //pointer.GetComponent<UnityEngine.UI.Text>().text = "not touch";
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    //pointer.GetComponent<UnityEngine.UI.Text>().text = "touch";
                    GameObject baseTile = hit.collider.gameObject;
                    Tile baseTileScript = baseTile.GetComponent<Tile>();
                    if (!baseTileScript.GetPlacability())
                    {
                        //pointer.GetComponent<UnityEngine.UI.Text>().text = "placable";
                        baseTileScript.SetOccupation(true);
                        float rand = Random.Range(0, 5);
                        towerManager.MakeTower(types[0], baseTileScript.GetPosition());
                    }
                
            }
        }
    }

    public void SetVar(GameObject myPointer, GameObject myPhoneCamera)
    {
        pointer = myPointer;
        phoneCamera = myPhoneCamera;
    }
    public void SetTowerManager(TowerManager myTowerManager)
    {
        towerManager = myTowerManager;
    }
    
}
