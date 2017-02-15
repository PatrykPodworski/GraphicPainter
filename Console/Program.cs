using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using GenericPainter;

namespace GeneticPainter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // ugly constants
            const int numberOfCandidates = 20;
            const int numberOfGenerations = 10000;

            // loading base structures
            var imageModel = Image.FromFile("src/image.png") as Bitmap;
            var mutator = new Mutator(10);
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
                    mutator.Score(candidate);
                }

                // parallel scoring
                //candidates.AsParallel().ForAll(mutator.Score);

                // sorting via score
                candidates = candidates.OrderBy(c => c.Difference).ToArray();

                // coping best candidate as a new generation
                for (var j = 1; j < numberOfCandidates; j++)
                {
                    candidates[j].Bitmap = candidates[0].Bitmap.Clone() as Bitmap;
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
