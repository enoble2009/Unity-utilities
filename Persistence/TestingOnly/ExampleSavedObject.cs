using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Test class to test saving.
 */
[System.Serializable]
public class ExampleSavedObject
{

    [SerializeField]
    private string name = "";
    [SerializeField]
    private int age = 0;
    [SerializeField]
    private float[] pointsByLevel = new float[0];

    public ExampleSavedObject()
    {
        name = name + "s";
        age = age + 20;
        pointsByLevel = new float[pointsByLevel.Length + 1];
        for (int i = 0; i < pointsByLevel.Length; i++)
        {
            pointsByLevel[i] = 12.35f;
        }
    }

}
