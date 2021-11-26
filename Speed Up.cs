using MelonLoader;
using Assets.Scripts.Utils;
using Assets.Scripts.Unity.UI_New.Popups;
using UnityEngine;

namespace ClassLibrary2
{
    public class MyMod : MelonMod
    {

        public static int Speed = 3;
        public static int SlowAmount = 1;
        public static int Customspeed = 100;
        public static bool Slow = false;

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            System.Console.WriteLine("speed Mod Loaded");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (TimeManager.FastForwardActive)
            {
                TimeManager.timeScaleWithoutNetwork = Speed;
                TimeManager.networkScale = Speed;
            }
            else
            {
                TimeManager.timeScaleWithoutNetwork = 1;
                TimeManager.networkScale = 1;
            }

            int max;
            if (Speed == 3)
            {
                max = 3;
            }
            else
            {
                max = Speed * 2;
            }

            TimeManager.maxSimulationStepsPerUpdate = Slow ? SlowAmount : max;



            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Speed = 3;
                System.Console.WriteLine("speed = 3");
            }

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                Speed = 10;
                System.Console.WriteLine("Speed = 20");
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                Speed = 50;
                System.Console.WriteLine("speed = 100");
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    Speed = Customspeed;
                    System.Console.WriteLine("speed =" + Customspeed);
                }

                if (Input.GetKeyDown(KeyCode.F1) && Input.GetKey(KeyCode.LeftControl))
                {
                    Slow = !Slow;
                    System.Console.WriteLine("slow =" + Slow);
                }

                if (Input.GetKeyDown(KeyCode.F2) && Input.GetKey(KeyCode.LeftControl))
                {
                    SlowAmount = SlowAmount == 1 ? 2 : 1;
                    System.Console.WriteLine("slow amount =" + SlowAmount);
                }

                if (Input.GetKeyDown(KeyCode.F5))
                {
                    System.Action<int> deb = yourInteger => {
                        Customspeed = 5;
                        Speed = Customspeed;
                    };
                    PopupScreen.instance.ShowSetValuePopup("speed", "which speed ?", deb, 100);
                }
            }
            
            
        }
    }
}