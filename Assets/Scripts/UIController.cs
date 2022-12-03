using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_CoinsText;
    [SerializeField] private TextMeshProUGUI m_CarryingText;
    [SerializeField] private TextMeshProUGUI m_VisitingText;

    [SerializeField] private FloatingText m_FloatingTextPrefab;

    public void SetCoinsText(int value)
    {
        m_CoinsText.text = "Coins: " + value;
    }
    
    public void SetCarryingText(string value)
    {
        m_CarryingText.text = "Carrying: " + value;
    }
    public void SetVisitingText(Structure structure)
    {
        string value = "";
        if (structure != null)
        {
            value = structure.GetType().Name;
        }
        m_VisitingText.text = "Visiting: " + value;
    }

    public FloatingText CreateFloatingText(Vector3 position, float duration = 0.5f)
    {
        FloatingText floatingText = Instantiate(m_FloatingTextPrefab, position, Quaternion.identity);
        StartCoroutine(DestroyFloatingText(floatingText, duration));
        return floatingText;
    }
    IEnumerator DestroyFloatingText(FloatingText text, float duration)
    {
        yield return new WaitForSeconds(duration);
        text.Destroy();
    }
}
