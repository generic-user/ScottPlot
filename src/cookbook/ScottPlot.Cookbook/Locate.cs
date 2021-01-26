﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ScottPlot.Cookbook
{
    public static class Locate
    {
        public static IRecipe[] GetRecipes() =>
            AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(x => x.IsAbstract == false)
            .Where(x => x.IsInterface == false)
            .Where(p => typeof(IRecipe).IsAssignableFrom(p))
            .Select(x => (IRecipe)Activator.CreateInstance(x))
            .ToArray();

        public static IRecipe GetRecipe(string id) => GetRecipes().Where(x => x.ID == id).First();

        public static string[] GetCategories() => GetRecipes().Select(x => x.Category).Distinct().ToArray();

        public static IRecipe[] GetRecipes(string category) => GetRecipes().Where(x => x.Category == category).ToArray();

        public static List<KeyValuePair<string, IRecipe[]>> GetCategorizedRecipes()
        {
            var categorizedRecipeList = new List<KeyValuePair<string, IRecipe[]>>();

            foreach (string category in GetCategories())
            {
                var recipesForCategory = new KeyValuePair<string, IRecipe[]>(category, GetRecipes(category));
                categorizedRecipeList.Add(recipesForCategory);
            }

            string[] topCategories =
            {
                "Quickstart",
                "Axis and Ticks",
                "Advanced Axis Features",
                "Multi-Axis",
            };

            foreach (string category in topCategories.Reverse())
            {
                var moveThis = categorizedRecipeList.Where(x => x.Key == category).First(); ;
                categorizedRecipeList.Remove(moveThis);
                categorizedRecipeList.Insert(0, moveThis);
            }

            string[] bottomCategories =
            {
                "Style",
                "Misc"
            };

            foreach (string category in bottomCategories)
            {
                var moveThis = categorizedRecipeList.Where(x => x.Key == category).First(); ;
                categorizedRecipeList.Remove(moveThis);
                categorizedRecipeList.Add(moveThis);
            }

            return categorizedRecipeList;
        }

        public static string RecipeSourceCode(string id)
        {
            string[] possiblePaths = {
                "cookbook/source", // same folder as this EXE
                "../../../../../tests/bin/Debug/net5.0/cookbook/source", // tests output if we are running from VS
            };

            StringBuilder sb = new StringBuilder();
            foreach (string possiblePath in possiblePaths)
            {
                string recipeSourceFile = System.IO.Path.Combine(possiblePath, id + ".cs");
                recipeSourceFile = System.IO.Path.GetFullPath(recipeSourceFile);
                sb.AppendLine($"Looking for: {recipeSourceFile}");
                if (System.IO.File.Exists(recipeSourceFile))
                {
                    var codeLines = System.IO.File.ReadLines(recipeSourceFile).Skip(2);
                    var codeText = string.Join(Environment.NewLine, codeLines);
                    return codeText;
                }
            }
            Debug.WriteLine(sb.ToString());

            // Return a message indicating exactly what the user can do to fix the problem.
            StringBuilder sb2 = new StringBuilder();
            sb2.AppendLine($"ERROR: Recipe information file was not found!");
            sb2.AppendLine($"Developers can generate these files by running the tests:");
            sb2.AppendLine($"To run tests from Visual Studio, click 'Test' and select 'Run All Tests'.");
            sb2.AppendLine($"To run tests from the command line, run 'dotnet test' in the src folder.");
            return sb2.ToString();
        }
    }
}
