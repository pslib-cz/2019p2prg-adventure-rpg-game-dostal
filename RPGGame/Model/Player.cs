namespace RPGGame.Model
{
    public class Player : CommonStats
    {
        private int level;

        private int meleeFightingSkill;

        public int Level { get { return level;} set { if (level == default) { level = 1;} } }

        public int MeleeFightingSkill { get { return meleeFightingSkill; } set { if (meleeFightingSkill == default) { meleeFightingSkill = 1;} } }

        public int ForcePotential { get; set; }

    }
}
