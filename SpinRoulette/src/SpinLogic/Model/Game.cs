using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpinLogic.Model
{
    public class Game
    {
        public Game(string gameId, uint cylinderSize, uint bulletPositon)
        {
            GameId = gameId;
            InitGame(cylinderSize, bulletPositon);
        }

        public void InitGame(uint bulletPositon)
        {
            InitGame((uint)(Cylinder.Length), bulletPositon);
        }

        public void InitGame(uint cylinderSize, uint bulletPositon)
        {
            CurrentTriggerPosition = -1;
            if (bulletPositon > cylinderSize - 1) {
                throw new Exception("Somethings wrong the bulletPositon is higher than size of the cylinder");
            }
            
            Cylinder = new BulletHole[cylinderSize];

            // set the bulletholes in the cylinder
            for (int cylIndex = 0; cylIndex < cylinderSize - 1; cylIndex++)
            {
                if (cylIndex == bulletPositon)
                {
                    Cylinder[cylIndex] = BulletHole.ContainsBullet;
                    continue;
                }

                Cylinder[cylIndex] = BulletHole.Empty;
            }
        }

        public int CurrentTriggerPosition { get; set; }

        public string GameId { get; set; }
        public uint NumberOfTiggerPulls {
            get
            {
                uint numberOfPulls = 0;
                foreach (var hole in Cylinder) {
                    if (hole == BulletHole.Fired) {
                        numberOfPulls++;
                    }
                }
                return numberOfPulls;
            }
        }
        public uint CylinderSize {
            get {
                return (uint)(Cylinder.Length);
            }
        }

        public BulletHole[] Cylinder { get; set; }
    }
}
