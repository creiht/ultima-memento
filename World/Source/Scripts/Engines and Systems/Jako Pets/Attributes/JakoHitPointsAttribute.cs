﻿namespace Custom.Jerbal.Jako
{
    public class JakoHitPointsAttribute : JakoBaseAttribute
    {
        public override double CapScale { get { return 1.25; } }
        public override uint AttributesGiven { get { return 10; } }
        public override uint Cap { get { return 550; } }
        public override uint PointsTaken { get { return 1; } }

        public override uint GetStat(Server.Mobiles.BaseCreature bc)
        {
            return (uint)bc.HitsMax;
        }

        protected override void SetStat(Server.Mobiles.BaseCreature bc, uint toThis)
        {
            var delta = (int)(toThis - bc.HitsMaxSeed);

            bc.HitsMaxSeed = (int)toThis;
            
            if (0 < delta)
                bc.Heal(delta);
        }

        public override string ToString()
        {
            return "Hits";
        }
    }
}
