using UnityEngine;

// A static class (never attached to an object). Holds the gem count and the saved record.
public static class RunState
{
    const string RecordKey = "TopGems";

    public static int Gems;

    public static int Record
    {
        get { return PlayerPrefs.GetInt(RecordKey, 0); }
    }

    public static void Reset()
    {
        Gems = 0;
    }

    public static void StoreRecord()
    {
        if (Gems > Record)
        {
            PlayerPrefs.SetInt(RecordKey, Gems);
            PlayerPrefs.Save();
            Debug.Log("New record stored: " + Gems);
        }
    }
}
