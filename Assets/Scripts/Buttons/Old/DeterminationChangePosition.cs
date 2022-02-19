using UnityEngine;

public class DeterminationChangePosition : MonoBehaviour
{
    public void SetPosition(Vector3 buttonPosition, Vector2 offset)
    {
        //Debug.Log(PlayerPrefs.GetInt("Item2"));
        transform.position = buttonPosition + (Vector3)offset;
        //Debug.Log($"{buttonPosition} {offset} {buttonPosition + (Vector3)offset}");
    }
}
