using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class honeyBeeAI : MonoBehaviour
{
    public GameObject checkpointParent;
    float step;
    public static float speed = 2.5f;
    int randomChild;
    void Start()
    {
        checkpointParent = GameObject.Find("checkpoints");
        randomChild = Random.Range(0, 763);
    }

    void Update()
    {
        step = speed * Time.deltaTime;

        if (transform.position != checkpointParent.transform.GetChild(randomChild).position)
        {
            transform.position = Vector3.MoveTowards(transform.position, checkpointParent.transform.GetChild(randomChild).position, step);
            transform.LookAt(checkpointParent.transform.GetChild(randomChild));

        } else
            randomChild = Random.Range(0, 763);

    }
}