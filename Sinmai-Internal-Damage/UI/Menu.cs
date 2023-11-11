using Sinmai.Functions;
using Sinmai.Helper;
using UnityEngine;

namespace Sinmai.UI
{
    public class Menu : MonoBehaviour
    {
        private bool MenuToggle = true;
        private Rect Window;


        private void Start()
        {
            Window = new Rect(350, 100f, 300, 400);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Delete)) // check Unity.Input when menu open unlock ur cursor
                MenuToggle = !MenuToggle;
        }

        private void OnGUI()
        {
            // Draw ur epic hek here
            if (MenuToggle)
            {
                Window = GUILayout.Window(0, Window, RenderMenu, "Internal Damage for Sinmai");
                int draw_y = (int)(Screen.height * 0.234375);
                Render.DrawString(new Vector2(0, draw_y), "Sinmai-Internal-Damage", false);
                Render.DrawString(new Vector2(0, draw_y + 15), $"Game Version: {Settings.GameVersion}", false);
                Render.DrawString(new Vector2(0, draw_y + 30), $"Build: {Settings.Version}", false);
            }



            AutoPlay.Opposite();
            AutoPlay.RandomCycle();
            AutoPlay.Force();
        }

        private void RenderMenu(int id)
        {
            switch (id)
            {
                // Menu
                case 0:
                    GUILayout.BeginVertical("MainToolbar", GUILayout.Height(20));
                    Settings.MainToolbarInt = GUILayout.Toolbar(Settings.MainToolbarInt, Settings.MainToolbarStrings, GUILayout.Width(300), GUILayout.Height(20));
                    GUILayout.EndVertical();

                    switch (Settings.MainToolbarInt)
                    {
                        case 0:
                            GUILayout.BeginVertical("Legit");
                            // Legit
                            GUILayout.Label("Legit");
                            Settings.LegitAutoPlayCheckBox = GUILayout.Toggle(Settings.LegitAutoPlayCheckBox, "Legit AutoPlay");
                            if (Settings.LegitAutoPlayCheckBox)
                            {
                                Settings.LegitMethodInt =
                                    GUILayout.SelectionGrid(Settings.LegitMethodInt, Settings.LegitMethod, 1);
                                switch (Settings.LegitMethodInt)
                                {
                                    case 0:
                                    case 1:
                                        GUILayout.Label("Critical Value");
                                        Settings.CriticalValue = GUILayout.HorizontalScrollbar(Settings.CriticalValue, 1.0f, 0.0f, 100.0f);
                                        GUILayout.Label("Perfect Value");
                                        Settings.PerfectValue = GUILayout.HorizontalScrollbar(Settings.PerfectValue, 1.0f, 0.0f, 100.0f);
                                        GUILayout.Label("Great Value");
                                        Settings.GreatValue = GUILayout.HorizontalScrollbar(Settings.GreatValue, 1.0f, 0.0f, 100.0f);
                                        GUILayout.Label("Good Value");
                                        Settings.GoodValue = GUILayout.HorizontalScrollbar(Settings.GoodValue, 1.0f, 0.0f, 100.0f);
                                        GUILayout.Label("Miss Value");
                                        Settings.MissValue = GUILayout.HorizontalScrollbar(Settings.MissValue, 1.0f, 0.0f, 100.0f);
                                        break;
                                    case 2:
                                        Settings.CriticalToggle = GUILayout.Toggle(Settings.CriticalToggle, "Critical");
                                        Settings.PerfectToggle = GUILayout.Toggle(Settings.PerfectToggle, "Perfect");
                                        Settings.GreatToggle = GUILayout.Toggle(Settings.GreatToggle, "Great");
                                        Settings.GoodToggle = GUILayout.Toggle(Settings.GoodToggle, "Good");
                                        Settings.MissToggle = GUILayout.Toggle(Settings.MissToggle, "Miss");
                                        break;
                                    default:
                                        break;
                                }
                            }
                            GUILayout.EndVertical();
                            break;
                        case 1:
                            GUILayout.BeginVertical("Misc");
                            // Misc
                            GUILayout.Label("Misc");
                            Settings.InfinityFreedomTimeCheckBox = GUILayout.Toggle(Settings.InfinityFreedomTimeCheckBox, "Infinity FreedomTime");
                            Settings.InfinityPrepareTimeCheckBox = GUILayout.Toggle(Settings.InfinityPrepareTimeCheckBox, "Infinity PrepareTime");
                            if (GUILayout.Button("Force Track Skip"))
                                Track.ForceTrackSkip();
                            if (GUILayout.Button("Unload"))
                                Loader.Unload();
                            GUILayout.EndVertical();
                            break;
                        default:
                            break;
                    }

                    // A cute break
                    break;
            }

            GUI.DragWindow();
        }
    }
}