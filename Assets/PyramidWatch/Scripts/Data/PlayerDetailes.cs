using UnityEngine;

[CreateAssetMenu(fileName = "Player Details", menuName = "PlayerData")]
public class PlayerDetailes : ScriptableObject
{
    public string UserName;
    public int coinAmount;
    public int badePointAmount;
}
