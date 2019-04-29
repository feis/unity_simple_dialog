using UnityEngine;
using System.Collections;

public abstract class ClickButton : MonoBehaviour
{
    public abstract IEnumerator WaitForClick();
}
