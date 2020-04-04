using System.Collections;
using System.Collections.Generic;


public class Neuron
{
    private List<float> weights;
    private int type; // 0  => input 1 => hidden 2 => output
    private float output;
    private float persistence = 0;
    private Func<float, float> activation;



    public Neuron(List<float> w, int t, Func<float, float> func)
    {
        this.weights = w;
        this.type = t;
    }

    public void compute(List<float> inputs)
    {
        if (inputs.Count != weights.Count) { }
           // debug

        float result = 0.0f;
        for(int i; i < inputs.Count; i++)
        {
            result += weights[i] * inputs[i];
        }

        this.output = activation(result + persistence);
        this.persistence = this.output;
    }

    public float Value
    {
        get { return output; }
    }
}

