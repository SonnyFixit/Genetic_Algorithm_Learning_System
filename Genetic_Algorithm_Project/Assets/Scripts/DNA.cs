using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA
{

    private List<float[][]> dna;
    private float mutationProb = 0.05f;
    private float maxVariation = 1f;
    private float maxMutation = 5f;

    public DNA(List<float[][]> weights)
    {
        this.dna = weights;
    }
    public List<float[][]> getDNA()
    {
        return dna;
    }
    public DNA mutate()
    {
        List<float[][]> newDna = new List<float[][]>();
        for (int i = 0; i < dna.Count; i++)
        {
            float[][] weightsLayer = dna[i];
            for (int j = 0; j < weightsLayer.Length; j++)
            {
                for (int k = 0; k < weightsLayer[j].Length; k++)
                {
                    float rand = UnityEngine.Random.Range(0f, 1f);
                    if (rand < mutationProb)
                    {
                        float mutation = UnityEngine.Random.Range(-maxMutation, maxMutation);
                        weightsLayer[j][k] += mutation;
                    }
                }
            }
            newDna.Add(weightsLayer);
        }
        return new DNA(newDna);
    }

    public DNA crossover(DNA otherParent)
    {
        List<float[][]> child = new List<float[][]>();
        for (int i = 0; i < dna.Count; i++)
        {
            float[][] otherParentLayer = otherParent.getDNA()[i];
            float[][] parentLayer = dna[i];
            float[][] childLayer = new float[parentLayer.Length][];
            for (int j = 0; j < parentLayer.Length; j++)
            {
                childLayer[j] = new float[parentLayer[j].Length];
                for (int k = 0; k < parentLayer[j].Length; k++)
                {
                    float rand = UnityEngine.Random.Range(0f, 1f);
                    if (rand < 0.5f)
                    {
                        // Second parent
                        childLayer[j][k] = otherParentLayer[j][k];
                    }
                    else
                    {
                        // Same as first parent
                        childLayer[j][k] = parentLayer[j][k];
                    }
                }
            }
            child.Add(childLayer);
        }
        return new DNA(child);
    }

}