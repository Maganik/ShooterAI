using System.Collections;
using System.Collections.Generic;
using System;


public class Neuron
{
    private List<float> weights;
    private int type; // 0  => input 1 => hidden 2 => output
    private float output;
    private float persistence = 0;
    private float persWeight;
    private Func<float, float> activation;



    public Neuron(List<float> w, int t, Func<float, float> func)
    {
        this.weights = w.GetRange(0,w.Count-1);
        this.persWeight = w[w.Count - 1];
        this.type = t;
        this.activation = func;
    }

    public void compute(List<float> inputs)
    {
        if (inputs.Count != weights.Count) { }
           // debug

        float result = 0.0f;
        for(int i = 0; i < inputs.Count; i++)
        {
            result += weights[i] * inputs[i];
        }

        this.output = activation(result + persistence*persWeight);
        this.persistence = this.output;
    }

    public float Value
    {
        get { return output; }
    }
}

