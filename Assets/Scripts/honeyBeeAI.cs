using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class honeyBeeAI : MonoBehaviour
{
    public GameObject checkpointParent;
    float step;
    int randomChild;
    void Start()
    {
        checkpointParent = GameObject.Find("checkpoints");
        step = 2 * Time.deltaTime;
        randomChild = Random.Range(0, 763);
    }

    void Update()
    {
        if (transform.position != checkpointParent.transform.GetChild(randomChild).position)
        {
            transform.position = Vector3.MoveTowards(transform.position, checkpointParent.transform.GetChild(randomChild).position, step);
            transform.LookAt(checkpointParent.transform.GetChild(randomChild));

        } else
            randomChild = Random.Range(0, 763);

    }
}