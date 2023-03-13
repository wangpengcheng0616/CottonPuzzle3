using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    // TODO: Loading Image Text
    [SerializeField] private Image m_Image;
    [SerializeField] private Text m_Text;

    [SerializeField] private Slider m_Slider;

    private void OnEnable()
    {
        var duration = 1f;
        m_Slider.DOValue(1, duration);
        DOTween.Sequence().AppendInterval(duration).AppendCallback
        (
            () =>
            {
                UIManager.Instance.HideUI(UIType.UILoading, duration);
                UIManager.Instance.ShowUI(UIType.UIGameStart, duration);
                m_Slider.value = 0;
            }
        );
    }
}