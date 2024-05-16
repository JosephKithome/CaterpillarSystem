using CaterpillarSystem.utils;
using Newtonsoft.Json;
using System;

public class CaterpillarControlSystem
{
    private Planet planet;
    private Stack<(string, int)> commandHistory = new Stack<(string, int)>();
    private Stack<(string, int)> undoneCommands = new Stack<(string, int)>();
    public List<(int X, int Y)> segments;
    private int maxSegments;
    private LogHelper logHelper = new LogHelper();

    public (int X, int Y) Head => segments.Count > 0 ? segments[0] : (0, 0);

    public (int X, int Y) Tail => segments.Count > 0 ? segments[segments.Count - 1] : (0, 0);


    public CaterpillarControlSystem(Planet planet, int startX, int startY)
    {
        this.planet = planet;
        segments = new List<(int X, int Y)> { (startX, startY), (startX, startY) };
        commandHistory = new Stack<(string Direction, int Steps)>();
        undoneCommands = new Stack<(string Direction, int Steps)>();
        maxSegments = 5;
        planet.SetSymbolAtPosition(startX, startY, 'H');
        planet.SetSymbolAtPosition(startX, startY, 'T');
    }

    public void MoveCaterpillar(string direction, int steps)
    {
       

            switch (direction?.ToUpper())
            {
                case "U":
                    MoveUp(steps);
                    break;
                case "D":
                    MoveDown(steps);
                    break;
                case "L":
                    MoveLeft(steps);
                    break;
                case "R":
                    MoveRight(steps);
                    break;
                default:
                    break;
            }
        
       

    }


   private void MoveUp(int steps)
    {
        Console.WriteLine("Moving up...");
        for (int i = 0; i < steps; i++)
        {
            Console.WriteLine($"Step {i + 1} of {steps}");
            if (Head.Y > 0 && planet.GetSymbolAtPosition(Head.X, Head.Y - 1) != '#')
            {
                Console.WriteLine("Can move up.");
                MoveHeadTo(Head.X, Head.Y - 1);
            }
            else
            {
                Console.WriteLine("Cannot move up.");
            }
        }
        planet.PrintMap();
        PrintCaterpillar();
        HandleInteractions();
        DisplayRadarImage();
    }

    private void MoveDown(int steps)
    {
        Console.WriteLine("Moving down...");
        for (int i = 0; i < steps; i++)
        {
            Console.WriteLine($"Step {i + 1} of {steps}");
            if (Head.Y < planet.GetMap().GetLength(0) - 1 && planet.GetSymbolAtPosition(Head.X, Head.Y + 1) != '#')
            {
                Console.WriteLine("Can move down.");
                MoveHeadTo(Head.X, Head.Y + 1);
            }
            else
            {
                Console.WriteLine("Cannot move down: obstacle or reached boundary.");
            }
        }
        planet.PrintMap();
        PrintCaterpillar();
        HandleInteractions();
        DisplayRadarImage();
    }

    private void MoveLeft(int steps)
    {
        Console.WriteLine("Moving left...");
        for (int i = 0; i < steps; i++)
        {
            Console.WriteLine($"Step {i + 1} of {steps}");
            if (Head.X > 0 && planet.GetSymbolAtPosition(Head.X - 1, Head.Y) != '#')
            {
                Console.WriteLine("Can move left.");
                MoveHeadTo(Head.X - 1, Head.Y);
            }
            else
            {
                Console.WriteLine("Cannot move left: obstacle or reached boundary.");
            }
        }
        planet.PrintMap();
        PrintCaterpillar();
        HandleInteractions();
        DisplayRadarImage();
    }

    private void MoveRight(int steps)
    {
        Console.WriteLine("Moving right...");
        for (int i = 0; i < steps; i++)
        {
            Console.WriteLine($"Step {i + 1} of {steps}");
            if (Head.X < planet.GetMap().GetLength(1) - 1 && planet.GetSymbolAtPosition(Head.X + 1, Head.Y) != '#')
            {
                Console.WriteLine("Can move right.");
                MoveHeadTo(Head.X + 1, Head.Y);
            }
            else
            {
                Console.WriteLine("Cannot move right: obstacle or reached boundary.");
            }
        }
        planet.PrintMap();
        PrintCaterpillar();
        HandleInteractions();
        DisplayRadarImage();
    }



