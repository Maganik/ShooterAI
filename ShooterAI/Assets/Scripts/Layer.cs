using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Layer 
{
    private List<Neuron> neurons;

    public Layer(List<float> weights, int nbNeurons, Func<float, float> func, int t)
    {
        this.neurons = new List<Neuron>();
        int nb_inputs = weights.Count / nbNeurons;
        for(int i = 0; i <nbNeurons;i++)
        {
            this.neurons.Add(new Neuron(weights.GetRange(i * nb_inputs, nb_inputs), t, func));
        }
    }

    
    public void compute(List<float> inputs)
    {
        foreach(Neuron n in neurons)
        {
            n.compute(inputs);
        }
    }

    public List<float> getOutput()
    {
        List<float> result = new List<float>();
        foreach(Neuron n in neurons)
        {
            result.Add(n.Value);
        }
        return result;
    }
}
