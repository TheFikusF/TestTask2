using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _fillAreaImage;
    [Header("Other")]
    [SerializeField] private Color _warningColor;
    [SerializeField] private Color _criticalColor;
    private TweenerCore<float, float, FloatOptions> _tween;

    public void StartTimer()
    {
        _slider.transform.localScale = new Vector3();
        _slider.transform.DOScale(1, 0.3f).SetUpdate(true);
        _slider.maxValue = GameStateManager.PlayingTime;
        _slider.value = _slider.maxValue;
        _tween = DOTween.To(() => _slider.value, x => _slider.value = x, 0, _slider.maxValue)
            .SetUpdate(true)
            .OnUpdate(() =>
            {
                _text.text = Mathf.Ceil(_slider.value).ToString() + "s";
                float sliderFilledPercent = _slider.value / _slider.maxValue;
                if (sliderFilledPercent < 0.5f)
                {
                    _fillAreaImage.color = _warningColor;
                }

                if (sliderFilledPercent < 0.2f)
                {
                    _fillAreaImage.color = _criticalColor;
                }
            }).SetEase(Ease.Linear);
    }

    public void StopTimer()
    {
        _tween.Kill();
    }
}
