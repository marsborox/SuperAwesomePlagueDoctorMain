using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Player _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = _player.score.ToString();
    }
}
