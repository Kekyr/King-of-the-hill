using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int ScoreModifier;
    private static TextMeshProUGUI _scoreText;
    private static int _score;
    
    private static TextMeshPro _scoreCounterText;
    private static Vector3 _scoreCounterPosition;
    private static Transform _scoreCounterParent;

    private static float _positionYModificator=0.001f;
    
    private void Start()
    {
        _score = 0;
        ScoreModifier = 0;
        _scoreText = GetComponent<TextMeshProUGUI>();
        _scoreCounterText = GameObject.Find("Score Counter (TMP)").GetComponent<TextMeshPro>();
    }

    public static Vector3 ScoreCounterPosition
    {
        get
        {
            return _scoreCounterPosition;
        }
        set
        {
            Vector3 counterPosition = new Vector3(value.x, value.y + _positionYModificator, value.x);
            _scoreCounterPosition = counterPosition;
            _scoreCounterText.transform.position = _scoreCounterPosition;
            _scoreCounterText.gameObject.GetComponent<Animator>().Play(0);
        }
        
    }

    public static Transform ScoreCounterParent
    {
        get
        {
            return _scoreCounterParent;
        }
        set
        {
            _scoreCounterParent = value;
            _scoreCounterText.transform.SetParent(_scoreCounterParent, true);
        }
    }
    

    public static int Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value + ScoreModifier;
            _scoreText.text = _score.ToString();
            int temp = 1 + ScoreModifier;
            _scoreCounterText.text = "+ " + temp.ToString();
        }
    }
}
