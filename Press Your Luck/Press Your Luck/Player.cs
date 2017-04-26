/** Group Members: Clarence Williams and Rephael Edwards
 * Date: 10-6-2016
   Class: CMPS 4143
   Professor: Dr. Catherine Stringfellow
 * Description: This file contains the definition of the class Player
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Press_Your_Luck
{
    class Player
    {
        //variable declarations
        private int money;
        private int spins;

        //constructor
        public Player()
        {
            money = 0;
            spins = 0;
        }

        //destructor
        ~Player()
        {
        }

        //Purpose:To take all of the players money when a whammy is won
        //Precond:None
        //Postcond:Money gets set to zero
        public void whammy()
        {
            money = 0;
        }

        //Purpose:To return the amount of money that the player has
        //Precond:None
        //Postcond:Money is returned
        public int getMoney()
        {
            return money;
        }

        //Purpose:To add money to the variable money by a proper amount
        //Precond:temp must be initialized
        //Postcond:Money is changed
        public void setMoney(int temp)
        {
            if ((money + temp) < 0)
                money = 0;
            else
                money += temp;
        }

        //Purpose:To return spins
        //Precond:None
        //Postcond:Spins is returned
        public int getSpins()
        {
            return spins;
        }

        //Purpose:To set spins
        //Precond:temp must be initialized
        //Postcond:Spins is changed
        public void setSpins(int temp)
        {
            spins += temp;
        }

        //Purpose:To set spins to zero
        //Precond:None
        //Postcond:spins is set to zero
        public void clearSpins()
        {
            spins = 0;
        }

        //Purpose:To decrement spins
        //Precond:None
        //Postcond:spins has been decreased by 1
        public void decSpins()
        {
            spins--;
        }

        //Purpose:To increment spins
        //Precond:None
        //Postcond:spins has been increased by 1
        public void incSpins()
        {
            spins++;
        }

        //Purpose:To compare another players money with the player's money
        //Precond:temp must be initialized
        //Postcond:A bool is returned
        public bool isRicher(Player temp)
        {
            if (money > temp.money)
                return true;
            else
                return false;
        }

        //Purpose:To check if the player is out of spins
        //Precond:None
        //Postcond:A bool is returned
        public bool isOutOfSpins()
        {
            if (spins <= 0)
                return true;
            else
                return false;
        }
    }
}
