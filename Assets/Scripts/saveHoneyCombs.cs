using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class saveHoneyCombs : MonoBehaviour
{
    GameObject[] getCountOfCombs;

    GameObject[] GameObjectsToRestore;
    public GameObject hexagon;
    // Use this for initialization
    void Start()
    {
        
        //Instantiate(hexagon, transform.position + (transform.forward * 1.2f) + transform.up * 0.6f, hexagon.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        getCountOfCombs = GameObject.FindGameObjectsWithTag("honeyComb");
        Debug.Log("transform.rotation: " + getCountOfCombs[0].transform.rotation);


        //Debug.Log("n1: " + getCountOfCombs[0].transform.localPosition);
        //Debug.Log("getCountOfCombs.Length: " + getCountOfCombs.Length);
        if (Input.GetKeyUp(KeyCode.U))
        {
            save();
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            load();
        }

    }

    public void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/worldObjects.bee");
        hexagonObject hb = new hexagonObject(getCountOfCombs.Length);

        //hb.totalNumbers = getCountOfCombs.Length;

        for (int i = 0; i < getCountOfCombs.Length; i++)
        {
            hb.pos[i, 0] = getCountOfCombs[i].transform.localPosition.x;
            hb.pos[i, 1] = getCountOfCombs[i].transform.localPosition.y;
            hb.pos[i, 2] = getCountOfCombs[i].transform.localPosition.z;
        }

        bf.Serialize(file, hb);
        file.Close();
        Debug.Log("Saved!");
    }

    public void load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/worldObjects.bee", FileMode.Open);
        hexagonObject hb = (hexagonObject) bf.Deserialize(file);
        file.Close();

        Debug.Log("hb.pos.Length/3: " + hb.pos.GetLength(0));
        for (int i = 0; i < hb.pos.GetLength(0); i++)
        {
            Instantiate(hexagon, new Vector3(hb.pos[i,0], hb.pos[i, 1], hb.pos[i, 2]), hexagon.transform.rotation);

        }
        /* GameObjectsToRestore = new GameObject[hb.hexaPos.Length];

         for (int i = 0; i < GameObjectsToRestore.Length; i++){
             GameObjectsToRestore[i].transform.position = hb.hexaPos[i];
         }


         for (int i = 0; i < GameObjectsToRestore.Length; i++)
         {
             Instantiate(hexagon, GameObjectsToRestore[i].transform.position, hexagon.transform.rotation);

         }*/
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 50, 50), "Save"))
            save();
    }

}
[Serializable]
class hexagonObject {

    //public int totalNumbers;
    public Vector3[] hexaPos;
    
    //Own invented vector3 that is (probably) Serializable
    public float[,] pos;

    //Own invented Quaternion that is (probably) Serializable
    public Quaternion[] hexaRotations;

    public hexagonObject(int totalObj)
    {
        //hexaPos = new Vector3[totalObj];
        hexaRotations = new Quaternion[totalObj];
        pos = new float[totalObj, 3];
        

    }

}

