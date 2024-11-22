using System.Collections;
using TMPro;
using UnityEngine;

public class UIPoints : MonoBehaviour
{
    int displayetPoints = 0;
    public TextMeshProUGUI pointsLabel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.Instance.OnPointsUpdated.AddListener(UpdatePoints);
    }

    void UpdatePoints()
    {
        StartCoroutine(UpdatePointsCoroutine());
    }
    IEnumerator UpdatePointsCoroutine()
    {
        while(displayetPoints < GameManager.Instance.Points)
        {
            displayetPoints++;
            pointsLabel.text = displayetPoints.ToString();
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

   
}
