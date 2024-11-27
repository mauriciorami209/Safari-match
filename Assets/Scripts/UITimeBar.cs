using UnityEngine;
using UnityEngine.UI;

public class UITimeBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public RectTransform fillRect;
    public Image fillColor;
    public Gradient gradient;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float factor = GameManager.Instance.currentTimeToMatch / GameManager.Instance.timeToMatch;
        factor = Mathf.Clamp(factor, 0f, 1f);
        factor = 1 - factor;
        fillRect.localScale = new Vector3(factor, 1, 1);
        fillColor.color = gradient.Evaluate(factor);
    }
}
