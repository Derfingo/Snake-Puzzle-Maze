using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text textScore = null;
    private int valueScore = SnakeController.LengthTail;

    void Awake()
    {
        if (textScore == null) textScore = GetComponent<Text>();
    }

    void Update()
    {
        textScore.text = SnakeController.LengthTail.ToString();
    }

}
