using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogPanelV2 : MonoBehaviour
{  
    public AnimationClip playFirstDialogMessageAnimation;
    public AnimationClip playSecondDialogMessageAnimation;
    public AnimationClip playThirdDialogMessageAnimation;

    public AnimationClip openDialogAnimation;
    public AnimationClip closeDialogAnimation;

    public Button dialogButton;

    private Image _dialogPanel;
    private Animation _animation;
    private bool _isButtonClicked;

    public void Awake()
    { 
        _dialogPanel = GetComponent<Image>();
        _animation = GetComponent<Animation>();
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
        _animation.Play(openDialogAnimation.name);
        while (_animation.isPlaying)
            yield return null;
    }

    private IEnumerator 播放第一段對話()
    {
        _animation.Play(playFirstDialogMessageAnimation.name);
        while (_animation.isPlaying)
            yield return null;
    }

    private IEnumerator 等待第一次按繼續按鈕()
    {
        yield return 等待按繼續按鈕();
    }

    private IEnumerator 播放第二段對話()
    {
        _animation.Play(playSecondDialogMessageAnimation.name);
        while (_animation.isPlaying)
            yield return null;
    }

    private IEnumerator 等待第二次按繼續按鈕()
    {
        yield return 等待按繼續按鈕();
    }

    private IEnumerator 播放第三段對話()
    {
        _animation.Play(playThirdDialogMessageAnimation.name);
        while (_animation.isPlaying)
            yield return null;
    }

    private IEnumerator 等待第三次按繼續按鈕()
    {
        yield return 等待按繼續按鈕();
    }

    private IEnumerator 關閉對話框()
    {
        _animation.Play(closeDialogAnimation.name);
        while (_animation.isPlaying)
            yield return null;
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
