﻿using QuestPDF.Drawing.SpacePlan;
using QuestPDF.Elements;
using QuestPDF.Infrastructure;

namespace QuestPDF.UnitTests.TestEngine
{
    internal static class SimpleContainerTests
    {
        #region measure
        
        public static void Measure<TElement>() where TElement : Element, IContainer, new()
        {
            Measure_Wrap<TElement>();
            Measure_PartialRender<TElement>();
            Measure_FullRender<TElement>();
        }
        
        private static void Measure_Wrap<TElement>() where TElement : Element, IContainer, new()
        {
            TestPlan
                .For(x => new TElement
                {
                    Child = x.CreateChild()
                })
                .MeasureElement(new Size(400, 300))
                .ExpectChildMeasure(new Size(400, 300), new Wrap())
                .CheckMeasureResult(new Wrap());
        }
        
        private static void Measure_PartialRender<TElement>() where TElement : Element, IContainer, new()
        {
            TestPlan
                .For(x => new TElement
                {
                    Child = x.CreateChild()
                })
                .MeasureElement(new Size(400, 300))
                .ExpectChildMeasure(new Size(400, 300), new PartialRender(200, 100))
                .CheckMeasureResult(new PartialRender(200, 100));
        }
        
        private static void Measure_FullRender<TElement>() where TElement : Element, IContainer, new()
        {
            TestPlan
                .For(x => new TElement
                {
                    Child = x.CreateChild()
                })
                .MeasureElement(new Size(400, 300))
                .ExpectChildMeasure(new Size(400, 300), new FullRender(250, 150))
                .CheckMeasureResult(new FullRender(250, 150));
        }
        
        #endregion
        
        public static void Draw<TElement>() where TElement : Element, IContainer, new()
        {
            TestPlan
                .For(x => new TElement
                {
                    Child = x.CreateChild()
                })
                .DrawElement(new Size(1200, 900))
                .ExpectChildDraw(new Size(1200, 900))
                .CheckDrawResult();
        }
    }
}