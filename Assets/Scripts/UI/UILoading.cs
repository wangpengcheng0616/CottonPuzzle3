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
        m_Slider.DOValue(1, 2f);
        DOTween.Sequence().AppendInterval(2f).AppendCallback
        (
            () =>
            {
                UIManager.Instance.HideUI(UIType.UILoading);
                UIManager.Instance.ShowUI(UIType.UIGameStart);
                m_Slider.value = 0;
            }
        );
    }
}