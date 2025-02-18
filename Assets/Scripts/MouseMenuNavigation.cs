//using UnityEngine;
//using UnityEngine.InputSystem;

//public class MouseMenuNavigationInputSystem : MonoBehaviour
//{
//    public RectTransform[] menu_options; // Opțiunile de meniu
//    private int current_index = -1;

//    private Vector2 mouse_position;

//    // Metodă pentru a detecta mișcarea mouse-ului
//    public void OnPoint(InputAction.CallbackContext context)
//    {
//        mouse_position = context.ReadValue<Vector2>();
//    }

//    // Metodă pentru a detecta clicul
//    public void OnClick(InputAction.CallbackContext context)
//    {
//        if (context.performed && current_index != -1)
//        {
//            ExecuteOption(current_index);
//        }
//    }

//    private void Update()
//    {
//        // Verifică dacă mouse-ul este deasupra vreunei opțiuni
//        for (int i = 0; i < menu_options.Length; i++)
//        {
//            if (RectTransformUtility.RectangleContainsScreenPoint(menu_options[i], mouse_position))
//            {
//                current_index = i;
//                return;
//            }
//        }

//        // Resetează indexul dacă mouse-ul nu este pe nicio opțiune
//        current_index = -1;
//    }

//    public void ExecuteOption(int index)
//    {
//        Debug.Log($"Opțiunea {index + 1} selectată!");
//        // Adaugă aici logica pentru fiecare opțiune
//        switch (index)
//        {
//            case 0:
//                Debug.Log("Ai ales prima opțiune!");
//                break;
//            case 1:
//                Debug.Log("Ai ales a doua opțiune!");
//                break;
//            case 2:
//                Debug.Log("Ai ales a treia opțiune!");
//                break;
//            case 3:
//                Debug.Log("Ai ales a patra opțiune!");
//                break;
//        }
//    }
//}
