#pragma once
#include <iostream>
#include "Node.h"

class Collection
{
    Node* head = nullptr;
    Node* tail = nullptr;
public:

    Collection(float data)
    {
        Push(data);
    }


    Collection(float data[], int size)
    {
        for (int i = 0; i < size; i++)
        {
            Push(data[i]);
        }
    }

    void Push(float data)
    {
        Node* temp = new Node(data);
        Node* temp1 = NULL;
        if (tail == NULL)
        {
            tail = temp;
        }
        else
        {
            temp1 = head;
        }
        head = temp;
        head->Previous = temp1;
    }

    float CalcSum()
    {
        Node* current = head;
        float sum = 0;
        int counter = 0;
        while (current != NULL)
        {

            sum += current->Data;
            current = current->Previous;
            counter++;
        }
        return sum / counter;
    }

    int CalcNumberOfNumbers(float sum)
    {
        Node* current = head;
        int counter = 0;
        while (current != NULL)
        {
            if (current->Data > sum)
            {
                counter++;
            }
            current = current->Previous;
        }
        return counter;
    }

    bool Pop(float data)
    {
        bool breaker = false;
        while (true)
        {
            Node* current = head;
            Node* temp = NULL;
            while (current != NULL)
            {
                if (current->Data == data)
                {
                    break;
                }
                temp = current;
                current = current->Previous;
            }

            if (current != NULL)
            {
                if (current == head)
                {
                    head = head->Previous;
                }
                else if (current->Previous == NULL)
                {
                    temp->Previous = NULL;
                }
                else
                {
                    temp->Previous = current->Previous;
                }
                breaker = true;
            }
            else return breaker;
        }
    }

    void ExcludeNegativeNumbers()
    {
        Node* current = head;
        while (current != NULL)
        {
            if (current->Data < 0) Pop(current->Data);
            current = current->Previous;
        }
    }
};