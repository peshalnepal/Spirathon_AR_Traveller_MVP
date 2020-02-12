using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_manager : MonoBehaviour
{
   public void scene_load_portal()
   {
    SceneManager.LoadScene(1);
   }
   public void scene_load_Recognize()
   {
    SceneManager.LoadScene(2);
   }
   
}
