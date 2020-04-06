using System.Collections;
using System.Collections.Generic;

public class Generation
{
    private List<Genome> currentGen;
    private List<float> fitness;
    private readonly int nbGenome; 

    public Generation(int population, int genomeSize)
    {
        nbGenome = population;
        fitness = new List<float>();
        currentGen = new List<Genome>();

        for(int i = 0; i < population; i++)
        {
            currentGen.Add(new Genome(genomeSize));
            fitness.Add(0.0f);
        }
    }

    public List<float> Fitness
    {
        set { fitness = value; }
    }

    //Compute to next generation
    public void nextGen(float frequency, float magnitude)
    {
        System.Random rand = new System.Random(); //Instantiate random number to be used
        List<Genome> nextGen = new List<Genome>();

        //Sorting Variables
        float fitMax = 0.0f;
        float tempFloat = 0.0f;
        int tempIndex = 0;

        //Probabilities Variables
        List<int> probaTab = new List<int>();
        int probaTemp1;
        int probaTemp2;

        //NextGen Variables
        Genome tempGenome = new Genome(currentGen[0].Size);
        float frequencyOfMutation = frequency; //Probability of mutation
        float forceOfMutation = magnitude; //Magnitude of change when mutate

        //Sorting
        for(int i = 0; i < this.nbGenome; i++)
        {
            for(int j = 0; j < this.nbGenome-1; i++)
            {
                if (fitness[j] > fitness[j + 1])
                {
                    fitMax = fitness[j];
                    tempIndex = j;
                }
            }
            //Sorting algorithme
            tempFloat = fitness[i];
            tempGenome = currentGen[i];
            fitness[i] = fitness[tempIndex];
            currentGen[i] = currentGen[tempIndex];
            fitness[tempIndex] = tempFloat;
            currentGen[tempIndex] = tempGenome;
        }

        //Setting probabilities
        for(int i = 0; i < this.nbGenome; i++)
        {
            for(int j = i; j < this.nbGenome; j++)
            {
                probaTab.Add(i);
            }
        }

        //Picking algorithme
        for(int i = 0; i < nbGenome; i++)
        {
            //Proba settings
            probaTemp1 = rand.Next(probaTab.Count);
           /* do
            {*/
                probaTemp2 = rand.Next(probaTab.Count);
           // } while (probaTab[probaTemp1] == probaTab[probaTemp2]);

            //Forming nextgen
            nextGen[i] = currentGen[probaTab[probaTemp1]] + currentGen[probaTab[probaTemp2]];
            nextGen[i].mutate(frequencyOfMutation, forceOfMutation);
        }
    }

    public Genome this[int i]
    {
        get { return currentGen[i]; }
    }
}
