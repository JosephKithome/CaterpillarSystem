/*using System;
using System.Numerics;

public class DirectionManager
{
    private CaterpillarSegment head;
    private CaterpillarSegment tail;
    private Planet planet;
    private Stack<(CaterpillarSegment, CaterpillarSegment)> commandHistory;

    public DirectionManager()
    {

    }
   *//* public DirectionManager(CaterpillarSegment head, CaterpillarSegment tail, Planet planet)
    {
        this.head = head;
        this.tail = tail;
        this.planet = planet;
        commandHistory = new Stack<(CaterpillarSegment, CaterpillarSegment)>();
    }*//*



    public void MoveDown(int steps)
    {
        // Move the caterpillar down and update the tail position if needed
        for (int i = 0; i < steps; i++)
        {
            if (head.X < planet.Map.GetLength(0) - 1 && planet.GetSymbolAtPosition(head.X + 1, head.Y) != '#')
            {
                planet.UpdateMap(head.X, head.Y, '.');
                head.X++;
                if (head.X == tail.X && head.Y == tail.Y)
                {
                    tail.X++;
                }
                planet.UpdateMap(head.X, head.Y, 'H');
            }
            else
            {
                break; // Hit obstacle, stop moving
            }
        }
    }


    public void MoveUp(int steps)
    {
        // Move the caterpillar up and update the tail position if needed
        Console.WriteLine("We moving up:: "+steps);
        for (int i = 0; i < steps; i++)
        {
            if (head.X > 0 && planet.GetSymbolAtPosition(head.X - 1, head.Y) != '#')
            {
                planet.UpdateMap(head.X, head.Y, '.');
                head.X--;
                if (head.X == tail.X && head.Y == tail.Y)
                {
                    tail.X--;
                }
                planet.UpdateMap(head.X, head.Y, 'H');
            }
            else
            {
                break; // Hit obstacle, stop moving
            }
        }
    }
    public void MoveLeft(int steps)
    {
        // Move the caterpillar left and update the tail position if needed
        for (int i = 0; i < steps; i++)
        {
            if (head.Y > 0 && planet.GetSymbolAtPosition(head.X, head.Y - 1) != '#')
            {
                planet.UpdateMap(head.X, head.Y, '.');
                head.Y--;
                if (head.X == tail.X && head.Y == tail.Y)
                {
                    tail.Y--;
                }
                planet.UpdateMap(head.X, head.Y, 'H');
            }
            else
            {
                break; // Hit obstacle, stop moving
            }
        }
    }


    public void MoveRight(int steps)
    {
        // Move the caterpillar right and update the tail position if needed
        for (int i = 0; i < steps; i++)
        {
            if (head.Y < planet.Map.GetLength(1) - 1 && planet.GetSymbolAtPosition(head.X, head.Y + 1) != '#')
            {
                planet.UpdateMap(head.X, head.Y, '.');
                head.Y++;
                if (head.X == tail.X && head.Y == tail.Y)
                {
                    tail.Y++;
                }
                planet.UpdateMap(head.X, head.Y, 'H');
            }
            else
            {
                break; // Hit obstacle, stop moving
            }
        }
    }

}
*/