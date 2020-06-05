namespace RPGGame.Model
{
    public class Player : CommonStats
    {
        public int Level { get; set; } = 1;

        public int MeleeFightingSkill { get; set; } = 1;

        public int ForcePotential { get; set; }

    }
}
