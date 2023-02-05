using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Text TextGui;
    private int _scr;

    public int Score {
        get { return _scr; }
        set {
            _scr = value;
            TextGui.text = Score.ToString();
            PlayerPrefs.SetInt("Score", 159);
        }
    }

    public int getScore()
    {
        return _scr;
    }

    public void setScore(int score)
    {
        _scr = score;
        TextGui.text = "Health: " + Score.ToString();
    }

    private void Update()
    {
        setScore(player.GetHealth());
    }
}
