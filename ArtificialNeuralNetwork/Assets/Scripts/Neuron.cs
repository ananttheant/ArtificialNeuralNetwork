using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A neuron is basically a perceptron
/// </summary>
public class Neuron
{
    /// <summary>
    /// It's the number of Inputs,
    /// usually a neuron is connected to everyother neuron of the previous layer
    /// </summary>
    /// <remarks>
    /// There could be alot of inputs coming into it
    /// </remarks>
    public int numInputs;

    /// <summary>
    /// Extra bias value to move around the results
    /// </summary>
    public double bias;

    /// <summary>
    /// The output from the nueron same as the output from the perceptron
    /// </summary>
    public double output;

    /// <summary>
    /// Assigning the amont of error to that neuron and it's weight
    /// </summary>
    public double errorGradient;

    /// <summary>
    /// List of all of the weights
    /// </summary>
    public List<double> weights = new List<double>();

    /// <summary>
    /// List of all of the inputs from the previous layer
    /// </summary>
    /// <remarks> 
    /// It can come from outside the Neural network or from the previous layer
    /// </remarks>
    public List<double> inputs = new List<double>();

    public Neuron(int nInputs)
    {
        //Settings the bias to random number
        bias = Random.Range(-1f, 1f);

        numInputs = nInputs;

        //Setting the weights randomly
        for (int i = 0; i < nInputs; i++)
        {
            weights.Add(Random.Range(-1f, 1f));
        }
    }
}
