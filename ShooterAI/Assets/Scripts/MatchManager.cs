using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public GameObject prefabAgent;
    public List<int> architecture;
    public Genome genomeAgent1;
    private GameObject agent1;
    // Start is called before the first frame update
    void Start()
    {
        agent1 = GameObject.Instantiate(prefabAgent, Vector3.zero, Quaternion.identity);
        agent1.transform.position = this.transform.position + new Vector3(0f, .5f, 0f);
        agent1.GetComponent<AgentManager>().network = new RecurentNet(genomeAgent1.Parameters, architecture, tanh);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float getFitness()
    {
        return 0f;
    }

    private float tanh(float x)
    {
        return (Mathf.Exp(x) - Mathf.Exp(-x)) / (Mathf.Exp(x) + Mathf.Exp(-x));
    }
}