using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class FilePersistence
{

    // Only to save in default case (not actually needed). Just to test.
    private const string DEFAULT_FILE_NAME = "default.save";

    /**
     * Save method (send an SavingObject inherited class that is Serialized).
     * You can create another method to call this one with any specification, like as SaveExampleObject.
     */
    public static void Save<T>(T objectToSave, string filename)
    {
        // Preparing file.
        BinaryFormatter bf = new BinaryFormatter();
        string fileFullPath = CreateFullPath(filename);
        Debug.Log(string.Format("Saving game data into {0}...", fileFullPath));
        FileStream fs = File.Open(fileFullPath, FileMode.Create);

        // Saving data in file.
        bf.Serialize(fs, objectToSave);
        fs.Close();

        Debug.Log(string.Format("Game data was saved into {0}", filename));
    }

    public static T Load<T>(string filename)
    {
        string fileFullPath = CreateFullPath(filename);
        Debug.Log(string.Format("Trying to loading game data from {0}...", fileFullPath));
        if (File.Exists(fileFullPath))
        {
            // Preparing file.
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(fileFullPath, FileMode.Open);

            T obj = (T)bf.Deserialize(fs);
            fs.Close();

            Debug.Log(string.Format("Loaded game data from {0} successfully", filename));
            return obj;
        }

        // If not loading game data, log warning and throw exception.
        Debug.LogWarning(string.Format("There wasn't game data into {0}.", filename));
        throw new System.Exception("Game data not exists");
    }

    // Save specification method.
    public static void SaveExampleObject(ExampleSavedObject exObj)
    {
        Save(exObj, "example-object.save");
    }

    // Load specification method.
    public static ExampleSavedObject LoadExampleObject()
    {
        return Load<ExampleSavedObject>("example-object.save");
    }

    // Private utils.
    private static string CreateFullPath(string filename)
    {
        return string.Format(
            "{0}/{1}", 
            Application.persistentDataPath, 
            filename != null ? filename : DEFAULT_FILE_NAME
        );
    }

}
