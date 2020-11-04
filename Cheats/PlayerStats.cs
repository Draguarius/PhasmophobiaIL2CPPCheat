using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMod.Cheats
{
    public class PlayerStats
    {
        public static void SetItemCount(string item, int count)
        {
            FileBasedPrefs.SetInt(item, count);
        }

        public static void SetPlayerLevel(int newLevel)
        {
            FileBasedPrefs.SetInt("myTotalExp", newLevel * 100);
            FileBasedPrefs.SetInt("totalExp", newLevel * 100);

            UpdateViews();
        }

        public static void SetPlayerMoney(int newMoney)
        {
            FileBasedPrefs.SetInt("PlayersMoney", newMoney);

            UpdateViews();
        }

        private static void UpdateViews()
        {
            var statsManager = UnityEngine.Object.FindObjectOfType<PlayerStatsManager>();

            statsManager.UpdateExperience();
            statsManager.UpdateLevel();
            statsManager.UpdateMoney();
        }
    }
}
