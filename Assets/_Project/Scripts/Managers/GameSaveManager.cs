using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{
    [SerializeField] private IntValue _highScoreData;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        InitializeSaveManager();
    }


    private void OnDisable()
    {
        ScoreScript.OnUpdateHighScore -= SaveHighScoreData;
    }

    private void SaveHighScoreData()
    {
        FileStream stream = File.Create(Application.persistentDataPath +
               $"/highscore.dat");
        BinaryFormatter binary = new BinaryFormatter();
        var json = JsonUtility.ToJson(_highScoreData);
        binary.Serialize(stream, json);
        stream.Close();
    }

    private void LoadHighScore()
    {
        if (File.Exists(Application.persistentDataPath +
                $"/highscore.dat"))
        {
            FileStream stream = File.Open(Application.persistentDataPath +
                $"/highscore.dat", FileMode.Open);
            BinaryFormatter binary = new BinaryFormatter();
            JsonUtility.FromJsonOverwrite((string)binary.Deserialize(stream), _highScoreData);
            stream.Close();
        }
    }

    private void InitializeSaveManager()
    {
        LoadHighScore();
        ScoreScript.OnUpdateHighScore += SaveHighScoreData;
    }
}
