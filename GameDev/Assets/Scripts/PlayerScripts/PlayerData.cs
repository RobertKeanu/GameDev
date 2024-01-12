using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 tutorialPosition;
    public Vector3 level1Position;
    public Vector3 level2Position;
    public Vector3 level3Position;

    public PlayerData(Vector3 playerPosition, int level)
    {
        switch (level)
        {
            case 0:
                this.tutorialPosition = playerPosition;
                break;
            case 1:
                this.level1Position = playerPosition;
                break;
            case 2:
                this.level2Position = playerPosition;
                break;
            case 3:
                this.level3Position = playerPosition;
                break;
        }
    }
}
