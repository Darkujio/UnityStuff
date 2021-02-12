using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButtonScript : MonoBehaviour
{
    public void ShopButton(){
        SceneManager.LoadScene("SkinShop");
    }
}
