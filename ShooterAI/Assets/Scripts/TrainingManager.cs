using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TrainingManager : MonoBehaviour
{
    public GameObject prefab;
    public int population;
    public float simulationTime;
    public List<int> architecture;
    private Generation generationAgent1;
    private Generation generationAgent2;
    private Generation generationAgent3;
    private Generation generationAgent4;
    private List<GameObject> simulations;
    private float remainingTime;
    public int nbGeneration = 1;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = simulationTime;
        simulations = new List<GameObject>();
        generationAgent1 = new Generation(population, RecurentNet.getNbWeightForArchi(architecture));
        generationAgent2 = new Generation(population, RecurentNet.getNbWeightForArchi(architecture));
        generationAgent3 = new Generation(population, RecurentNet.getNbWeightForArchi(architecture));
        generationAgent4 = new Generation(population, RecurentNet.getNbWeightForArchi(architecture));
        for (int i = 0; i < population; i++)
        {
            simulations.Add(GameObject.Instantiate(prefab, new Vector3(12 * i, 0), Quaternion.Euler(90, 0, 0)));
            simulations[i].GetComponent<MatchManager>().genomeAgent1 = generationAgent1[i];
            simulations[i].GetComponent<MatchManager>().genomeAgent2 = generationAgent2[i];
            simulations[i].GetComponent<MatchManager>().genomeAgent3 = generationAgent3[i];
            simulations[i].GetComponent<MatchManager>().genomeAgent4 = generationAgent4[i];
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

        List<float> fitnessAgent1 = new List<float>();
        List<float> fitnessAgent2 = new List<float>();
        List<float> fitnessAgent3 = new List<float>();
        List<float> fitnessAgent4 = new List<float>();

        foreach (GameObject gameObject in simulations)
        {
            List<float> fitness = gameObject.GetComponent<MatchManager>().getFitness();

            fitnessAgent1.Add(fitness[0]);
            fitnessAgent2.Add(fitness[1]);
            fitnessAgent3.Add(fitness[2]);
            fitnessAgent4.Add(fitness[3]);

            Destroy(gameObject);
        }
        
        simulations = new List<GameObject>();
   
        generationAgent1.Fitness = fitnessAgent1;
        generationAgent2.Fitness = fitnessAgent2;
        generationAgent3.Fitness = fitnessAgent3;
        generationAgent4.Fitness = fitnessAgent4;


        generationAgent1.nextGen(0.05f, 0.5f);
        generationAgent2.nextGen(0.05f, 0.5f);
        generationAgent3.nextGen(0.05f, 0.5f);
        generationAgent4.nextGen(0.05f, 0.5f);


        for (int i = 0; i < population; i++)
        {
            simulations.Add(GameObject.Instantiate(prefab, new Vector3(12 * i, 0), Quaternion.Euler(90, 0, 0)));
            simulations[i].GetComponent<MatchManager>().genomeAgent1 = generationAgent1[i];
            simulations[i].GetComponent<MatchManager>().genomeAgent2 = generationAgent2[i];
            simulations[i].GetComponent<MatchManager>().genomeAgent3 = generationAgent3[i];
            simulations[i].GetComponent<MatchManager>().genomeAgent4 = generationAgent4[i];
            simulations[i].GetComponent<MatchManager>().architecture = architecture;
        }

        nbGeneration++;
    }
}