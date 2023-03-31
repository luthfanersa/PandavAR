using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlinks : MonoBehaviour
{
    public void OpenIG()
    {
        Application.OpenURL("https://instagram.com/luthfanersa");
    }
   public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }
}
