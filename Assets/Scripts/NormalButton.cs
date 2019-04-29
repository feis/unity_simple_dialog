using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NormalButton : ClickButton
{
    private Button _dialogButton;
    private bool _isButtonClicked;

    private void Awake()
    {
        _dialogButton = GetComponent<Button>();
    }

    public override IEnumerator WaitForClick()
    {
        gameObject.SetActive(true);
        _dialogButton.onClick.AddListener(_SetButtonClicked);
        _isButtonClicked = false;
        while (!_isButtonClicked)
            yield return null;
        _dialogButton.onClick.RemoveListener(_SetButtonClicked);
    }

    private void _SetButtonClicked()
    {
        _isButtonClicked = true;
    }
}
