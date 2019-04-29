using UnityEngine;
using System.Collections;

public class SpaceButton : ClickButton
{
    public override IEnumerator WaitForClick()
    {
        while (!Input.GetKey(KeyCode.Space))
            yield return null;
    }
}
