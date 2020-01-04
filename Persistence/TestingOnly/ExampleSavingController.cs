using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Example class to test saving methods (using Serialization and json conversion).
 */
public class ExampleSavingController : MonoBehaviour
{

    ExampleSavedObject obj = new ExampleSavedObject();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Saving only with Serialization.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FilePersistence.SaveExampleObject(obj);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            obj = FilePersistence.LoadExampleObject();
        }

        // Saving only with JSON conversion.
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            FileJSONPersistence.SaveExampleObject(obj);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            obj = FileJSONPersistence.LoadExampleObject();
        }
    }
}
