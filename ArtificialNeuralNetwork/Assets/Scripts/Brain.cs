using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    /// <summary>
    /// Our artificial neural network
    /// </summary>
    ANN ann;

    /// <summary>
    /// A value we use in Stats to calculate how close the model
    /// we have constructed fits the data we fed into it
    /// </summary>
    /// <remarks>
    /// The closer it is to 0 the better trained model it is
    /// </remarks>
    double sumSquareError = 0;


    private void Start()
    {
        //make an ann
        //value of alpha is from 0-1
        ann = new ANN(2, 1, 1, 2, 0.8);

        List<double> result;

        //epochs
        for (int i = 0; i < 100000; i++)
        {
            sumSquareError = 0;

            //XNOR
            result = Train(1, 1, 1);

            // (the result we get back - the desired result)^2
            sumSquareError += Mathf.Pow((float) result[0] - 1,2);

            result = Train(1, 0, 0);
            sumSquareError += Mathf.Pow((float)result[0] - 0, 2);

            result = Train(0, 1, 0);
            sumSquareError += Mathf.Pow((float)result[0] - 0, 2);

            result = Train(0, 0, 1);
            sumSquareError += Mathf.Pow((float)result[0] - 1, 2);
        }
        Debug.Log("SSE: " + sumSquareError);

        result = Train(1, 1, 1);
        Debug.Log(" 1,1 = " + result[0]);

        result = Train(1, 0, 0);
        Debug.Log(" 1,0 = " + result[0]);

        result = Train(0, 1, 0);
        Debug.Log(" 0,1 = " + result[0]);

        result = Train(0, 0, 1);
        Debug.Log(" 0,0 = " + result[0]);
    }


    List<double> Train(int _input1, int _input2, int _output)
    {
        List<double> inputs = new List<double>();
        List<double> outputs = new List<double>();

        inputs.Add(_input1);
        inputs.Add(_input2);
        outputs.Add(_output);


        return (ann.Calculate(inputs,outputs));
    }
}