    private void MoveHeadTo(int newX, int newY)
    {
        if (!IsValidPosition(newX, newY)) return;

        var tail = Tail;
        segments.Insert(0, (newX, newY));
        segments.RemoveAt(segments.Count - 1);
        planet.SetSymbolAtPosition(tail.X, tail.Y, '*');
        planet.SetSymbolAtPosition(newX, newY, 'H');
        planet.SetSymbolAtPosition(segments[segments.Count - 1].X, segments[segments.Count - 1].Y, 'T');
        HandleInteractions();
        DisplayRadarImage();
    }

    private bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < planet.GetMap().GetLength(1) && y >= 0 && y < planet.GetMap().GetLength(0);
    }

    public void PrintCaterpillar()
    {
        foreach (var segment in segments)
        {
            Console.Write($"The Caterpillar({segment.X}, {segment.Y}) ");
        }
        Console.WriteLine();
    }

    public void HandleInteractions()
    {
        char symbol = planet.GetSymbolAtPosition(Head.X, Head.Y);

        switch (symbol)
        {
            case '$':
                HandleSpice();
                break;
            case 'B':
                HandleBooster();
                break;
            case '#':
                HandleObstacle();
                break;
            default:
                break;
        }
    }


    public void HandleSpice()
    {
        // Ingest spice and remove it from the planet
        planet.SetSymbolAtPosition(Head.X, Head.Y, '*');
    }

    public void HandleBooster()
    {
        if (segments.Count < maxSegments)
        {
            segments.Add(Tail); // Grow the caterpillar by adding a new segment
        }
        // Remove the booster from the planet
        planet.SetSymbolAtPosition(Head.X, Head.Y, '*');
    }

    public void HandleObstacle()
    {
        // If any segment of the caterpillar hits an obstacle, disintegrate all segments
        foreach (var segment in segments)
        {
            planet.SetSymbolAtPosition(segment.X, segment.Y, '*');
        }
        segments.Clear();
    }

    public void ShrinkCaterpillar()
    {
        if (segments.Count > 2)
        {
            segments.RemoveAt(segments.Count - 1); // Remove the last segment
        }
    }

    public void Undo()
    {
        if (commandHistory.Count > 0)
        {
            var lastCommand = commandHistory.Pop();
            undoneCommands.Push(lastCommand);

            // Undo the last command
            switch (lastCommand.Item1)
            {
                case "U":
                    MoveDown(lastCommand.Item2); // Move opposite direction
                    break;
                case "D":
                    MoveUp(lastCommand.Item2);
                    break;
                case "L":
                    MoveRight(lastCommand.Item2);
                    break;
                case "R":
                    MoveLeft(lastCommand.Item2);
                    break;
                default:
                    break;
            }
            HandleInteractions();
            DisplayRadarImage();
        }
    }

    public void Redo()
    {
        if (undoneCommands.Count > 0)
        {
            var lastUndoneCommand = undoneCommands.Pop();
            commandHistory.Push(lastUndoneCommand);

            // Redo the last undone command
            switch (lastUndoneCommand.Item1)
            {
                case "U":
                    MoveUp(lastUndoneCommand.Item2);
                    break;
                case "D":
                    MoveDown(lastUndoneCommand.Item2);
                    break;
                case "L":
                    MoveLeft(lastUndoneCommand.Item2);
                    break;
                case "R":
                    MoveRight(lastUndoneCommand.Item2);
                    break;
                default:
                    break;
            }
            HandleInteractions();
            DisplayRadarImage();
        }
    }

    public void DisplayRadarImage()
    {

        Console.WriteLine("Displaying radar Image");
        int radarDiameter = 11;
        int startX = Head.X - (radarDiameter / 2);
        int startY = Head.Y - (radarDiameter / 2);

        for (int y = startY; y < startY + radarDiameter; y++)
        {
            for (int x = startX; x < startX + radarDiameter; x++)
            {
                if (IsValidPosition(x, y))
                {
                    Console.Write(planet.GetSymbolAtPosition(x, y) + " ");
                }
                else
                {
                    Console.Write(" "); // Empty space if out of bounds
                }
            }
            Console.WriteLine();
        }
    }

    public void LogCommand(string direction, int steps)
    {
        commandHistory.Push((direction, steps));

        string log = JsonConvert.SerializeObject(commandHistory);
        logHelper.WriteToLogger(log);
    }




}


