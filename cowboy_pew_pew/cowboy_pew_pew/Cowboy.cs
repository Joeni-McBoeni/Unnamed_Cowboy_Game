using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cowboy_pew_pew
{
    class Cowboy
    {
        private int myHealth;
        private int myBullets;
        private int myPrimaryAbilityId;
        private int mySecondaryAbilityId;
        private int myCurrentAction;

        // Standard-Cowboy definieren
        public Cowboy()
        {
            this.myHealth = 3;
            this.myBullets = 2;
            this.myPrimaryAbilityId = -1;
            this.mySecondaryAbilityId = -1;
            this.myCurrentAction = 0;
        }

        // Custom Cowboy definieren
        public Cowboy(int health, int bullets, int primaryAbilityId, int secondaryAbilityId)
        {
            this.myHealth = health;
            this.myBullets = bullets;
            this.myPrimaryAbilityId = primaryAbilityId;
            this.mySecondaryAbilityId = secondaryAbilityId;
            this.myCurrentAction = 0;
        }

        // Kampfresultate
        public void combat(Cowboy enemy, bool enemyAbleToShoot)
        {
            switch (myCurrentAction)
            {
                case 1:
                    if (myBullets != 0)
                    {
                        myBullets--;
                        if (enemy.myCurrentAction != 2)
                        {
                            enemy.myHealth--;
                        }
                    }
                    break;
                case 3:
                    if (myBullets != 6)
                    {
                        myBullets++;
                    }
                    break;
                case 4:
                    if (enemy.currentAction == 1 && enemyAbleToShoot == true)
                    {
                        myHealth--;
                    }
                    if (myHealth != 6)
                    {
                        myHealth++;
                    }
                    break;
                default:
                    break;
            }
        }

        // Get- und Set-Properties
        
        public int health
        {
            get { return myHealth; }
        }

        public int bullets
        {
            get { return myBullets; }
        }

        public int currentAction
        {
            get { return myCurrentAction; }
            set { this.myCurrentAction = value; }
        }
    }
}
