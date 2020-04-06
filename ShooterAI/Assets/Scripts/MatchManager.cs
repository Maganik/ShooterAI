using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public GameObject prefabAgent;
    public List<int> architecture;
    public Genome genomeAgent1;
    public Genome genomeAgent2;
    public Genome genomeAgent3;
    public Genome genomeAgent4;
    private GameObject agent1;
    private GameObject agent2;
    private GameObject agent3;
    private GameObject agent4;
    // Start is called before the first frame update
    void Start()
    {
        agent1 = GameObject.Instantiate(prefabAgent, new Vector3(2,2), Quaternion.identity);
        agent1.transform.position = this.transform.position + new Vector3(0f, .5f, 0f) + new Vector3(2, 0, 2);
        agent1.transform.parent = this.transform;
        agent1.GetComponent<AgentManager>().network = new RecurentNet(genomeAgent1.Parameters, architecture, sigmoid);
        agent1.GetComponent<AgentManager>().team = 1;

        agent2 = GameObject.Instantiate(prefabAgent, new Vector3(-2, 2), Quaternion.identity);
        agent2.transform.position = this.transform.position + new Vector3(0f, .5f, 0f) + new Vector3(-2, 0, 2);
        agent2.transform.parent = this.transform;
        agent2.GetComponent<AgentManager>().network = new RecurentNet(genomeAgent2.Parameters, architecture, sigmoid);
        agent2.GetComponent<AgentManager>().team = 1;

        agent3 = GameObject.Instantiate(prefabAgent, new Vector3(3, -3), Quaternion.identity);
        agent3.transform.position = this.transform.position + new Vector3(0f, .5f, 0f) + new Vector3(3,0, -3);
        agent3.transform.parent = this.transform;
        agent3.GetComponent<AgentManager>().network = new RecurentNet(genomeAgent3.Parameters, architecture, sigmoid);
        agent3.GetComponent<AgentManager>().team = 2;

        agent4 = GameObject.Instantiate(prefabAgent, new Vector3(-3, -3), Quaternion.identity);
        agent4.transform.position = this.transform.position + new Vector3(0f, .5f, 0f) + new Vector3(-3,0, -3);
        agent4.transform.parent = this.transform;
        agent4.GetComponent<AgentManager>().network = new RecurentNet(genomeAgent4.Parameters, architecture, sigmoid);
        agent4.GetComponent<AgentManager>().team = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<float> getFitness()
    {
        List<float> fitness = new List<float>();
        fitness.Add(agent1.GetComponent<AgentManager>().getFitness());
        fitness.Add(agent2.GetComponent<AgentManager>().getFitness());
        fitness.Add(agent3.GetComponent<AgentManager>().getFitness());
        fitness.Add(agent4.GetComponent<AgentManager>().getFitness());
        return fitness;
    }

    public float tanh(float x)
    {
        return (Mathf.Exp(x) - Mathf.Exp(-x)) / (Mathf.Exp(x) + Mathf.Exp(-x));
    }
    public float sigmoid(float x)
    {
        return 1 / (1 + Mathf.Exp(-x));
    }
}