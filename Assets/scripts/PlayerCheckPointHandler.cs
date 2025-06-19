using UnityEngine;

public class PlayerCheckpointHandler : MonoBehaviour
{
    public static GameObject Instance;
    private Vector3 lastCheckpointPosition;
    private Rigidbody2D rb;

    private const string CheckpointPosKey = "LastCheckpoint";
    private const string CheckpointNameKey = "LastCheckpointName";

    private GameObject lastCheckpointObj;

    void Start()
    {
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
                    lastCheckpointObj.SetActive(false); // keep it deactivated
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
        // Reactivate the last one if it exists
        if (lastCheckpointObj != null)
        {
            lastCheckpointObj.SetActive(true);
        }

        lastCheckpointObj = checkpointObject;
        lastCheckpointObj.SetActive(false); // deactivate new one

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }
}
