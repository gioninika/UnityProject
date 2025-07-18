using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCheckpointHandler : MonoBehaviour
{
    public static PlayerCheckpointHandler Instance;
    private Vector3 lastCheckpointPosition;
    private Rigidbody2D rb;
    private GameObject lastCheckpointObj;

    private string CheckpointPosKey => SceneManager.GetActiveScene().name + "_LastCheckpoint";
    private string CheckpointNameKey => SceneManager.GetActiveScene().name + "_LastCheckpointName";

    void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();

        if (PlayerPrefs.HasKey(CheckpointPosKey))
        {
            string pos = PlayerPrefs.GetString(CheckpointPosKey);
            lastCheckpointPosition = StringToVector3(pos);
            transform.position = lastCheckpointPosition;

            string cpName = PlayerPrefs.GetString(CheckpointNameKey, "");
            if (cpName != "")
            {
                GameObject found = GameObject.Find(cpName);
                if (found != null)
                {
                    lastCheckpointObj = found;
                    lastCheckpointObj.SetActive(false);
                }
            }

            Debug.Log("Loaded checkpoint at: " + lastCheckpointPosition);
        }
        else
        {
            lastCheckpointPosition = transform.position;
        }
    }

    public void SetCheckpoint(Vector3 pos, GameObject checkpointObject)
    {
        if (lastCheckpointObj != null)
        {
            lastCheckpointObj.SetActive(true);
        }

        lastCheckpointObj = checkpointObject;
        lastCheckpointObj.SetActive(false);

        lastCheckpointPosition = pos;

        PlayerPrefs.SetString(CheckpointPosKey, pos.ToString());
        PlayerPrefs.SetString(CheckpointNameKey, checkpointObject.name);
        PlayerPrefs.Save();

        Debug.Log("Checkpoint saved at " + checkpointObject.name);
    }

    public void Respawn()
    {
        transform.position = lastCheckpointPosition;
        rb.linearVelocity = Vector2.zero;
    }

    private Vector3 StringToVector3(string s)
    {
        s = s.Trim('(', ')');
        string[] parts = s.Split(',');
        return new Vector3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]));
    }

    public void ClearCheckpoint()
    {
        PlayerPrefs.DeleteKey(CheckpointPosKey);
        PlayerPrefs.DeleteKey(CheckpointNameKey);
        PlayerPrefs.Save();

        Debug.Log("Checkpoint data cleared.");
    }
}
