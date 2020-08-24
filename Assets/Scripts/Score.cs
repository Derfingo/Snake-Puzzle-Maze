using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text lengthText = null;
    int valueScore = SnakeController.lengthTail;

    void Awake()
    {
        if (lengthText == null) lengthText = GetComponent<Text>();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        lengthText.text = SnakeController.lengthTail.ToString();
    }

}
