using Sinmai.Functions;
using Sinmai.Helper;
using UnityEngine;
using Manager;

namespace Sinmai.UI
{
    public class Menu : MonoBehaviour
    {
        private bool MenuToggle = true;
        private Rect Window;


        private void Start()
        {
            Window = new Rect(780, (float)(Screen.height * 0.234375), 300, 400);
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
                Render.DrawString(new Vector2(0, draw_y + 45), Settings.log, false);
            }


        }

        private void RenderMenu(int id)
        {
            switch (id)
            {
                // Menu
                case 0:
                    GUILayout.BeginVertical("MainToolbar", GUILayout.Height(20));
                    Settings.MainToolbarInt = GUILayout.Toolbar(Settings.MainToolbarInt, Settings.MainToolbarStrings);
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
                                Settings.LegitMethodInt = (Settings.LegitMethod)GUILayout.SelectionGrid((int)Settings.LegitMethodInt, System.Enum.GetNames(typeof(Settings.LegitMethod)), 1);
                                switch (Settings.LegitMethodInt)
                                {
                                    case Settings.LegitMethod.Weighted:
                                        GUILayout.Label($"Critical Value ({Settings.CriticalValue})");
                                        Settings.CriticalValue = GUILayout.HorizontalScrollbar(Settings.CriticalValue, 1.0f, 0.0f, 100.0f);
                                        GUILayout.Label($"Perfect Value ({Settings.PerfectValue})");
                                        Settings.PerfectValue = GUILayout.HorizontalScrollbar(Settings.PerfectValue, 1.0f, 0.0f, 100.0f);
                                        GUILayout.Label($"Great Value ({Settings.GreatValue})");
                                        Settings.GreatValue = GUILayout.HorizontalScrollbar(Settings.GreatValue, 1.0f, 0.0f, 100.0f);
                                        GUILayout.Label($"Good Value ({Settings.GoodValue})");
                                        Settings.GoodValue = GUILayout.HorizontalScrollbar(Settings.GoodValue, 1.0f, 0.0f, 100.0f);
                                        GUILayout.Label($"Miss Value ({Settings.MissValue})");
                                        Settings.MissValue = GUILayout.HorizontalScrollbar(Settings.MissValue, 1.0f, 0.0f, 100.0f);
                                        break;
                                    default:
                                        break;
                                }
                            }

                            GUILayout.Label("Native AutoPlay");
                            GameManager.AutoPlay = (GameManager.AutoPlayMode)GUILayout.Toolbar((int)GameManager.AutoPlay, System.Enum.GetNames(typeof(GameManager.AutoPlayMode)), GUILayout.Width(300));

                            GUILayout.Label("Native Random");
                            GUILayout.BeginHorizontal();
                            Settings.CriticalToggle = GUILayout.Toggle(Settings.CriticalToggle, "Critical", GUILayout.Width(100));
                            Settings.PerfectToggle = GUILayout.Toggle(Settings.PerfectToggle, "Perfect", GUILayout.Width(100));
                            Settings.GreatToggle = GUILayout.Toggle(Settings.GreatToggle, "Great", GUILayout.Width(100));
                            GUILayout.EndHorizontal();

                            GUILayout.BeginHorizontal();
                            Settings.GoodToggle = GUILayout.Toggle(Settings.GoodToggle, "Good", GUILayout.Width(100));
                            Settings.MissToggle = GUILayout.Toggle(Settings.MissToggle, "Miss", GUILayout.Width(100));
                            if (GUILayout.Button("Set", GUILayout.Width(100)))
                            {
                                AutoPlay.FullRandom();
                            }
                            GUILayout.EndHorizontal();


                            GUILayout.EndVertical();
                            break;
                        case 1:
                            GUILayout.BeginVertical("Misc");
                            // Misc
                            GUILayout.Label("Misc");
                            Settings.InfinityFreedomTimeCheckBox = GUILayout.Toggle(Settings.InfinityFreedomTimeCheckBox, "Infinity FreedomTime");
                            Settings.InfinityPrepareTimeCheckBox = GUILayout.Toggle(Settings.InfinityPrepareTimeCheckBox, "Infinity PrepareTime");

                            GUILayout.BeginHorizontal();
                            if (GUILayout.Button("Track Skip 1P"))
                                Track.ForceTrackSkip(0);
                            if (GUILayout.Button("Track Skip 2P"))
                                Track.ForceTrackSkip(1);
                            GUILayout.EndHorizontal();

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