using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Genome
{
    
    private List<float> parameters;
    private int size;
    //Instantiate random number to be used


    public Genome(int size)
    {
        

        this.parameters = new List<float>();
        this.size = size;
        for (int i = 0; i < size; i++)
        {
            parameters.Add(((float)Random.Range(0f,1f) * 5.0f) - 2.5f);
        }
    }

    public int Size
    {
        get { return this.size; }
    }
    public List<float> Parameters
    {
        get { return parameters; }
    }

    //Return the crossover of a and b
    public static Genome operator +(Genome a, Genome b)
    {
        

        Genome result = new Genome(a.size);

        for(int i = 0; i < result.size; i++)
        {
            if ( (float) Random.Range(0f,1f) <= 0.5)
                result.parameters[i] = a.parameters[i];
            else
                result.parameters[i] = b.parameters[i];
        }

        return result;
    }

    public void mutate(float frequency, float magnitude)
    {
 
        for(int i = 0; i < this.size; i++)
        {
            if ((float)Random.Range(0f,1f) <= frequency)
                this.parameters[i] += ((float)Random.Range(0f,1f) * magnitude) + magnitude / 2.0f;
        }
    }
}
