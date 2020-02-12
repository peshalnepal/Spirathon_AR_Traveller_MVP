
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button_pressed : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject room;
   public GameObject place;
    public GameObject door;
public void Hotel_scroll(int val)
{
    if(val==0)
    {
            room.SetActive(false);
            place.SetActive(true);
            door.SetActive(true);
    }
    else if(val==1)
    {
      Debug.Log("hotel1");
      room.SetActive(true);
      place.SetActive(false);
      door.SetActive(false);
    }
}
public void go_back()
{
SceneManager.LoadScene(0);
}
}
