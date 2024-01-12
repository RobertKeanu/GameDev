using UnityEngine;
using System.IO;

public static class SaveSystem
{
    public static void SavePlayerPosition(PlayerData pd)
    {
        File.WriteAllText("./playerData.json", JsonUtility.ToJson(pd));
    }

    public static PlayerData LoadPlayer()
    {
        return JsonUtility.FromJson<PlayerData>(File.ReadAllText("./playerData.json"));
    }
}
