using UnityEngine;

public class Fixed : MonoBehaviour
{
    private void Start()
    {
        SetResolution();
    }

    public void SetResolution()
    {
        int setWidth = 720; 
        int setHeight = 1280; 

        Screen.SetResolution(setWidth, setHeight, true);
    }
}
