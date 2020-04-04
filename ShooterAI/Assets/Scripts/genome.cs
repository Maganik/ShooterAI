using System.Collections;
using System.Collections.Generic;
using System;

public class Genome
{
    private List<float> parameters;
    private int size;

    public Genome(int size)
    {
        Random rand = new Random(); //Instantiate random number to be used

        parameters = new List<float>(size);
        this.size = size;

        for (int i = 0; i < size; i++)
        {
            parameters[i] = ((float)rand.NextDouble() * 10.0f) - 5.0f;
        }
    }

    public List<float> Parameters
    {
        get { return parameters; }
    }

    //Return the crossover of a and b
    public static Genome operator +(Genome a, Genome b)
    {
        Random rand = new Random(); //Instantiate random number to be used

        if (a.size != b.size) throw new Exception();

        Genome result = new Genome(a.size);

        for(int i = 0; i < result.size; i++)
        {
            if ((float)rand.NextDouble() <= 0.5)
                result.parameters[i] = a.parameters[i];
            else
                result.parameters[i] = b.parameters[i];
        }

        return result;
    }

    public void mutate(float frequency, float magnitude)
    {
        Random rand = new Random(); //Instantiate random number to be used

        for(int i = 0; i < this.size; i++)
        {
            if ((float)rand.NextDouble() <= frequency)
                this.parameters[i] += ((float)rand.NextDouble() * magnitude) + magnitude / 2.0f;
        }
    }
}
