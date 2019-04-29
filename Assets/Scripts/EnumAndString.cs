using UnityEngine;

public class EnumAndString : MonoBehaviour
{
    private string stateA;
    private State stateB;

    private enum State
    {
        Open,
        Running,
        Close,
    }

    private void SwitchA()
    {
        switch(stateA)
        {
            case "Open":
                break;
            case "Running":
                break;
            case "Close":
                break;
        }
    }

    private void SwitchB()
    {
        switch(stateB)
        {
            case State.Open:
                break;
            case State.Running:
                break;
            case State.Close:
                break;
        }
    }
}
