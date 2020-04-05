using System.Collections;
using System.Collections.Generic;

public class Generation
{
    private List<Genome> currentGen;
    private List<float> fitness;
    private int nbGenome;

    public Generation(int population, int genomeSize)
    {
        fitness = new List<float>(population);

        for(int i = 0; i < population; i++)
        {
            currentGen[i] = new Genome(genomeSize);
            fitness[i] = 0.0f;
        }
    }

    public List<float> Fitness
    {
        set { fitness = value; }
    }

    public void nextGen()
    {

    }
}
