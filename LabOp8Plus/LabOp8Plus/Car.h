#pragma once
#include <iostream>
#include <string>

using namespace std;

void(*SpeedLimitHandler)(string message);

void DisplayMessage(string message)
{
    cout << message << endl;
}

class Car
{
    double fuel;
    int speed;
public:
    Car(double fuel)
    {
        if (fuel < 0)
        {
            this->fuel = 0;
        }
        else
        {
            this->fuel = fuel;
        }
        this->speed = 0;
    }

    void startMoving()
    {
        if (speed == 0)
        {
            if (fuel > 0)
            {
                speed = 20;
            }
            else
            {
                cout << "Car fuel is out. You can't move" << endl;
            }
        }
        else
        {
            cout << "You are alrady moving" << endl;
        }
    }

    void move(int distance, int atSpeed)
    {
        if (atSpeed <= 0)
        {
            stopMoving();
            return;
        }
        else if (atSpeed > 60)
        {
            SpeedLimitHandler = DisplayMessage;
            SpeedLimitHandler("You have exceeded speed limit!");
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
                cout << "Car fuel is out. You can't move" << endl;
                break;
            }
            fuel -= fuelUsage(speed, 1);
        }
    }

    void stopMoving()
    {
        speed = 0;
    }

    void getFuel(int freshFuel)
    {
        if (freshFuel > 0)
        {
            fuel += freshFuel;
        }
    }


    double fuelUsage(int speed, int distance)
    {
        return speed * distance * 0.004;
    }

};

