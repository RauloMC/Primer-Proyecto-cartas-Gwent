
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public TMP_Text NameText; 
    public Sprite Photo;

    public string Name
    {
        get { return NameText.text; }
    }
}
