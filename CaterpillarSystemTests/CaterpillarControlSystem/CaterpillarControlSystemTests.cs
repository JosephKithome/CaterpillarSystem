﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class CaterpillarControlSystemTests
    {

        char[,] map = new char[,]
       {
            { '$', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '$', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '#', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '#' },
            { '*', '*', '*', '#', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '$', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '$', '$', '*', '*', '*', '#', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '$', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '$', '*', '*', '*', '*', '*', '$', '*', '*', '*', '*', '*', '*', '#', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '$', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '#', '*', '*', '*', '*', '$', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', 'B', '*', '*', '*', '*', '*', '*', '*', '*', '$', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '$', '*', '*', 'B', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '$', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '#', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '$', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '#', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' },
            { 's', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' }
       };
        [TestMethod()]
        public void MoveCaterpillar_ValidMove_Success()
        {
            // Arrange
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);

            // Act
            caterpillar.MoveCaterpillar("U", 1);

            // Assert
            Assert.AreEqual((5, 4), caterpillar.Head, "Head should have moved up by 1 step.");
        }

        [TestMethod()]
        public void MoveCaterpillar_InvalidMove_Fail()
        {
            // Arrange
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 0, 0);

            // Act
            caterpillar.MoveCaterpillar("L", 1);

            // Assert
            Assert.AreEqual((0, 0), caterpillar.Head, "Head should not have moved left due to boundary.");
        }

        [TestMethod()]
        public void Redo_UndoLastMove_Success()
        {
            // Arrange
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);
            caterpillar.MoveCaterpillar("U", 2);
            caterpillar.Undo();

            // Act
            caterpillar.Redo();

            // Assert
            Assert.AreEqual((5, 3), caterpillar.Head, "Caterpillar head should have moved forward to the position before undo.");
        }

        [TestMethod()]
        public void DisplayRadarImage_ValidRadar_Success()
        {
            // Arrange
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);

            // Act & Assert
            // No easy way to test console output, so no direct assertion here
            caterpillar.DisplayRadarImage();
        }


        [TestMethod]
        public void ShrinkCaterpillar_Shrink_Success()
        {
            // Arrange
            char[,] map = new char[10, 10]; // Assuming map is defined as a 2D char array
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);

            // Move the caterpillar to create multiple segments
            caterpillar.MoveCaterpillar("U", 3); // This should create 4 segments

            // Act
            caterpillar.ShrinkCaterpillar();

            // Assert
            Assert.AreEqual(3, caterpillar.segments.Count, "Caterpillar should have shrunk by 1 segment.");
        }

        [TestMethod()]
        public void PrintCaterpillarTest()
        {
            // Arrange
            char[,] map = new char[10, 10]; // Assuming map is defined as a 2D char array
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);

            // Act & Assert
            // No easy way to test console output, so no direct assertion here
            caterpillar.PrintCaterpillar();
        }

        [TestMethod()]
        public void HandleInteractionsTest()
        {
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);

            // Act
            caterpillar.HandleInteractions();

        }

        [TestMethod()]
        public void HandleSpiceTest()
        {
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);
            planet.SetSymbolAtPosition(5, 5, '$');

            // Act
            caterpillar.HandleSpice();

            // Assert
            Assert.AreEqual('*', planet.GetSymbolAtPosition(5, 5), "Spice should have been ingested.");
        }

        [TestMethod()]
        public void HandleBoosterTest()
        {
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);
            planet.SetSymbolAtPosition(5, 5, 'B');

            // Act
            caterpillar.HandleBooster();

            // Assert
            Assert.AreEqual(3, caterpillar.segments.Count, "Caterpillar should have grown by 1 segment.");
        }

        [TestMethod()]
        public void HandleObstacleTest()
        {
       
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);
            planet.SetSymbolAtPosition(5, 5, '#');

            // Act
            caterpillar.HandleObstacle();

            // Assert
            Assert.AreEqual(0, caterpillar.segments.Count, "Caterpillar should have disintegrated.");
        }

        [TestMethod]
        public void ShrinkCaterpillarTest()
        {
            // Arrange
            char[,] map = new char[10, 10]; // Assuming map is defined as a 2D char array
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);

            // Initial segments should contain the starting position
            Assert.AreEqual(1, caterpillar.segments.Count, "Initial segment count should be 1.");

            // Move the caterpillar to create segments
            caterpillar.MoveCaterpillar("U", 3); // This should create 4 segments

            // Assert the segments count after moving
            Assert.AreEqual(4, caterpillar.segments.Count, "Segment count after moving up 3 steps should be 4.");

            // Act
            caterpillar.ShrinkCaterpillar();

            // Assert
            Assert.AreEqual(3, caterpillar.segments.Count, "Caterpillar should have shrunk by 1 segment.");
        }




        [TestMethod()]
        public void RedoTest()
        {
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);
            caterpillar.MoveCaterpillar("U", 2);
            caterpillar.Undo();

            // Act
            caterpillar.Redo();

            // Assert
            Assert.AreEqual((5, 3), caterpillar.Head, "Caterpillar head should have moved forward to the position before undo.");
        }

        [TestMethod()]
        public void DisplayRadarImageTest()
        {
            Planet planet = new Planet(map);
            CaterpillarControlSystem caterpillar = new CaterpillarControlSystem(planet, 5, 5);
            caterpillar.DisplayRadarImage();
        }








    }
}