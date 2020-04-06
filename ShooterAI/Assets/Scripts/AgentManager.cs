using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{
    public RecurentNet network;
    public float reactionSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        network.feedForward(getInputs());
        if(network.Output[0] > 0.5)
        {
            moveForward(3f);
        }
    }

    private void moveForward(float speed)
    {
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }

    private void rotate(bool rotWay, float rotSpeed)
    {

    }

    private List<float> getInputs()
    {
        List<float> sensors = new List<float>();
        Vector3 pos = this.gameObject.transform.position;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            sensors.Add(1 - (hit.distance / 10f));
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            sensors.Add(0f);
        }
        return sensors;
    }



}