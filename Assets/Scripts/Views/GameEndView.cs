using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameEndView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private TextMeshProUGUI _loseText;
    [SerializeField] private GameObject _endGamePanel;
    
    public void ViewGameEnd(GameResult result)
    {
        _endGamePanel.SetActive(true);
        _endGamePanel.transform.DOScale(0, 0.1f).SetUpdate(true);
        _endGamePanel.transform.DOScale(1, 0.3f).SetUpdate(true);
        if (result == GameResult.Win)
        {
            _winText.gameObject.SetActive(true);
            return;
        }
        _loseText.gameObject.SetActive(true);
    }
}
