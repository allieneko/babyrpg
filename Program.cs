using System;
using System.Threading;
using System.Collections.Generic;

namespace scary
{
    public class Human
{
    public string name;

    //The { get; set; } format creates accessor methods for the field specified
    //This is done to allow flexibility
    public int health { get; set; }

    //These properties are all private
    protected int strength { get; set; }
    protected int intelligence { get; set; }
    protected int dexterity { get; set; }

    public Human(string person)
    {
        name = person;
        strength = 3;
        intelligence = 3;
        dexterity = 3;
        health = 100;
    }

    public Human(string person, int str, int intel, int dex, int hp)
    {
        name = person;
        strength = str;
        intelligence = intel;
        dexterity = dex;
        health = hp;
    }

    public void attack(object obj)
    {
        Human enemy = obj as Human;
        if(enemy == null)
        {
            Console.WriteLine("Failed Attack");
        }
        else
        {
            enemy.health -= strength * 5;
        }
    }

    public new string ToString(){
        // return "Name: " + name +", strength: " + strength + ", intelligence: " + intelligence + ", dexterity: " + dexterity + ", health: "+ health;
        return name + " is at " + health + " health!";
    }
}

public class Wizard : Human{

    //Human constuctor is expecting a string so you don't need to define the parameter as a string here
    public Wizard(string name): base(name){ 
        health = 50;
        intelligence = 25;
    }

    public void heal(){
        health += (intelligence * 10);
    }

    public void fireball(object victim){
        Enemy enemy = victim as Enemy; //does this work or does it reset some of the default values??
        Random rnd = new Random();
        int damage = rnd.Next(20,51);
        enemy.health -= damage; //check if object has health??? something
    }
}

public class Ninja : Human{
    public Ninja(string name): base(name){ 
        dexterity = 175;
    }

    public void steal(object victim){
        Enemy enemy = victim as Enemy;
        enemy.health -= 10;
        health += 10;
    }

    public void get_away(){
        health -= 15;
    }
}

public class Samurai : Human{
    public Samurai(string name): base(name) {
        health = 200;
        instanceCount = instanceCount + 1;
    }

    public static int instanceCount;


    public void death_blow(object victim){
        Enemy enemy = victim as Enemy;
        if(enemy.health < 50){
            enemy.health = 0;
        }
    }

    public void meditate(){
        health = 200;
    }

    public void how_many(){
        Console.WriteLine("There are " + instanceCount + " Samurai!");

    }


}

    public class Program
    {
        public static void Main(string[] args)
        {

            Wizard harry = new Wizard("Harry");
            Ninja liz = new Ninja("Liz");
            Samurai allie = new Samurai("Allie");

            List<Human> Party = new List<Human>();
                Party.Add(allie);
                Party.Add(liz);
                Party.Add(harry);

            Spider nightmare = new Spider("Nightmare");
            Zombie billy = new Zombie("Billy");
            Zombie todd = new Zombie("Todd");
            
            List<Enemy> Enemies = new List<Enemy>();
                Enemies.Add(nightmare);
                Enemies.Add(billy);
                Enemies.Add(todd);

                Random rnd = new Random();



            // System.Console.WriteLine(nightmare.ToString());
            // System.Console.WriteLine(billy.ToString());

            System.Console.WriteLine("Your party has encountered some enemies!");
            for (var i=0; i < Enemies.Count; i++) {
                    System.Console.WriteLine("\t" + Enemies[i].name + ", a " + Enemies[i].GetType().Name + ", is at " + Enemies[i].health + "!");
                }

                System.Console.WriteLine("You're screwed! \nWho would you like to attack?");
                object targetInput = Console.ReadLine();
                Enemy partyVictim = targetInput as Enemy;

            System.Console.WriteLine("What do you want to do?");
            System.Console.WriteLine("\tLiz can steal and get_away,\n\tAllie can death_blow and meditate, and \n\tHarry can heal himself (sorry, he's not a team player) and fireball the enemy!");
            string InputLine = Console.ReadLine();


                // for (var i=0; i < Enemies.Count; i++) {
                //     System.Console.WriteLine(Enemies[i].name + ", a " + Enemies[i].GetType().Name + ", is at " + Enemies[i].health + "!");
                // }

                // System.Console.WriteLine("What would you like to attack?");
                // object targetInput = Console.ReadLine();


                System.Console.WriteLine("********************************");

            while (partyVictim.health > 0) {

                int target = rnd.Next(Party.Count);
                Human enemy_target = Party[target];
            
                if (InputLine == "steal") {
                    liz.steal(partyVictim);
                }
                else if (InputLine == "get_away") {
                    liz.get_away();
                }
                else if (InputLine == "death_blow") {
                    allie.death_blow(partyVictim);
                }

                else if (InputLine == "meditate") {
                    allie.meditate();
                }

                else if (InputLine == "heal") {
                    harry.heal();
                }

                else if (InputLine == "fireball") {
                    harry.fireball(partyVictim);
                }
                else {
                    System.Console.WriteLine("You should probably do something, you know, if you wanna live...");
                }
                

                if (partyVictim.health <= 0) {
                    System.Console.WriteLine("You are victorious against the " + partyVictim.name + "! But there are totally more things you need to kill...");
                    Enemies.Remove(partyVictim);
                    break;
                }

                System.Console.WriteLine(Enemies[0].name + "'s turn to attack!");

                System.Console.WriteLine(enemy_target.ToString());
                billy.bite(enemy_target);
                System.Console.WriteLine(enemy_target.name + " was bit! Ouch! Looks painful...");

                if (enemy_target.health <= 0) {
                    System.Console.WriteLine("Sucks to be you! " + enemy_target.name + " is totally dead.");
                    break;
                }



                System.Console.WriteLine("Ninjas can steal and get_away, Samurai can death_blow and meditate, and Wizard can heal (himself, sorry, he's not a team player) and fireball the enemy!");
                InputLine = Console.ReadLine();
                // System.Console.WriteLine(InputLine);



            }

            // System.Console.WriteLine(nightmare.ToString());
            
            
            
            
            }
            
        
    }
}

