using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogPanelV1 : MonoBehaviour
{  
    public GameObject firstDialogMessageRoot;
    public RectTransform firstDialogMessageMask;
    public Text firstDialogMessageLabel;

    public GameObject secondDialogMessageRoot;
    public RectTransform secondDialogMessageMask;
    public Text secondDialogMessageLabel;

    public GameObject thirdDialogMessageRoot;
    public RectTransform thirdDialogMessageMask;
    public Text thirdDialogMessageLabel;

    public Button dialogButton;

    private Image _dialogPanel;
    private bool _isButtonClicked;

    public void Awake()
    {
       _dialogPanel = GetComponent<Image>();
    }

    public IEnumerator Start()
    {
        yield return 開啟對話框();
        yield return 播放第一段對話();
        yield return 等待第一次按繼續按鈕();
        yield return 播放第二段對話();
        yield return 等待第二次按繼續按鈕();
        yield return 播放第三段對話();
        yield return 等待第三次按繼續按鈕();
        yield return 關閉對話框();
    }

    private IEnumerator 開啟對話框()
    {
        var fromColor = 
            _dialogPanel.color * new Color(1f, 1f, 1f, 0f);
        var toColor = _dialogPanel.color;
        const int length = 60;
        for (var i = 0; i < length; i++) { 
            _dialogPanel.color = 
                Color.Lerp(fromColor, toColor, i / (float) length);
            yield return null;
        }
        _dialogPanel.color = toColor;
    }

    private IEnumerator 播放第一段對話()
    {
        yield return
            播放對話(
                firstDialogMessageRoot,
                firstDialogMessageMask,
                firstDialogMessageLabel,
                dialogButton);
    }

    private IEnumerator 等待第一次按繼續按鈕()
    {
        yield return 等待按繼續按鈕();
    }

    private IEnumerator 播放第二段對話()
    {
        firstDialogMessageRoot.SetActive(false);

        yield return
            播放對話(
                secondDialogMessageRoot,
                secondDialogMessageMask,
                secondDialogMessageLabel,
                dialogButton);
    }

    private IEnumerator 等待第二次按繼續按鈕()
    {
        yield return 等待按繼續按鈕();
    }

    private IEnumerator 播放第三段對話()
    {
        secondDialogMessageRoot.SetActive(false);

        yield return
            播放對話(
                thirdDialogMessageRoot,
                thirdDialogMessageMask,
                thirdDialogMessageLabel,
                dialogButton);
    }

    private IEnumerator 等待第三次按繼續按鈕()
    {
        yield return 等待按繼續按鈕();
    }

    private IEnumerator 關閉對話框()
    {
        dialogButton.gameObject.SetActive(false);
        thirdDialogMessageRoot.SetActive(false);

        const int length = 20;

        var fromColor = _dialogPanel.color;
        var toColor = _dialogPanel.color * new Color(1f, 1f, 1f, 0f); 

        var fromSizeDelta = _dialogPanel.rectTransform.sizeDelta;
        var toSizeDelta = 
            _dialogPanel.rectTransform.sizeDelta * new Vector2(0.6f, 0.9f);

        for (var i = 0; i < length; i++)
        {
            _dialogPanel.color =
                Color.Lerp(fromColor, toColor, i / (float) length);

            _dialogPanel.rectTransform.sizeDelta =
                Vector2.Lerp(fromSizeDelta, toSizeDelta, i / (float) length);

            yield return null;
        }
        _dialogPanel.color = toColor;
        _dialogPanel.rectTransform.sizeDelta = toSizeDelta;
    }


    private static IEnumerator 播放對話(
        GameObject dialogMessageRoot,
        RectTransform dialogMessageMask,
        Text dialogMessageLabel,
        Button dialogButton)
    {
        dialogButton.gameObject.SetActive(false);
        dialogMessageRoot.SetActive(true);

        const int length = 90;

        var fromSizeDelta = 
            dialogMessageMask.sizeDelta * new Vector2(0f, 1f);

        var toSizeDelta = 
            dialogMessageMask.sizeDelta;

        for (var i = 0; i < length; i++)
        {
            dialogMessageMask.sizeDelta = 
                Vector2.Lerp(
                    fromSizeDelta, 
                    toSizeDelta, 
                    i /  (float) length);
            yield return null;
        }

        dialogMessageMask.sizeDelta = toSizeDelta;
    }

    private IEnumerator 等待按繼續按鈕()
    {
        dialogButton.gameObject.SetActive(true);
        dialogButton.onClick.AddListener(_SetButtonClicked);
        _isButtonClicked = false;
        while (!_isButtonClicked)
            yield return null;
        dialogButton.onClick.RemoveListener(_SetButtonClicked);
    }

    private void _SetButtonClicked()
    {
        _isButtonClicked = true;
    }
}
