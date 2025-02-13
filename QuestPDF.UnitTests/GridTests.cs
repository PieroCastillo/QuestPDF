﻿using FluentAssertions;
using NUnit.Framework;
using QuestPDF.Elements;
using QuestPDF.Fluent;
using QuestPDF.UnitTests.TestEngine;

namespace QuestPDF.UnitTests
{
    [TestFixture]
    public class GridTests
    {
        #region Alignment
        
        [Test]
        public void AlignLeft()
        {
            // arrange
            var structure = new Container();

            var childA = TestPlan.CreateUniqueElement();
            var childB = TestPlan.CreateUniqueElement();
            var childC = TestPlan.CreateUniqueElement();
            var childD = TestPlan.CreateUniqueElement();
            var childE = TestPlan.CreateUniqueElement();

            // act
            structure
                .Grid(grid =>
                {
                    grid.AlignLeft();
                    
                    grid.Item(6).Element(childA);
                    grid.Item(4).Element(childB);
                    grid.Item(4).Element(childC);
                    grid.Item(2).Element(childD);
                    grid.Item(8).Element(childE);
                });
            
            // assert
            var expected = new Container();
            
            expected.Stack(stack =>
            {
                stack.Item().Row(row =>
                {
                    row.RelativeColumn(6).Element(childA);
                    row.RelativeColumn(4).Element(childB);
                    row.RelativeColumn(2);
                });
                
                stack.Item().Row(row =>
                {
                    row.RelativeColumn(4).Element(childC);
                    row.RelativeColumn(2).Element(childD);
                    row.RelativeColumn(6);
                });
                
                stack.Item().Row(row =>
                {
                    row.RelativeColumn(8).Element(childE);
                    row.RelativeColumn(4);
                });
            });
            
            TestPlan.CompareOperations(structure, expected);
        }
        
        [Test]
        public void AlignCenter()
        {
            // arrange
            var structure = new Container();

            var childA = TestPlan.CreateUniqueElement();
            var childB = TestPlan.CreateUniqueElement();
            var childC = TestPlan.CreateUniqueElement();
            var childD = TestPlan.CreateUniqueElement();
            var childE = TestPlan.CreateUniqueElement();

            // act
            structure
                .Grid(grid =>
                {
                    grid.AlignCenter();
                    
                    grid.Item(6).Element(childA);
                    grid.Item(4).Element(childB);
                    grid.Item(4).Element(childC);
                    grid.Item(2).Element(childD);
                    grid.Item(8).Element(childE);
                });
            
            // assert
            var expected = new Container();
            
            expected.Stack(stack =>
            {
                stack.Item().Row(row =>
                {
                    row.RelativeColumn(1);
                    row.RelativeColumn(6).Element(childA);
                    row.RelativeColumn(4).Element(childB);
                    row.RelativeColumn(1);
                });
                
                stack.Item().Row(row =>
                {
                    row.RelativeColumn(3);
                    row.RelativeColumn(4).Element(childC);
                    row.RelativeColumn(2).Element(childD);
                    row.RelativeColumn(3);
                });
                
                stack.Item().Row(row =>
                {
                    row.RelativeColumn(2);
                    row.RelativeColumn(8).Element(childE);
                    row.RelativeColumn(2);
                });
            });

            TestPlan.CompareOperations(structure, expected);
        }
        
        [Test]
        public void AlignRight()
        {
            // arrange
            var structure = new Container();

            var childA = TestPlan.CreateUniqueElement();
            var childB = TestPlan.CreateUniqueElement();
            var childC = TestPlan.CreateUniqueElement();
            var childD = TestPlan.CreateUniqueElement();
            var childE = TestPlan.CreateUniqueElement();

            // act
            structure
                .Grid(grid =>
                {
                    grid.AlignRight();
                    
                    grid.Item(6).Element(childA);
                    grid.Item(4).Element(childB);
                    grid.Item(4).Element(childC);
                    grid.Item(2).Element(childD);
                    grid.Item(8).Element(childE);
                });
            
            // assert
            var expected = new Container();
            
            expected.Stack(stack =>
            {
                stack.Item().Row(row =>
                {
                    row.RelativeColumn(2);
                    row.RelativeColumn(6).Element(childA);
                    row.RelativeColumn(4).Element(childB);
                });
                
                stack.Item().Row(row =>
                {
                    row.RelativeColumn(6);
                    row.RelativeColumn(4).Element(childC);
                    row.RelativeColumn(2).Element(childD);
                });
                
                stack.Item().Row(row =>
                {
                    row.RelativeColumn(4);
                    row.RelativeColumn(8).Element(childE);
                });
            });
            
            TestPlan.CompareOperations(structure, expected);
        }
        
        #endregion
        
        #region Spacing
        
        [Test]
        public void Spacing()
        {
            // arrange
            var structure = new Container();

            var childA = TestPlan.CreateUniqueElement();
            var childB = TestPlan.CreateUniqueElement();
            var childC = TestPlan.CreateUniqueElement();
            var childD = TestPlan.CreateUniqueElement();

            // act
            structure
                .Grid(grid =>
                {
                    grid.Columns(16);
                    grid.AlignCenter();
                    
                    grid.VerticalSpacing(20);
                    grid.HorizontalSpacing(30);

                    grid.Item(5).Element(childA);
                    grid.Item(5).Element(childB);
                    grid.Item(10).Element(childC);
                    grid.Item(12).Element(childD);
                });
            
            // assert
            var expected = new Container();
            
            expected.Stack(stack =>
            {
                stack.Spacing(20);
                
                stack.Item().Row(row =>
                {
                    row.Spacing(30);
                    
                    row.RelativeColumn(3);
                    row.RelativeColumn(5).Element(childA);
                    row.RelativeColumn(5).Element(childB);
                    row.RelativeColumn(3);
                });
                
                stack.Item().Row(row =>
                {
                    row.Spacing(30);
                    
                    row.RelativeColumn(3);
                    row.RelativeColumn(10).Element(childC);
                    row.RelativeColumn(3);
                });
                
                stack.Item().Row(row =>
                {
                    row.Spacing(30);
                    
                    row.RelativeColumn(2);
                    row.RelativeColumn(12).Element(childD);
                    row.RelativeColumn(2);
                });
            });
            
            TestPlan.CompareOperations(structure, expected);
        }
        
        #endregion
    }
}