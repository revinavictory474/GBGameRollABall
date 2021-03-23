using UnityEditor;

namespace Geekbrains
{
    public class MenuItems
    {
        [MenuItem("Geekbrains/Item_1")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "Geekbrains");
        }
        [MenuItem("Geekbrains/Item_2 #i")]
        private static void NewMenuOption()
        {
        }
        [MenuItem("Geekbrains/Item_3 #&t")]
        private static void NewNestedOption()
        {
        }
        [MenuItem("Geekbrains/Item_4 %e")]
        private static void NewOptionWithHotKey()
        {
        }
        [MenuItem("Geekbrains/Item_4/Item_4.1 _m")]
        private static void NewOptionWithKey()
        {
        }
        [MenuItem("Assets/Revina")]
        private static void NewFunctional()
        {
        }
        [MenuItem("Assets/Create/TestGB")]
        private static void NewConfig()
        {
        }
        [MenuItem("CONTEXT/BoxCollider/TestGBRevina")]
        private static void NewOpenForBC()
        {
        }


    }
}