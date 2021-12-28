using Terraria.ModLoader;

namespace ExtinctionTalesMod
{
    //Work in Progress
    public static class ExtinctionLocalization
    {
        private static string[][] _localization;

        public static void Load()
        {
            _localization = new string[3][]
            {
                new string[2]
                {
                    "BrillianceWarning",
                    "A light from the sky spread trough your world."
                },
                new string[2]
                {
                    "GraniteWarning",
                    "The Granite empowers."
                },
                new string[2]
                {
                    "MarbleWarning",
                    "The Ancient Marble recovers its essence."
                }
            };
        }

        public static void Unload()
        {
            _localization = null;
        }

        public static void AddLocalizations()
        {
            Load();
            string[][] localizations = _localization;
            foreach (string[] array in localizations)
            {
                ModTranslation val = ExtinctionMod.Instance.CreateTranslation(array[0]);
                val.SetDefault(array[1]);
                ExtinctionMod.Instance.AddTranslation(val);
            }
            Unload();
        }
    }
}