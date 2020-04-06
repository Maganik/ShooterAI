using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingManager : MonoBehaviour
{
    public GameObject prefab;
    public int population;
    public float simulationTime;
    public List<int> architecture;
    private Generation generation;
    private List<GameObject> simulations;
    private float remainingTime;
    public int nbGeneration = 1;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = simulationTime;
        simulations = new List<GameObject>();
        generation = new Generation(population, RecurentNet.getNbWeightForArchi(architecture));
        for (int i = 0; i < population; i++)
        {
            simulations.Add(GameObject.Instantiate(prefab, new Vector3(12 * i, 0), Quaternion.Euler(90, 0, 0)));
            simulations[i].GetComponent<MatchManager>().genomeAgent1 = generation[i];
            simulations[i].GetComponent<MatchManager>().architecture = architecture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        if (remainingTime < 0f)
        {
            nextSimulationRound();
            remainingTime = simulationTime;
        }
    }

    public void nextSimulationRound()
    {

        List<float> fitness = new List<float>();
        foreach (GameObject gameObject in simulations)
        {
            fitness.Add(gameObject.GetComponent<MatchManager>().getFitness());
            Destroy(gameObject);
        }
        simulations = new List<GameObject>();
        generation.Fitness = fitness;
        generation.nextGen();
        for (int i = 0; i < population; i++)
        {
            simulations.Add(GameObject.Instantiate(prefab, new Vector3(12 * i, 0), Quaternion.Euler(90, 0, 0)));
            simulations[i].GetComponent<MatchManager>().genomeAgent1 = generation[i];
        }
        nbGeneration++;
    }
}