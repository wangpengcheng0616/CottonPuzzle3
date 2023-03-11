using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UILoading : MonoBehaviour
{
    // TODO: Loading Image Text
    [SerializeField] private Image m_Image;
    [SerializeField] private Text m_Text;

    [SerializeField] private Slider m_Slider;
    [SerializeField] private Text m_SliderPercentText;

    private void OnEnable()
    {
        m_Slider.DOValue(1, 3f);
        DOTween.Sequence().AppendInterval(1f).AppendCallback
        (
            () => { UIManager.Instance.HideUI(UIType.UILoading); }
        );
    }
}