#pragma once

class Node
{
public:
    float Data;
    Node* Previous = NULL;

    Node(float data)
    {
        Data = data;
    }

    Node() = default;
};