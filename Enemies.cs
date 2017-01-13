using System;
using System.Collections.Generic;

namespace scary
{
        
    public class Enemy
    {
        public string name;

        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }

        //These properties are all private
        protected int strength { get; set; }
        protected int intelligence { get; set; }
        protected int dexterity { get; set; }
        
        public new string ToString(){
        return name + " is at " + health + " health!";
        }

        public Enemy(string monster)
        {
            name = monster;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 10;
        }

        public Enemy(string monster, int str, int intel, int dex, int hp)
        {
            name = monster;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }
            
            
        }
        public class Spider : Enemy{

            public Spider(string name): base(name){ 
                health = 5;
                intelligence = 15;
            }

            // public void heal(){
            //     health += (intelligence * 10);
            // }

            public void spit(object victim){
                Human enemy = victim as Human; //does this work or does it reset some of the default values??
                Random rnd = new Random();
                int damage = rnd.Next(0,11);
                enemy.health -= damage; //check if object has health??? something
            }
        }
        public class Zombie : Enemy{

            public Zombie(string name): base(name){ 
                health = 10;
                intelligence = 0;
            }

            // public void heal(){
            //     health += (intelligence * 10);
            // }

            public void bite(object victim){
                Human enemy = victim as Human; //does this work or does it reset some of the default values??
                Random rnd = new Random();
                int damage = rnd.Next(10,21);
                enemy.health -= damage; //check if object has health??? something

    }

}
}