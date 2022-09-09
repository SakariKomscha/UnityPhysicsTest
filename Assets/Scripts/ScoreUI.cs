using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public int scorePlayerRight;
    public int scorePlayerLeft;
    public GUIStyle style;

    private void OnGUI()
    {
        float x = Screen.width / 2f;
        float y = 30f;
        float width = 300f;
        float height = 20f;
        string text = scorePlayerLeft + " / " + scorePlayerRight;

        GUI.Label(new Rect(x - (width / 2f), y, width, height), text, style);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
