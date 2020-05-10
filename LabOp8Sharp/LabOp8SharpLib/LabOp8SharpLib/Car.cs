using System;

namespace LabOp8SharpLib
{
    public class Car
    {
        private static double fuelSt;
        private static int speedSt;
        private double fuel;
        private int speed;
        public static event OverSpeedHandler Notify = (string message) => { Console.WriteLine(message); };
        public delegate void OverSpeedHandler(string message);

        public Car()
        {
            fuelSt = 0;
            speedSt = 0;
        }
        public Car(double fuel)
        {
            if (fuel < 0)
            {
                this.fuel = 0;
            }
            else
            {
                this.fuel = fuel;
            }
            this.speed = 0;
        }

        public void startMoving()
        {
            if (speed == 0)
            {
                if (fuel > 0)
                {
                    speed = 20;
                }
                else
                {
                    Console.WriteLine("Car fuel is out. You can't move");
                }
            }
            else
            {
                Console.WriteLine("You are alrady moving");
            }
        }

        public static void startMovingSt()
        {
            if (speedSt == 0)
            {
                if (fuelSt > 0)
                {
                    speedSt = 20;
                }
                else
                {
                    Console.WriteLine("Car fuel is out. You can't move");
                }
            }
            else
            {
                Console.WriteLine("You are alrady moving");
            }
        }

        public void move(int distance, int atSpeed)
        {
            if (atSpeed <= 0)
            {
                stopMoving();
                return;
            }
            else if (atSpeed > 60)
            {
                Notify?.Invoke("You have exceeded speed limit!");
                speed = 60;
            }
            else
            {
                speed = atSpeed;
            }
            for (int i = 0; i < distance; i++)
            {
                if (fuel < 0)
                {
                    fuel = 0;
                    stopMoving();
                    Console.WriteLine("Car fuel is out. You can't move");
                    break;
                }
                fuel -= fuelUsage(speed, 1);
            }
        }

        public static void moveSt(int distance, int atSpeed)
        {
            if (atSpeed <= 0)
            {
                speedSt = 0;
                return;
            }
            else if (atSpeed > 60)
            {
                Notify?.Invoke("You have exceeded speed limit!");
                speedSt = 60;
            }
            else
            {
                speedSt = atSpeed;
            }
            for (int i = 0; i < distance; i++)
            {
                if (fuelSt < 0)
                {
                    fuelSt = 0;
                    speedSt = 0;
                    Console.WriteLine("Car fuel is out. You can't move");
                    break;
                }
                fuelSt -= fuelUsageSt(speedSt, 1);
            }
        }
        public void stopMoving()
        {
            speed = 0;
        }

        public static void stopMovingSt()
        {
            speedSt = 0;
        }

        public void getFuel(int freshFuel)
        {
            if (freshFuel > 0)
            {
                fuel += freshFuel;
            }
        }

        public static void getFuelSt(int freshFuel)
        {
            if (freshFuel > 0)
            {
                fuelSt += freshFuel;
            }
        }

        public double fuelUsage(int speed, int distance)
        {
            return speed * distance * 0.004;
        }

        public static double fuelUsageSt(int speed, int distance)
        {
            return speed * distance * 0.004;
        }
    }
}
