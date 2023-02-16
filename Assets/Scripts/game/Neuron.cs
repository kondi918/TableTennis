using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Neuron
{
    private List<double> weights= new List<double>();
    private List<double> reading_data(string parametres)  // funkcja odpowiedzialna za odczytanie wag z pliku tekstowego
    {
        List <double> weights = new List <double>();
        string number = string.Empty;
        for (int i = 0; i < parametres.Length; i++)
        {
            if (parametres[i] == '|')
            {
                if (double.TryParse(number, out double result))
                {
                    weights.Add(result);
                    number = string.Empty;
                }
            }
            else if (char.IsDigit(parametres[i]) || parametres[i] == '-')
            {
                number += parametres[i];
            }
        }
        return weights;
    }
    private string get_weights()
    {
        string path = Application.streamingAssetsPath + "/parametres.txt";
        string result = File.ReadLines(path).Last();
        return result;
    }
    private double neuron_calculations(double[] weights,double[] numbers)   // funkcja mnozy dane wejsciowe przez ich wagi i sumuje sie do wyniku. Dodawana jest tez dodatkowa liczba
    {
        double result = 0;
        for(int i =0; i < weights.Length-1; i++) 
        {
            result += weights[i] * numbers[i];
        }
        result += weights[weights.Length - 1];
        return result;
    }
    private int activation_function_zero_one(double result)
    {
        if(result < 0 )
        {
            return -1;
        }
        else
        {
            return 1;
        }

    }
    private double activation_function_sigmoid(double x)
    { 
        return 1.0 / (1.0 + Mathf.Exp((float)-x));
    }
    private double activation_function_sinus(double x)
    { 
        return 0.5 * (1 + Mathf.Sin((float)x * Mathf.PI));
    }
    public int get_neuron_answer(List<double> position_data)
    { 
        double result = neuron_calculations(weights.ToArray(),position_data.ToArray());
        return activation_function_zero_one(result);
    }
    public Neuron()
    {
        weights = reading_data(get_weights());
    }
}
