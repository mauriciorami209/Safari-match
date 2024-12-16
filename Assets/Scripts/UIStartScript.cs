using UnityEngine;

public class UIStartScript : MonoBehaviour
{
    public void StartBtnClicked()
    {
        GameManager.Instance.StartGame();
    }
}
