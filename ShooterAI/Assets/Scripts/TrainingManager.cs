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
    // Start is called before the first frame update
    void Start()
    {
        simulations = new List<GameObject>(population);
        generation = new Generation(population, RecurentNet.getNbWeightForArchi(architecture));
        for(int i = 0; i< population;i++)
        {
           simulations[i] =  GameObject.Instantiate(prefab, new Vector3(12 * i, 0), Quaternion.Euler(90,0,0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
