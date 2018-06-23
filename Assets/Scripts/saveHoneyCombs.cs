using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class saveHoneyCombs : MonoBehaviour
{
    GameObject[] getCountOfCombs;
    GameObject[] getCountOfFilledCombs;
    GameObject[] GameObjectsToRestore;

    public GameObject hexagon;
    public GameObject filledHoneyComb;
    
    // Is called before Start
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getCountOfCombs = GameObject.FindGameObjectsWithTag("honeyComb");
        getCountOfFilledCombs = GameObject.FindGameObjectsWithTag("filledHoneyComb");

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
        FileStream file = File.Create(Application.persistentDataPath + "/honeycomb.bee");
        hexagonObject hb = new hexagonObject(getCountOfCombs.Length);

        Debug.Log(getCountOfCombs.Length);
        for (int i = 0; i < getCountOfCombs.Length; i++)
        {
            hb.pos[i, 0] = getCountOfCombs[i].transform.localPosition.x;
            hb.pos[i, 1] = getCountOfCombs[i].transform.localPosition.y;
            hb.pos[i, 2] = getCountOfCombs[i].transform.localPosition.z;
        }

        for (int i = 0; i < getCountOfCombs.Length; i++)
        {
            hb.hexaRotations[i, 0] = getCountOfCombs[i].transform.rotation.x;
            hb.hexaRotations[i, 1] = getCountOfCombs[i].transform.rotation.y;
            hb.hexaRotations[i, 2] = getCountOfCombs[i].transform.rotation.z;
            hb.hexaRotations[i, 3] = getCountOfCombs[i].transform.rotation.w;
        }


        bf.Serialize(file, hb);
        file.Close();
        Debug.Log("Saved!");

        //Handels the saving for honeycombs filled with honey

        BinaryFormatter bformatter = new BinaryFormatter();
        FileStream saveFile = File.Create(Application.persistentDataPath + "/data.bee");
        filledHoneycomb fh = new filledHoneycomb(getCountOfFilledCombs.Length);

        for (int i = 0; i < getCountOfFilledCombs.Length; i++)
        {
            fh.pos[i, 0] = getCountOfFilledCombs[i].transform.localPosition.x;
            fh.pos[i, 1] = getCountOfFilledCombs[i].transform.localPosition.y;
            fh.pos[i, 2] = getCountOfFilledCombs[i].transform.localPosition.z;
        }

        for (int i = 0; i < getCountOfFilledCombs.Length; i++)
        {
            fh.hexaRotations[i, 0] = getCountOfFilledCombs[i].transform.rotation.x;
            fh.hexaRotations[i, 1] = getCountOfFilledCombs[i].transform.rotation.y;
            fh.hexaRotations[i, 2] = getCountOfFilledCombs[i].transform.rotation.z;
            fh.hexaRotations[i, 3] = getCountOfFilledCombs[i].transform.rotation.w;
        }


        bformatter.Serialize(saveFile, fh);
        saveFile.Close();
        Debug.Log("Saved!");

    }

    public void load()
    {
        if(File.Exists(Application.persistentDataPath + "/honeycomb.bee"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/honeycomb.bee", FileMode.Open);
            hexagonObject hb = (hexagonObject)bf.Deserialize(file);
            file.Close();

            Quaternion rotationOfCombs = new Quaternion();
            for (int i = 0; i < hb.pos.GetLength(0); i++)
            {
                rotationOfCombs.Set(hb.hexaRotations[i, 0], hb.hexaRotations[i, 1], hb.hexaRotations[i, 2], hb.hexaRotations[i, 3]);
                Instantiate(hexagon, new Vector3(hb.pos[i, 0], hb.pos[i, 1], hb.pos[i, 2]), rotationOfCombs);
                Debug.Log("pos: " + i.ToString() + ": " + new Vector3(hb.pos[i, 0], hb.pos[i, 1], hb.pos[i, 2]));
            }

        }// Debug.Log("No data found! Try saving first.");


        //Handels the loading for honeycombs filled with honey
        if (File.Exists(Application.persistentDataPath + "/data.bee"))
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            FileStream saveFile = File.Open(Application.persistentDataPath + "/data.bee", FileMode.Open);
            filledHoneycomb fh = (filledHoneycomb) bformatter.Deserialize(saveFile);
            saveFile.Close();

            Quaternion rotationOfCombs = new Quaternion();
            for (int i = 0; i < fh.pos.GetLength(0); i++)
            {
                rotationOfCombs.Set(fh.hexaRotations[i, 0], fh.hexaRotations[i, 1], fh.hexaRotations[i, 2], fh.hexaRotations[i, 3]);
                Instantiate(filledHoneyComb, new Vector3(fh.pos[i, 0], fh.pos[i, 1], fh.pos[i, 2]), rotationOfCombs);
                Debug.Log("Filled pos: " + i.ToString() + ": " + new Vector3(fh.pos[i, 0], fh.pos[i, 1], fh.pos[i, 2]));
            }

        }
       // Debug.Log("No data found! Try saving first.");

    }

}
[Serializable]
class hexagonObject {
    //Own invented vector3 that is (probably) Serializable
    public float[,] pos;

    //Own invented Quaternion that is (probably) Serializable
    public float[,] hexaRotations;

    public hexagonObject(int totalObj)
    {
        hexaRotations = new float[totalObj, 4];
        pos = new float[totalObj, 3];
    }
}

[Serializable]
class filledHoneycomb
{
    //Own invented vector3 that is (probably) Serializable
    public float[,] pos;

    //Own invented Quaternion that is (probably) Serializable
    public float[,] hexaRotations;

    public filledHoneycomb(int totalObj)
    {
        hexaRotations = new float[totalObj, 4];
        pos = new float[totalObj, 3];
    }
}
