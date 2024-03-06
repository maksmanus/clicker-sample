using UnityEngine;

public class ButtonBotton : MonoBehaviour {
    
    [SerializeField] private GameObject _currentShop;
    [SerializeField] private GameObject _otherShop;

    public void isClicked()
    {
        if(_currentShop.active == false)
        {
            _otherShop.active = false;
            _currentShop.active = true;
        }

        else
        {
            _otherShop.active = false;
            _currentShop.active = false;
        }
    }
}