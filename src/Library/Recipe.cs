//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic; // Agrega este using
using System.Linq; // También necesitarás este using para el método Sum

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private List<Step> steps = new List<Step>(); // Cambia ArrayList a List<Step>

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public double GetProductionCost()
        {
            double costInsumos = this.steps.Sum(step => step.Input.UnitCost * step.Quantity);
            double costEquipamiento = this.steps.Sum(step => step.Equipment.HourlyCost * (step.Time / 60));
            return costInsumos + costEquipamiento;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }

            double productionCost = this.GetProductionCost(); // Calcula el costo total de producción.
            Console.WriteLine($"Costo total de producción: ${productionCost}");
        }
    }
}