using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_Text;

    private const float FADE_DURATION = 0.2f;

    public void SetText(string value)
    {
        m_Text.text = value;
        m_Text.alpha = 0;
        m_Text.DOFade(1, FADE_DURATION);
    }

    public void Destroy()
    {
        m_Text.DOFade(0, FADE_DURATION).onComplete = () => { Destroy(this.gameObject); };
    }
}
