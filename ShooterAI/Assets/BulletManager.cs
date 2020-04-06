using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public GameObject emitingAgent;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject != emitingAgent)
        {
            if (collision.gameObject.tag == "Agent" && collision.gameObject.GetComponent<AgentManager>().team == emitingAgent.GetComponent<AgentManager>().team)
                emitingAgent.GetComponent<AgentManager>().addFitness(-10f);
            else if (collision.gameObject.tag == "Agent" && collision.gameObject.GetComponent<AgentManager>().team != emitingAgent.GetComponent<AgentManager>().team)
                emitingAgent.GetComponent<AgentManager>().addFitness(10f);
            Destroy(gameObject);
        }
        
            
    }
}
