using System.Collections;
using System.Collections.Generic;
using System;

public class RecurentNet
{
    private List<Layer> layers;

    public RecurentNet(List<float> weights, List<int> architecture, Func<float, float> func)
    {
        this.layers = new List<Layer>();
        int startIndex = 0;
        for(int i = 0; i< architecture.Count-1; i++)
        {
            int nbWeights = (architecture[i]+1) * architecture[i+1]; // 
            layers.Add(new Layer(weights.GetRange(startIndex, nbWeights), architecture[i+1], func, 1));
            startIndex += nbWeights;
        }
    }

    public static int getNbWeightForArchi(List<int> architecture)
    {
        int startIndex = 0;
        for (int i = 0; i < architecture.Count - 1; i++)
        {
            int nbWeights = (architecture[i] + 1) * architecture[i + 1]; // 
            startIndex += nbWeights;
        }
        return startIndex;
    }

    public void feedForward(List<float> inputs)
    {
        this.layers[0].compute(inputs);
        for(int i = 1; i<this.layers.Count;i++)
        {
            this.layers[i].compute(this.layers[i - 1].getOutput());
        }
    }

    public List<float> Output
    {
        get { return layers[layers.Count - 1].getOutput(); }
    }
}
