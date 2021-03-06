﻿using GenericPainter.Mutators;
using GenericPainter.Other;
using System;
using System.Diagnostics;
using System.Linq;

namespace GeneticPainter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // ugly constants
            const int numberOfCandidates = 30;
            const int numberOfGenerations = 3000;

            // loading base structures
            var imageModel = new RgbImage("src/image.png");

            var mutator = new FixedSquareMutator();
            var candidates = new ImageCandidate[numberOfCandidates];

            // creating candidates
            for (var i = 0; i < numberOfCandidates; i++)
            {
                candidates[i] = new ImageCandidate(imageModel);
            }

            // stopwatch for time measurment
            var stopwatch = Stopwatch.StartNew();

            // main iteration loop
            for (var i = 1; i <= numberOfGenerations; i++)
            {
                // mutating loop
                for (var j = 0; j < numberOfCandidates; j++)
                {
                    mutator.Mutate(candidates[j]);
                }

                // scoring loop
                foreach (var candidate in candidates)
                {
                    candidate.Score(imageModel);
                }

                // sorting via score
                candidates = candidates.OrderBy(c => c.Difference).ToArray();

                // coping best candidate as a new generation (crossing)
                for (var j = 1; j < numberOfCandidates; j++)
                {
                    candidates[j].Image.Copy(candidates[0].Image);
                }

                if (i % 10 == 0)
                {
                    candidates[0].Save("src/result" + i + ".png");
                }

                Console.WriteLine("Iteration: " + i +
                    ", time elapsed: " + stopwatch.Elapsed +
                    ", difference: " + candidates[0].PercentageDifference + "%");
            }

        }
    }
}
